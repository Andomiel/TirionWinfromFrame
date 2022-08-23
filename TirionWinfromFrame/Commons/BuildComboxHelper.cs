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
                "D1-1","D1-2","D1-3","D1-4",
                "D2-1","D2-2","D2-3","D2-4",
                "D3-1","D3-2","D3-3","D3-4",
                "D4-1","D4-2","D4-3","D4-4",
                "D5-1","D5-2","D5-3","D5-4",
            };
        }

        public static List<string> BuildLightShelf()
        {
            return new List<string>
            {
                "",
                "01",
                "02",
                "03",
                "04",
                "05",
                "06",
                "07",
                "08",
                "09",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20",
                "21"
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
