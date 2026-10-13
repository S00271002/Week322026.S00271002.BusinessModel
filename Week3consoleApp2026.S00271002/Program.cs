using Microsoft.EntityFrameworkCore;
using Tracker.WebAPIClient;
using Week32026.BusinessModel;

namespace Week3consoleApp2026.S00271002
{
    internal class Program
    {

        static void Main(string[] args)
        {

            ActivityAPIClient.Track(StudentID: "S0099995",
             StudentName: "Paul Powell Test Account",
             activityName: "Rad301 2026 Week 3 Lab 1",
             Task: "Seeding and using test data");


            using (ProductDBContext db = new ProductDBContext(new DbContextOptions<ProductDBContext>()))
            {
                db.Categories.Add(new Category
                {
                    Description = "Accessories",
                    Products = new List<Product>()
            {
                new Product
                {
                    Description = "Bow Tie",
                    dateFirstIssued = DateTime.Now,
                    QuantityInStock = 200,
                    UnitPrice = 12.99f
                },
            }
                });

                db.SaveChanges();

                foreach (var item in db.Categories.Include(c => c.Products))
                {
                    Console.WriteLine(item.Description);

                    foreach (var product in item.Products)
                    {
                        Console.WriteLine(product.Description);
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
