using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SmartBit.Models
{
    public enum TypeMonetaryFund
    {
        [Display(Name = "Cash")]
        Cash = 0,
        
        [Display(Name = "CheckingAccount")]
        CheckingAccount = 1,
        
        [Display(Name = "SavingsAccount")]
        SavingsAccount = 2
    }

    public static class TypeMonetaryFundHelper
    {
        public static bool IsValid(int value)
        {
            return Enum.IsDefined(typeof(TypeMonetaryFund), value);
        }

        public static string? GetName(int value)
        {
            return Enum.IsDefined(typeof(TypeMonetaryFund), value)
                    ? Enum.GetName(typeof(TypeMonetaryFund), value)
                    : null;
        }

        public static string GetDisplayName(TypeMonetaryFund type)
        {
            var field = typeof(TypeMonetaryFund).GetField(type.ToString());
            var attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? type.ToString();
        }
        
        // Método para obtener todos los valores con sus Display Names
        public static Dictionary<TypeMonetaryFund, string> GetAllWithDisplayNames()
        {
            return Enum.GetValues<TypeMonetaryFund>()
                .ToDictionary(e => e, e => GetDisplayName(e));
        }
    }
}