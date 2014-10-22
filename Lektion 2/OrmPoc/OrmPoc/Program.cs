using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrm;

namespace OrmPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
            
            var proxy = new DbProxy(connectionString);
            
            var result = proxy.GetAll<Person>();

            foreach (var person in result)
            {
                Console.WriteLine(person);
            }
        }
    }
}
