using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Semaine_3.Models;
using System.Security.Cryptography;

namespace Semaine_3.client
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the ObjcetContext
            NorthwindContext context = new NorthwindContext();

            // 1. List all customers with a city enter with the keyboard
            /*
            System.Console.WriteLine("Enter a city name: ");
            string city = System.Console.ReadLine();

            IEnumerable<Customer> customers = (from c in context.Customers
                                               where c.City == city
                                               select c);

            foreach (Customer c in customers)
            {
                System.Console.WriteLine(c.ContactName);
            }
            */


            // 2. Display produts of "Baverages" and "Condiments"'s category.
            // Use lazy loading
            // What's lazy loading?
            // Lazy Loading loads the related entities from the database
            //      when you access a navigation property.
            //      At each request (p.Category.CategoryName), a new request is made to the database.
            //      To access to CategoryName.
            /*
            Console.WriteLine("Catégorie : Beverages");
            IQueryable<Product> beverages = from p in context.Products
                                            where p.Category.CategoryName == "Beverages"
                                            select p;

            foreach (Product p in beverages)
            {
                Console.WriteLine("{0}", p.ProductName);
            }

            Console.WriteLine("Catégorie : Condiment");
            IQueryable<Product> condiments = from p in context.Products
                                             where p.Category.CategoryName == "Condiments"
                                             select p;

            foreach (Product p in condiments)
            {
                Console.WriteLine("{0}", p.ProductName);
            }
            */


            // 3. Display produts of "Baverages et Condiments"'s category.
            // Use eager loading
            // What's eager loading?
            // Eager Loading loads the related entities from the database directly with .Include()
            //      when you access a navigation property.
            //      No need to make a new request to the database at each request.
            /*
            Console.WriteLine("Catégorie : Beverages");
            IQueryable<Product> beverages = from p in context.Products
                                            .Include(p => p.Category)
                                            where p.Category.CategoryName == "Beverages"
                                            select p;

            foreach (Product p in beverages)
            {
                Console.WriteLine("{0}", p.ProductName);
            }

            Console.WriteLine("Catégorie : Condiment");
            IQueryable<Product> condiments = from p in context.Products
                                             .Include(p => p.Category)
                                             where p.Category.CategoryName == "Condiments"
                                             select p;

            foreach (Product p in condiments)
            {
                Console.WriteLine("{0}", p.ProductName);
            }
            */

            // 4. Give for a client enter with the keyboard, the list of his orders ordered by date.
            //      where the command is delivered.
            //      THe list must contain CustomerID, OrderDate, ShippedDate
            /*
            System.Console.WriteLine("Enter a client ID: ");
            string clientID = System.Console.ReadLine();

            var QueryResult4 = from o in context.Orders
                               where o.CustomerId == clientID && o.ShippedDate != null
                               orderby o.OrderDate ascending
                               select new
                               {
                                   CustomerID = o.CustomerId,
                                   OrderDate = o.OrderDate,
                                   ShippedDate = o.ShippedDate
                               };

            foreach (var o in QueryResult4)
            {
                System.Console.WriteLine("CustomerID: {0}, OrderDate: {1}, ShippedDate: {2}", o.CustomerID, o.OrderDate, o.ShippedDate);
            }
            */

            // 5. Display the total of sells by product (productID -> Total) ordered by productID
            /*
            var QueryResult5 = from od in context.OrderDetails
                               group od by od.ProductId into g
                               orderby g.Key
                               select new
                               {
                                   ProductID = g.Key,
                                   Total = g.Sum(od => od.Quantity)
                               };

            foreach (var od in QueryResult5)
            {
                System.Console.WriteLine("{0} ----> {1}", od.ProductID, od.Total);
            }
            */

            // 6. Display all employees (their name) who are responsible for the "Western" region
            /*
            Console.WriteLine("List of employess of the Western region");
            IQueryable<Employee> employees = from e in context.Employees
                               where e.Territories.Any(t => t.Region.RegionDescription == "Western")
                               select e;

            foreach (Employee e in employees)
            {
                Console.WriteLine("{0}", e.LastName);
            }
            */

            // 7. Display the territories managed by the superior of "Suyama Michael"
            /*
            Console.WriteLine("Territories managed by the superior of Suyama Michael");
            var territories = (from e in context.Employees
                               where e.LastName.Equals("Suyama")
                               select e.ReportsToNavigation.Territories).SingleOrDefault();

            foreach (Territory territory in territories)
            {
                Console.WriteLine(territory.TerritoryDescription);
            }
            */

            // C.1 Give a capital letter to the first letter of the name of all customers
            /*
            foreach (Customer c in context.Customers)
            {
                c.ContactName = c.ContactName.ToUpper();
            }

            context.SaveChanges();

            // C.2 Verify the insertion
            foreach (Customer c in context.Customers)
            {
                Console.WriteLine(c.ContactName);
            }
            */

            // D.1 Insert a category by keyboard entry
            
            System.Console.WriteLine("Enter a cateogy name: ");
            string name = System.Console.ReadLine();

            Category nc = new Category();
            nc.CategoryName = name;

            context.Categories.Add(nc);
            context.SaveChanges();

            // D.2 Verify the insertion
            Console.WriteLine("After insertion :");
            foreach (Category c in context.Categories)
            {
                System.Console.WriteLine(c.CategoryName);
            }
            

            // E.1 Delete the added category
            foreach (Category c in context.Categories)
            {
                if (c.CategoryName.Equals(name))
                {
                    context.Categories.Remove(c);
                }
            }

            context.SaveChanges();

            // E.2 Verify the deletion
            Console.WriteLine("After deletion :");
            foreach (Category c in context.Categories)
            {
                System.Console.WriteLine(c.CategoryName);
            }










        }
    }
}   