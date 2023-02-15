using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirionWinfromFrame.Commons
{
    public static class BuildComboxHelper
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

        public static List<string> TransformationShelf = new List<string>
            {
                "",
                "H001","H002","H003"
            };


        public static List<string> PalletAreas = new List<string> {
        "",
        "ZB-01", "ZB-02", "ZB-03", "ZB-04", "ZB-05", "ZB-06", "ZB-07", "ZB-08",
         "ZB-09", "ZB-10", "ZB-11", "ZB-12", "ZB-13", "ZB-14", "ZB-15", "ZB-16",
         "ZB-17","ZB-18","ZB-19","ZB-20"
        };

        public static List<string> NearbyAreas = new List<string>()
        {
                "",
                "L001",
                "L002",
                "L003",
                "L004",
                "L005",
                "L006",
                "L007"
        };

        public static List<string> LightShelf = new List<string>
            {
                "",
                "L008",
                "L009",
                "L010"
            };


        public static List<string> AbSide = new List<string>
            {
                "",
                "A",
                "B"
            };

    }
}
