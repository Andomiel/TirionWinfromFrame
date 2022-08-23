using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirionWinfromFrame.Commons
{
    /// <summary>
    /// 枚举类项目
    /// </summary>
    public class EnumItem
    {
        /// <summary>
        /// 枚举名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 枚举值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 枚举描述
        /// </summary>
        public string Description { get; set; }
    }

    public static class EnumHelper
    {
        private static ConcurrentDictionary<string, List<EnumItem>> dic = new ConcurrentDictionary<string, List<EnumItem>>();

        private static string GetFieldDesc(System.Reflection.FieldInfo field_info)
        {
            object[] attrs = field_info.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if ((attrs != null) && (attrs.Length > 0))
            {
                return (attrs[0] as System.ComponentModel.DescriptionAttribute).Description;
            }
            return field_info.Name;
        }

        /// <summary>
        /// 获取一个枚举类型的列表，用于在dropdownList中显示
        /// </summary>
        /// <returns></returns>
        public static List<EnumItem> GetEnumItems(Type type)
        {
            if (!dic.ContainsKey(type.Name))
            {
                //System.Type type = typeof(T);
                System.Reflection.FieldInfo[] fields = type.GetFields();

                List<EnumItem> itemList = new List<EnumItem>(fields.Length);
                foreach (System.Reflection.FieldInfo fi in fields)
                {
                    if (fi.FieldType == type)
                    {
                        EnumItem item = new EnumItem();
                        item.Name = fi.Name;
                        item.Value = Convert.ToInt32(fi.GetRawConstantValue());
                        item.Description = EnumHelper.GetFieldDesc(fi);

                        if (string.IsNullOrEmpty(item.Description))
                        {
                            item.Description = item.Name;
                        }

                        itemList.Add(item);
                    }
                }
                dic[type.Name] = itemList;
            }
            return new List<EnumItem>(dic[type.Name]);
        }

        /// <summary>
        /// 获取按照枚举值划分的枚举项列表
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="flag">比较方式，0为小于，1为等于，2为大于</param>
        /// <param name="value">比较值</param>
        /// <returns>返回经过比较的枚举项列表</returns>
        public static List<EnumItem> GetEnumItems(Type type, int flag, int value)
        {
            //System.Type type = typeof(T);
            System.Reflection.FieldInfo[] fields = type.GetFields();

            List<EnumItem> itemList = new List<EnumItem>(fields.Length);
            foreach (System.Reflection.FieldInfo fi in fields)
            {
                if (fi.FieldType == type && CompareItem(fi, flag, value))
                {
                    EnumItem item = new EnumItem
                    {
                        Name = fi.Name,
                        Value = Convert.ToInt32(fi.GetRawConstantValue()),
                        Description = EnumHelper.GetFieldDesc(fi)
                    };

                    itemList.Add(item);
                }
            }

            return itemList;
        }

        private static bool CompareItem(System.Reflection.FieldInfo fi, int flag, int value)
        {
            int currValue = Convert.ToInt32(fi.GetRawConstantValue());
            //判断是大于还是小于
            bool toCompare = true;
            if (flag == 0)
            {
                //小于
                toCompare = currValue < value;
            }
            else if (flag == 1)
            {
                //等于
                toCompare = currValue == value;
            }
            else if (flag == 2)
            {
                //大于
                toCompare = currValue > value;
            }
            else
            {
                //留待后续
            }
            return toCompare;
        }

        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="enumType">指定的枚举类型</param>
        /// <param name="enumValue">枚举类型的值</param>
        /// <returns>枚举值的描述,需用DescriptionAttribute进行描述</returns>
        public static string GetDescription(Type enumType, int enumValue)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("enumType不是枚举类型");
            }
            List<EnumItem> items = EnumHelper.GetEnumItems(enumType);
            EnumItem item = items.Find(p => p.Value == enumValue);
            if (item == null)
            {
                // throw new ArgumentException("enumType不包括此枚举值");
                return "未知";
            }
            return item == null ? enumValue.ToString() : item.Description;
        }

        public static string GetDescription(Type enumType, string enumName)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("enumType不是枚举类型");
            }
            if (string.IsNullOrWhiteSpace(enumName))
            {
                return "";
            }
            List<EnumItem> items = GetEnumItems(enumType);
            EnumItem item = items.Find(p => p.Name.Equals(enumName));
            if (item == null)
            {
                // throw new ArgumentException("enumType不包括此枚举值");
                return "未知";
            }
            return item == null ? enumName : item.Description;
        }

        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="enumValue">指定的枚举值: 如SystemParameterEnum.ServerLevel</param>
        /// <returns>枚举值的描述,需用DescriptionAttribute进行描述</returns>
        public static string GetDescription(object enumValue)
        {
            if (enumValue == null)
            {
                throw new ArgumentNullException("enumValue");
            }

            if (enumValue.GetType().IsEnum)
            {
                return EnumHelper.GetDescription(enumValue.GetType(),
                    Convert.ToInt32(enumValue));
            }
            else
            {
                throw new ArgumentException("enumValue不是枚举值");
            }
        }

    }
}
