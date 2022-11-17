using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirionWinfromFrame.Commons
{
    public class BuildComboxHelper
    {
        public static List<EnumItem> BuildComboxWithoutEmptyFromEnum(Type enumType)
        {
            List<EnumItem> enumItems = EnumHelper.GetEnumItems(enumType);
            return enumItems;
        }

        public static List<EnumItem> BuildComboxWithEmptyFromEnum(Type enumType)
        {
            List<EnumItem> enumItems = new List<EnumItem>
            {
                new EnumItem
                {
                    Name = string.Empty,
                    Value = -1,
                    Description = string.Empty
                }
            };
            enumItems.AddRange(BuildComboxWithoutEmptyFromEnum(enumType));
            return enumItems;
        }

        public static List<string> BuildTransformationShelf()
        {
            return new List<string>
            {
                "",
                "H001","H002","H003"
            };
        }

        public static List<string> BuildLightShelf()
        {
            return new List<string>
            {
                "",
                "SWHY001",
                "SWHY002",
                "SWHY003"
            };
        }

        public static List<string> BuildAbSide()
        {
            return new List<string>
            {
                "",
                "A",
                "B"
            };

        }
    }
}
