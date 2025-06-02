namespace SmartBit.Models
{
    public enum DocumentType
    {
        Voucher = 0,
        Invoice = 1,
        Other = 2
    }

    public static class DocumentTypeHelper
    {
        public static string GetStringValue(DocumentType type)
        {
            return type.ToString();
        }

        public static bool IsValid(int value)
        {
            return Enum.IsDefined(typeof(DocumentType), value);
        }
    }
}