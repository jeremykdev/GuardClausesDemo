using Ardalis.GuardClauses;
using GuardCluasesDemo.Common.Models;
using System.Security.Cryptography.X509Certificates;

namespace GuardCluasesDemo.Common.Business
{
    public class CustomerProcessor
    {
        protected static Func<IEnumerable<Customer>, bool> HasNoNullMembers => customers => !customers.Any(x => x is null);

        public void ProcessWithGuards(IEnumerable<Customer> customers)
        {
            
            try
            {
                Guard.Against.NullOrEmpty(customers);

                Guard.Against.NullOrInvalidInput<IEnumerable<Customer>>(customers, nameof(customers), HasNoNullMembers, "Customers list may not contain null members");

                foreach (var c in customers)
                    Console.WriteLine(c.ToString());

            }
            catch(Exception ex)
            {
                Console.WriteLine("Processing failed");
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Processing success!");
                        
        }

        public void ProcessWithoutGuards(IEnumerable<Customer> customers)
        {
            
            try
            {               

                foreach (var c in customers)
                    Console.WriteLine(c.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Processing failed");
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Processing success!");

        }
    }
}
