using Ardalis.GuardClauses;
using GuardCluasesDemo.Common.Utilities;

namespace GuardCluasesDemo.Common.Guards
{
    public static class NonPhoneNumberGuard
    {
        public static string NonPhoneNumber(this IGuardClause guard, string input, string parameterName)
        {
            if(!PhoneNumberHelper.IsUsPhoneNumber(input)) 
                throw new ArgumentException("Must be a phone number", parameterName);

            return input;
        }
    }
}
