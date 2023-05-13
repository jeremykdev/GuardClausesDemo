using Ardalis.GuardClauses;
using GuardCluasesDemo.Common.Guards;
using GuardCluasesDemo.Common.Utilities;

namespace GuardCluasesDemo.Common.Models
{

    public class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public int NumberOfDogs { get; set; }

        public override string ToString()
        {
            return $"Customer: {FirstName} {LastName}";
        }

        /// <summary>
        /// Ctor with guard clauses
        /// </summary>
        public Customer(string firstName, string lastName, string email, string phoneNumber, DateTime birthday, int numberOfDogs)
        {
            this.FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
            this.LastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
            this.NumberOfDogs = Guard.Against.OutOfRange(numberOfDogs, nameof(numberOfDogs), 1, 101);
            this.Birthday = Guard.Against.OutOfSQLDateRange(birthday, nameof(birthday));
            this.Email = Guard.Against.NonEmail(email, nameof(email));
            this.Phone = Guard.Against.NonPhoneNumber(phoneNumber, nameof(phoneNumber));
        }

        /// <summary>
        /// Ctor without guard clauses
        /// </summary>
        public Customer(int numberOfDogs, DateTime birthday, string firstName, string lastName, string email, string phoneNumber)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Cannot be null or whitespace", nameof(firstName));

            if (String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Cannot be null or whitespace", nameof(lastName));

            if (numberOfDogs < 1 || numberOfDogs > 101)
                throw new ArgumentException("Must be between 1 and 101", nameof(numberOfDogs));

            if (birthday < new DateTime(1753, 1, 1) || birthday > new DateTime(9999, 12, 31, 23, 59, 59))
                throw new ArgumentOutOfRangeException(nameof(birthday));

            if (!EmailHelper.IsEmailAddress(email))
                throw new ArgumentException("Must be an email address", nameof(email));

            if (!PhoneNumberHelper.IsUsPhoneNumber(phoneNumber))
                throw new ArgumentException("Must be a phone number", nameof(phoneNumber));

            this.FirstName = firstName;
            this.LastName = lastName;
            this.NumberOfDogs = numberOfDogs;
            this.Birthday = birthday;
            this.Email = email;
            this.Phone = phoneNumber;
        }
    }
}