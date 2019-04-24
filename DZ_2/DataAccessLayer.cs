using System.Data.Common;
using System.Configuration;
using System;

namespace DZ_2
{
    public class DataAccessLayer
    {
        public readonly string _connectionString;
        public readonly string _providerName;
        public readonly DbProviderFactory _providerFactory;
        
        public DataAccessLayer()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConnectionString"].ConnectionString;
            _providerName = ConfigurationManager.ConnectionStrings["appConnectionString"].ProviderName;
            _providerFactory = DbProviderFactories.GetFactory(_providerName);
        }

        public string CreateGroupsTable()
        {
            string message = "";

            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    
                    command.CommandText = "create table Groups ( Id int primary key identity, Name nvarchar(30) not null unique )";
                    
                    command.ExecuteNonQuery();

                    message += "Таблица была успешно создана!";
                }
                catch (DbException)
                {
                    message += "Такая таблица уже существует";
                }
                catch(Exception)
                {
                    message += "Произошла ошибка!";
                }
            }

            return message;
        }
    }
}
