using System.Net.Mail;

namespace GuardCluasesDemo.Common.Utilities
{
    public static class EmailHelper
    {
        public static bool IsEmailAddress(string input)
        {
            if(String.IsNullOrWhiteSpace(input)) 
                return false;

            try
            {
                var addr = new MailAddress(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
