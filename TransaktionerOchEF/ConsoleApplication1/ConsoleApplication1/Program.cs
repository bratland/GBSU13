using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Proxy();
            foreach (var item in db.Items)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }

            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var scope2 = new TransactionScope())
                    {

                        db.Items.Add(new Item { Id = db.Items.Max(i => i.Id) + 1, Name = "Anders" });
                        db.SaveChanges();
                        scope2.Complete();
                    }
                    db.Items.Add(new Item { Id = db.Items.Max(i => i.Id) + 2, Name = "Anders" });
                    db.Items.Add(new Item { Id = db.Items.Max(i => i.Id) + 3, Name = "Anders" });
                    db.SaveChanges();
                    throw new Exception("No goood");
                    scope.Complete();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Db fucked up");
            }

        }
    }

    public class Proxy : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
