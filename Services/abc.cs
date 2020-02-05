using System;
using Dapper;
using webapi.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;

namespace webapi.Services
{
    public class fruitsservice
    {
        MySqlConnection connection = new MySqlConnection();
        string connectionString = @"server=localhost;uid=root;password=123;database=db1";
        public List<fruits> GetFruits()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();

            //MySqlCommand cmd = new MySqlCommand("SELECT * FROM fruits", connection);
            var details = connection.Query<fruits>("select * from fruits");
            //MySqlDataReader rd = cmd.ExecuteReader();
            connection.Close();

            return details.ToList();
            // rd.Close();

        }

        public void AddFruits(fruits f)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("INSERT INTO fruits (idfruits, name, type, price) VALUES (@idfruits, @name, @type, @price);", connection);
                cmd.Parameters.AddWithValue("@idfruits", f.idfruits);
                cmd.Parameters.AddWithValue("@name", f.name);
                cmd.Parameters.AddWithValue("@type", f.type);
                cmd.Parameters.AddWithValue("@price", f.price);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void UpdateFruits(fruits f)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd2 = new MySqlCommand("UPDATE fruits SET idfruits=@idfruits, name=@name, type=@type, price=@price WHERE idfruits=@idfruits", connection);
                cmd2.Parameters.AddWithValue("@idfruits", f.idfruits);
                cmd2.Parameters.AddWithValue("@name", f.name);
                cmd2.Parameters.AddWithValue("@type", f.type);
                cmd2.Parameters.AddWithValue("@price", f.price);
                cmd2.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void DeleteFruits(fruits f)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd3 = new MySqlCommand("DELETE FROM fruits WHERE idfruits=@idfruits", connection);
                cmd3.Parameters.AddWithValue("@idfruits", f.idfruits);
                cmd3.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

}
