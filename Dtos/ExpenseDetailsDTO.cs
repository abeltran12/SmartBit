using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBit.Dtos
{
    public class ExpenseDetailsDTO
    {
        public double Amount { get; set; }

        public string ExpenseTypeName { get; set; } = "";
    }
}