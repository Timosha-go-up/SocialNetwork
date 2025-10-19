using Dapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SocialNetwork.DAL.Repositories
{
    public class BaseRepository
    {
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    Console.WriteLine($"Соединение открыто: {connection.State}");
                    Console.WriteLine($"Выполняется запрос: {sql}");
                    Console.WriteLine($"Параметры: {JsonConvert.SerializeObject(parameters)}");

                    // Без указания commandType
                    return connection.QueryFirstOrDefault<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                throw;
            }
        }





        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = DAL/DB/social_network.db; Version = 3");
        }
    }
}
