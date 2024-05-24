using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UserListAPI.Domain;


namespace UserListAPI.Data
{
    public class UsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Users> GetUsers()
        {
            var users = new List<Users>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT UserId, UserName, UserEmail FROM Users", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new Users
                            {
                                UserId = reader.GetInt32(0),
                                UserName = reader.GetString(1),
                                UserEmail = reader.GetString(2)
                            });
                        }
                    }
                }
            }

            return users;
        }
    }
}