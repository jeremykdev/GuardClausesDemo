using GuardCluasesDemo.Common.Models;
using GuardCluasesDemo.Common.Business;

namespace GuardClausesDemo.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerWithGuards();

            CustomerWithoutGuards();

            CustomerProcesorWithGuards();

            CustomerProcesorWihoutGuards();
        }

        static void WriteSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("===============================");
        }

        static List<Customer> GetCustomers()
        {
            List<Customer> list = new();

            list.Add(new Customer("Abel", "Adams", "adams@example.com", "505-555-1234", new DateTime(1970, 5, 12), 2));


            list.Add(new Customer("Bernice", "Barnes", "betty@example.com", "505-555-5678", new DateTime(1980, 9, 22), 1));

            Customer c = null;
            list.Add(c);

            return list; 
        }

        static void CustomerProcesorWihoutGuards()
        {
            WriteSeparator();
            Console.WriteLine(nameof(CustomerProcesorWihoutGuards));

            try
            {
                var customers = GetCustomers();
                CustomerProcessor processor = new();
                processor.ProcessWithoutGuards(customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CustomerProcesorWithGuards()
        {
            WriteSeparator();
            Console.WriteLine(nameof(CustomerWithGuards));

            try
            {
                var customers = GetCustomers();
                CustomerProcessor processor = new();
                processor.ProcessWithGuards(customers);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void CustomerWithoutGuards()
        {
            WriteSeparator();
            Console.WriteLine(nameof(CustomerWithoutGuards));

            try
            {
                Customer customer1 = new(5, new DateTime(1983, 6, 20), null, null, null, null);

                // new("Bob", "Smith", "bob@example.com", "505-555-1234", new DateTime(1980, 1, 2), 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CustomerWithGuards()
        {
            WriteSeparator();
            Console.WriteLine(nameof(CustomerWithGuards));

            try
            {
                Customer customer1 = new(null, "Smith", "bob@example.com", "505-555-1234", new DateTime(1980, 1, 2), 2);

                Console.WriteLine(customer1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}