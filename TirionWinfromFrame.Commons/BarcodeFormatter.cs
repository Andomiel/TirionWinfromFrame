using System.Linq;

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
            int starCount = originBarcode.ToCharArray().Count(p => p.Equals('*'));
            if (starCount < 6 || starCount > 9)
            {
                throw new OppoCoreException($"二维码格式不正确，内部包含{starCount}个*号");
            }
            var elements = originBarcode.Split('*');
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].Trim();
            }
            return string.Join("*", elements);
        }
    }
}
