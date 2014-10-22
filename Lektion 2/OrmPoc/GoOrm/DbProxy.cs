using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoOrm
{
    public class DbProxy
    {
        private SqlConnection _connection;
        public DbProxy(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IEnumerable<T> GetAll<T>()
        {
            var type = typeof (T);

            var command = _connection.CreateCommand();
            command.CommandText = "select * from " + type.Name;
            _connection.Open();
            var dataReader = command.ExecuteReader();
            var list = new List<T>();
            while (dataReader.Read())
            {
                var instance = (T)Activator.CreateInstance(type);
                foreach (var propertyInfo in type.GetProperties())
                {
                    propertyInfo.SetValue(instance, dataReader[propertyInfo.Name]);
                }
                list.Add(instance);
            }
            _connection.Close();
            return list;
        }
    }
}
