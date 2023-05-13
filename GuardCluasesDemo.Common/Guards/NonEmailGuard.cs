using Ardalis.GuardClauses;
using GuardCluasesDemo.Common.Utilities;

namespace GuardCluasesDemo.Common.Guards
{
    public static class NonEmailGuard
    {
        public static string NonEmail(this IGuardClause guard, string input, string parameterName)
        {
            if (!EmailHelper.IsEmailAddress(input))
                throw new ArgumentException("Must be an email address", parameterName);

            return input;
        }

    }
}
