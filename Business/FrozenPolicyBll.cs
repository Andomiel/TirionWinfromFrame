using DataBase;
using Entity;
using Entity.DataContext;
using Entity.Dto;
using Entity.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TirionWinfromFrame.Commons;

namespace Business
{
    public static class FrozenPolicyBll
    {
        private static string QueryInventoryBaseSql =>
                      @"SELECT szm.ReelID,
                               szm.QRcode,
                               szm.Part_Number as PartNumber,
                               szm.WZ_SCCJ as Manufacturer,
                               szm.DateCode,
                               szm.SerialNo,
                               szm.LockTowerNo,
                               stm.Description as Tower,
                               szm.ABSide,
                               szm.LockMachineID,
                               szm.LockLocation,
                               szm.ReelType,
                               szm.SaveTime,
                               szm.Qty
                          FROM smt_zd_material szm  WITH(NOLock) 
                     LEFT JOIN smt_TowerMap stm WITH(NOLock) 
                            ON szm.LockTowerNo = stm.TowerNo
                     LEFT JOIN smt_bake sb WITH(NOLock) 
                            ON szm.ReelID = sb.UPN
                         WHERE szm.Qty > 0
                           AND sb.UPN is null
                           AND szm.isTakeCheck = 0 ";

        private static string QueryUpnBaseSql => @" SELECT szm.ReelID,szm.DateCode FROM smt_zd_material szm  WITH(NOLock) WHERE 1=1 ";

        public static string BuildWhereCondition(MaterialQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            if (condition.ExceedStart != 0 && condition.ExceedEnd != 0)
            {
                DateTime today = DateTime.Today;
                DateTime exceedDt1;
                DateTime exceedDt2;
                if (condition.ExceedStart > condition.ExceedEnd)
                {
                    exceedDt1 = today.AddDays(-condition.ExceedStart);
                    exceedDt2 = today.AddDays(-condition.ExceedEnd); ;
                }
                else
                {
                    exceedDt2 = today.AddDays(-condition.ExceedStart);
                    exceedDt1 = today.AddDays(-condition.ExceedEnd); ;
                }
                sb.Append($" AND szm.SaveTime BETWEEN '{exceedDt1}' AND '{exceedDt2}' ");
            }
            else
            {
                if (condition.haveSaveTimeQuery)
                {
                    sb.Append($" AND szm.SaveTime BETWEEN '{condition.SaveTimeStart}' AND '{condition.SaveTimeEnd}' ");
                }
            }
            if (!string.IsNullOrWhiteSpace(condition.UPN))
            {
                sb.Append($" AND szm.ReelId = '{condition.UPN}' ");
            }
            if (!string.IsNullOrWhiteSpace(condition.PartNumber))
            {
                sb.Append($" AND szm.Part_Number = '{condition.PartNumber}' ");
            }
            if (!string.IsNullOrWhiteSpace(condition.Supplier))
            {
                sb.Append($" AND szm.WZ_SCCJ='{condition.Supplier}' ");
            }

            if (!string.IsNullOrWhiteSpace(condition.ABSide))
            {
                sb.Append($" AND szm.ABSide='{condition.ABSide}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MachineId))
            {
                sb.Append($" AND szm.LockMachineID='{condition.MachineId}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MSD))
            {
                sb.Append($" AND szm.MSD='{condition.MSD}'");
            }
            if (condition.TowerNo != -1)
            {
                sb.Append($" AND szm.LockTowerNo={condition.TowerNo}");
            }

            if (!string.IsNullOrWhiteSpace(condition.SerialNoStart))
            {
                sb.Append($" AND szm.SerialNo >= '{condition.SerialNoStart}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.SerialNoEnd))
            {
                sb.Append($" AND szm.SerialNo <= '{condition.SerialNoEnd}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MateType))
            {
                sb.Append($" AND szm.ReelType = '{condition.MateType}'");
            }
            return sb.ToString();
        }

        public static IEnumerable<FrozenQueryItem> GetInventory(MaterialQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(QueryInventoryBaseSql);
            sb.Append(BuildWhereCondition(condition));
            var queryResult = DbHelper.GetDataTable(sb.ToString()).DataTableToList<FrozenQueryItem>();

            if (condition.haveCycleQuery)
            {
                queryResult = queryResult.Where(p => (DateTime.Compare(p.DateCodeDate, condition.CycleStart) >= 0
                                                  && DateTime.Compare(p.DateCodeDate, condition.CycleEnd) <= 0)
                                                  || p.DateCodeDate.Year == 1900).ToList();
            }
            return queryResult;
        }

        public static List<PolicyView> GetAllFrozenPolicies()
        {
            List<PolicyView> policyViews = new List<PolicyView>();
            string selPolicy = " SELECT * FROM smt_FrozenPolicy ";
            var list = DbHelper.GetDataTable(selPolicy).DataTableToList<FrozenPolicy>();
            string selDetail = " SELECT * FROM smt_FrozenPolicyDetail ";
            var detailList = DbHelper.GetDataTable(selDetail).DataTableToList<FrozenPolicyDetail>();

            foreach (var policy in list)
            {
                PolicyView policyView = new PolicyView()
                {
                    Id = policy.Id,
                    FrozenNo = policy.FrozenNo,
                    CreateTime = policy.CreateTime,
                    CreateUser = policy.CreateUser,
                    UpdateTime = policy.UpdateTime,
                    UpdateUser = policy.UpdateUser,
                    Enable = policy.Enable,
                    FileSrc = policy.FileSrc,
                    Remark = policy.Remark,
                    PolicyType = policy.PolicyType,
                    ConditionJson = policy.ConditionJson,
                    PolicyDetail = JsonConvert.SerializeObject(detailList.Where(p => p.FrozenNo == policy.FrozenNo).ToList())
                };
                policyViews.Add(policyView);
            }
            return policyViews;
        }

        /// <summary>
        /// 按查询条件创建冻结策略
        /// </summary>
        /// <param name="condition"></param>
        public static PolicyCreateResult SavePolicy(MaterialQueryCondition condition, string remark, string currentUser)
        {
            PolicyCreateResult createResult = new PolicyCreateResult();
            try
            {
                IEnumerable<FrozenQueryItem> inventories = GetInventory(condition);
                List<string> upns = inventories.Select(p => p.ReelID).ToList();
                createResult.Policy = new FrozenPolicy(DateTime.Now, PolicyTypeEnum.Conditions, remark);
                createResult.Policy.ConditionJson = JsonConvert.SerializeObject(condition);
                createResult.Details = BuildPolicyDetails(createResult.Policy.FrozenNo, condition);
                createResult.FrozenMaterials = BuildMaterialFrozen(createResult.Policy.FrozenNo, upns, currentUser);
                createResult.Result = SavePolicyAndHoldUpn(createResult);
            }
            catch (Exception ex)
            {
                string exString = $"按查询条件创建策略失败{Environment.NewLine}{ex.Message}";
                FileLog.Log(exString);
                throw new OppoCoreException(exString);
            }
            return createResult;
        }

        /// <summary>
        /// 批量UPN创建冻结
        /// </summary>
        /// <param name="upns"></param>
        public static PolicyCreateResult SavePolicy(List<string> upns, string remark, string currentUser)
        {
            PolicyCreateResult createResult = new PolicyCreateResult();
            try
            {
                createResult.Policy = new FrozenPolicy(DateTime.Now, PolicyTypeEnum.UPNs, remark);
                createResult.Details = new List<FrozenPolicyDetail>();
                foreach (string upn in upns)
                {
                    createResult.Details.Add(new FrozenPolicyDetail(createResult.Policy.FrozenNo, upn));
                }
                createResult.FrozenMaterials = BuildMaterialFrozen(createResult.Policy.FrozenNo, upns, currentUser);
                createResult.Result = SavePolicyAndHoldUpn(createResult);
            }
            catch (Exception ex)
            {
                string exString = $"批量UPN创建策略失败{Environment.NewLine}{ex.Message}";
                FileLog.Log(exString);
                throw new OppoCoreException(exString);
            }
            return createResult;
        }

        private static bool SavePolicyAndHoldUpn(PolicyCreateResult createResult)
        {
            bool result = false;
            try
            {
                SaveMaterialFrozen(createResult.FrozenMaterials);
                SaveTablePolicy(createResult.Policy);
                SaveTablePolicyDetails(createResult.Details);
                result = true;
            }
            catch (Exception ex)
            {
                FileLog.Log($"创建策略，同时冻结对应UPN:【{ex.Message}】");
            }
            return result;
        }

        private static void SaveTablePolicy(FrozenPolicy policy)
        {
            string policyInsSql = $@" INSERT INTO smt_FrozenPolicy
                                        (FrozenNo,CreateTime,
                                            CreateUser,UpdateTime,
                                            UpdateUser,Enable,
                                            FileSrc,Remark,
                                            PolicyType,ConditionJson)
                                            VALUES 
                                        ('{policy.FrozenNo}','{policy.CreateTime}',
                                            '{policy.CreateUser}','{policy.UpdateTime}',
                                            '{policy.UpdateUser}','{policy.Enable}',
                                            '{policy.FileSrc}','{policy.Remark}',
                                            '{policy.PolicyType}','{policy.ConditionJson}') ";
            DbHelper.Insert(policyInsSql);
        }

        private static void SaveTablePolicyDetails(List<FrozenPolicyDetail> details)
        {
            string policyDetailInsSql = $@" INSERT INTO smt_FrozenPolicyDetail
                                                     (FrozenNo,FieldName,
                                                      FieldDes,Operator,FieldValue)
                                                    VALUES ";
            List<string> values = new List<string>();
            foreach (var detail in details)
            {
                values.Add($@" ('{detail.FrozenNo}','{detail.FieldName}',
                                        '{detail.FieldDes}','{detail.Operator}','{detail.FieldValue}') ");
            }
            DbHelper.Insert($"{policyDetailInsSql} {string.Join(",", values)}");
        }

        private static List<FrozenPolicyDetail> BuildPolicyDetails(string frozenNo, MaterialQueryCondition condition)
        {
            List<FrozenPolicyDetail> details = new List<FrozenPolicyDetail>();
            if (condition.ExceedStart != 0 && condition.ExceedEnd != 0)
            {
                DateTime today = DateTime.Today;
                DateTime exceedDt1;
                DateTime exceedDt2;
                if (condition.ExceedStart > condition.ExceedEnd)
                {
                    exceedDt1 = today.AddDays(-condition.ExceedStart);
                    exceedDt2 = today.AddDays(-condition.ExceedEnd); ;
                }
                else
                {
                    exceedDt2 = today.AddDays(-condition.ExceedStart);
                    exceedDt1 = today.AddDays(-condition.ExceedEnd); ;
                }
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "SaveTime",
                    FieldDes = "入库时间",
                    Operator = (int)PolicyOperator.Gte,
                    FieldValue = exceedDt1.ToString("yyyy-MM-dd HH:mm:ss"),
                });
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "SaveTime",
                    FieldDes = "入库时间",
                    Operator = (int)PolicyOperator.Lte,
                    FieldValue = exceedDt2.ToString("yyyy-MM-dd HH:mm:ss"),
                });
            }
            else
            {
                if (condition.haveSaveTimeQuery)
                {
                    details.Add(new FrozenPolicyDetail(frozenNo)
                    {
                        FieldName = "SaveTime",
                        FieldDes = "入库时间",
                        Operator = (int)PolicyOperator.Gte,
                        FieldValue = condition.SaveTimeStart.ToString("yyyy-MM-dd HH:mm:ss"),
                    });
                    details.Add(new FrozenPolicyDetail(frozenNo)
                    {
                        FieldName = "SaveTime",
                        FieldDes = "入库时间",
                        Operator = (int)PolicyOperator.Lte,
                        FieldValue = condition.SaveTimeEnd.ToString("yyyy-MM-dd HH:mm:ss"),
                    });
                }
            }
            if (!string.IsNullOrWhiteSpace(condition.UPN))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "ReelId",
                    FieldDes = "UPN",
                    Operator = (int)PolicyOperator.Eq,
                    FieldValue = condition.UPN,
                });
            }
            if (!string.IsNullOrWhiteSpace(condition.PartNumber))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "Part_Number",
                    FieldDes = "料号",
                    Operator = (int)PolicyOperator.Eq,
                    FieldValue = condition.PartNumber,
                });
            }
            if (!string.IsNullOrWhiteSpace(condition.Supplier))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "WZ_SCCJ",
                    FieldDes = "供货厂家",
                    Operator = (int)PolicyOperator.Eq,
                    FieldValue = condition.Supplier,
                });
            }

            if (!string.IsNullOrWhiteSpace(condition.ABSide))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "ABSide",
                    FieldDes = "巷道",
                    Operator = (int)PolicyOperator.Eq,
                    FieldValue = condition.ABSide,
                });
            }
            if (!string.IsNullOrWhiteSpace(condition.MachineId))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "LockMachineID",
                    FieldDes = "货架",
                    Operator = (int)PolicyOperator.Eq,
                    FieldValue = condition.MachineId,
                });
            }
            if (!string.IsNullOrWhiteSpace(condition.MSD))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "MSD",
                    FieldDes = "MSD",
                    Operator = (int)PolicyOperator.Eq,
                    FieldValue = condition.MSD,
                });
            }
            if (condition.TowerNo != -1)
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "LockTowerNo",
                    FieldDes = "库区",
                    Operator = (int)PolicyOperator.Eq,
                    FieldValue = condition.TowerNo.ToString(),
                });
            }

            if (!string.IsNullOrWhiteSpace(condition.SerialNoStart))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "SerialNo",
                    FieldDes = "流水号",
                    Operator = (int)PolicyOperator.Gte,
                    FieldValue = condition.SerialNoStart,
                });
            }
            if (!string.IsNullOrWhiteSpace(condition.SerialNoEnd))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "SerialNo",
                    FieldDes = "流水号",
                    Operator = (int)PolicyOperator.Lte,
                    FieldValue = condition.SerialNoEnd,
                });
            }
            if (!string.IsNullOrWhiteSpace(condition.MateType))
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "ReelType",
                    FieldDes = "类型",
                    Operator = (int)PolicyOperator.Eq,
                    FieldValue = condition.MateType,
                });
            }
            if (condition.haveCycleQuery)
            {
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "DateCode",
                    FieldDes = "生产日期",
                    Operator = (int)PolicyOperator.Gte,
                    FieldValue = condition.CycleStart.ToString("yyyy-MM-dd HH:mm:ss"),
                });
                details.Add(new FrozenPolicyDetail(frozenNo)
                {
                    FieldName = "DateCode",
                    FieldDes = "生产日期",
                    Operator = (int)PolicyOperator.Lte,
                    FieldValue = condition.CycleEnd.ToString("yyyy-MM-dd HH:mm:ss"),
                });
            }

            return details;
        }

        private static List<MaterialFrozen> BuildMaterialFrozen(string frozenNo, List<string> upns, string currentUser)
        {
            List<MaterialFrozen> materialFrozens = new List<MaterialFrozen>();
            DateTime now = DateTime.Now;
            foreach (var upn in upns)
            {
                materialFrozens.Add(new MaterialFrozen
                {
                    UPN = upn,
                    FrozenNo = frozenNo,
                    CreateTime = now,
                    CreateUser = currentUser
                });
            }
            return materialFrozens;
        }

        public static bool OperatePolicyEnable(List<PolicyView> policyViews, FrozenOperateType operate, string currentUser)
        {
            bool result = false;
            //禁用 和 删除（依照单号，删除冻结表 所有相关数据）
            if (operate == FrozenOperateType.Unable || operate == FrozenOperateType.Del)
            {
                result = OperatePolicyThawMaterial(policyViews, operate, currentUser);
            }
            //启用（依照策略，重新构建冻结表相关数据）
            else
            {
                result = OperatePolicyFreezeMaterial(policyViews, currentUser);
            }
            return result;
        }

        private static bool OperatePolicyThawMaterial(List<PolicyView> policyViews, FrozenOperateType operate, string currentUser)
        {
            try
            {
                List<string> frozenNos = policyViews.Select(p => p.FrozenNo).ToList();
                if (operate == FrozenOperateType.Unable)
                {
                    EnabledFrozenPolicies(policyViews, 0, currentUser);
                }
                if (operate == FrozenOperateType.Del)
                {
                    DbHelper.Delete($@" DELETE FROM smt_FrozenPolicy WHERE FrozenNo IN ('{string.Join("','", frozenNos)}') ");
                    DbHelper.Delete($@" DELETE FROM smt_FrozenPolicyDetail WHERE FrozenNo IN ('{string.Join("','", frozenNos)}') ");
                }
                Thread.Sleep(500);
                string delRelationSql = $@" DELETE FROM smt_Material_Frozen
                                                  WHERE FrozenNo IN ('{string.Join("','", frozenNos)}')";
                DbHelper.Delete(delRelationSql);
                return true;
            }
            catch (Exception ex)
            {
                FileLog.Log($"{EnumHelper.GetDescription(operate)}策略失败：【{ex.Message}】");
                return false;
            }
        }

        private static bool OperatePolicyFreezeMaterial(List<PolicyView> policyViews, string currentUser)
        {
            List<MaterialFrozen> frozenMaterials = BuildMaterialFrozen(policyViews, currentUser);
            try
            {
                SaveMaterialFrozen(frozenMaterials);
                EnabledFrozenPolicies(policyViews, 1, currentUser);
                return true;
            }
            catch (Exception ex)
            {
                FileLog.Log($"启用策略失败：【{ex.Message}】");
                return false;
            }
        }

        private static void SaveMaterialFrozen(List<MaterialFrozen> frozenMaterials)
        {
            List<Task> taskArr = new List<Task>();
            int times = 0;
            while (true)
            {
                var oneGroup = frozenMaterials.Skip(1000 * times).Take(1000).ToList();
                if (oneGroup.Count == 0)
                {
                    break;
                }
                taskArr.Add(Task.Run(() =>
                {
                    List<string> insertValues = oneGroup.Select(p => $"('{p.UPN}','{p.FrozenNo}','{p.CreateUser}','{p.CreateTime}')").ToList();
                    string insertSql = $@" INSERT INTO smt_Material_Frozen (UPN, FrozenNo, CreateUser, CreateTime) 
                                                    VALUES {string.Join(",", insertValues)}";
                    DbHelper.Insert(insertSql);
                }));
                times++;
            }

            Task.WaitAll(taskArr.ToArray());
        }

        private static void EnabledFrozenPolicies(List<PolicyView> policyViews, int enable, string currentUser)
        {
            List<string> frozenNos = policyViews.Select(p => p.FrozenNo).ToList();
            string sql = $@" UPDATE smt_FrozenPolicy 
                                SET UpdateTime = '{DateTime.Now}',
                                    UpdateUser = '{currentUser}',
                                    Enable = {enable}
                              WHERE FrozenNo IN ('{string.Join("','", frozenNos)}')";
            DbHelper.Update(sql);
        }

        private static List<MaterialFrozen> BuildMaterialFrozen(List<PolicyView> policyViews, string currentUser)
        {
            List<FrozenNoUpnRelation> relations = new List<FrozenNoUpnRelation>();
            relations.AddRange(GetRelationsByUpnPolicy(policyViews));
            relations.AddRange(GetRelationsByConditionPolicy(policyViews));

            return relations.Select(p =>
                        new MaterialFrozen
                        {
                            UPN = p.UPN,
                            FrozenNo = p.FrozenNo,
                            CreateUser = currentUser,
                        }).ToList();
        }

        private static IEnumerable<FrozenNoUpnRelation> GetRelationsByUpnPolicy(List<PolicyView> policyViews)
        {
            //批量UPN冻结的部分
            List<string> frozenNoForUpn = policyViews.Where(p => p.PolicyType == (int)PolicyTypeEnum.UPNs).Select(p => p.FrozenNo).ToList();

            string sql = $@" SELECT FrozenNo,FieldValue 
                               FROM smt_FrozenPolicyDetail
                              WHERE FrozenNo IN ('{string.Join("','", frozenNoForUpn)}') ";
            return DbHelper.GetDataTable(sql).DataTableToList<FrozenNoUpnRelation>();
        }

        private static List<FrozenNoUpnRelation> GetRelationsByConditionPolicy(List<PolicyView> policyViews)
        {
            List<FrozenNoUpnRelation> relations = new List<FrozenNoUpnRelation>();
            //查询条件的冻结部分
            List<PolicyView> policyConditions = policyViews.Where(p => p.PolicyType == (int)PolicyTypeEnum.Conditions).ToList();
            foreach (var policy in policyConditions)
            {
                var queryCondition = JsonConvert.DeserializeObject<MaterialQueryCondition>(policy.ConditionJson);
                string sql = $"{QueryUpnBaseSql} {BuildWhereCondition(queryCondition)}";
                var queryResult = DbHelper.GetDataTable(sql).DataTableToList<FrozenQueryItem>();

                if (queryCondition.haveCycleQuery)
                {
                    queryResult = queryResult.Where(p => (DateTime.Compare(p.DateCodeDate, queryCondition.CycleStart) >= 0
                                                      && DateTime.Compare(p.DateCodeDate, queryCondition.CycleEnd) <= 0)
                                                      || p.DateCodeDate.Year == 1900).ToList();
                }
                relations.AddRange(queryResult.Select(p =>
                                new FrozenNoUpnRelation { UPN = p.ReelID, FrozenNo = policy.FrozenNo })
                                .ToList());
            }
            return relations;
        }

    }
}
