using System.ComponentModel;

namespace Entity.Enums
{
    public enum PolicyOperator
    {
        [Description("等于")]
        Eq,
        [Description("大于")]
        Gt,
        [Description("大于等于")]
        Gte,
        [Description("小于")]
        Lt,
        [Description("小于等于")]
        Lte,
        [Description("包含")]
        In,
        [Description("不等于")]
        Neq,
    }

    public enum PolicyTypeEnum
    {
        [Description("批量UPN")]
        UPNs,
        [Description("查询条件筛选")]
        Conditions,
    }

    public enum FrozenOperateType
    {
        [Description("启用")]
        Enable = 1,
        [Description("禁用")]
        Unable = 0,
        [Description("删除")]
        Del = -1
    }

    public enum FrozenRemindBtnType
    {
        [Description("全部显示")]
        All,
        [Description("只按条件筛选")]
        OnlyCondition,
        [Description("只指定UPN")]
        OnlyUpns,
    }
}
