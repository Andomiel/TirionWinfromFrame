using System.Linq;
using System.Text.RegularExpressions;

namespace TirionWinfromFrame.Commons
{
    public static class BarcodeFormatter
    {
        public static string FormatBarcode(string originBarcode)
        {
            if (string.IsNullOrWhiteSpace(originBarcode))
            {
                throw new OppoCoreException("要格式化的二维码为空");
            }

            Regex reg = new Regex("^[0-9]");
            if (!reg.IsMatch(originBarcode))
            {
                throw new OppoCoreException("UPN不是以数字开头");
            }

            int starCount = originBarcode.ToCharArray().Count(p => p.Equals('*'));
            if (starCount < 6 || starCount > 9)
            {
                throw new OppoCoreException($"二维码格式不正确，内部包含{starCount}个*号");
            }

            var elements = originBarcode.Split('*');
            string upn = elements[0];
            string[] upnElements = upn.Split('-');
            if (upnElements.Length == 0 || (upnElements[0].Length != 7 && upnElements[0].Length != 12))
            {
                throw new OppoCoreException($"UPN中第一段物料号必须为7位老料号或者12位新料号");
            }
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].Trim();
            }
            return string.Join("*", elements);
        }

    }
}
