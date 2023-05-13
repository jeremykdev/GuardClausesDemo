using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardCluasesDemo.Common.Utilities
{
    public static class PhoneNumberHelper
    {
        public static bool IsUsPhoneNumber(string input)
        {
            if(String.IsNullOrWhiteSpace(input)) 
                return false;

            if (input.Where(c => Char.IsDigit(c)).Count() == 10)
                return true;

            return false;
        }

    }
}
