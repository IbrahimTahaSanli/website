using MongoDB.Driver;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Controllers
{
    public static class SQL
    {

        private static string Host = "localhost";
        private static string User = "******************";
        private static string DBName = "******************";
        private static string Password = "******************";
        private static string Port = "5432";

        public static NpgsqlConnection CreateConnection()
        {
            string connString =
                String.Format(
                    "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBName,
                    Port,
                    Password);

            return new NpgsqlConnection(connString);
        }

        public static Models.Home.HomeBoard[] getOpiDatas() {
            var conn = CreateConnection();
            var command = new NpgsqlCommand("SELECT \"Name\", \"comment\", \"photoPath\",\"RealName\" FROM schema.opinions ORDER BY \"dateAdded\" DESC LIMIT 3", conn);
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Controllers.Exceptions.SQL();
            }
            var reader = command.ExecuteReader();
            List<Models.Home.HomeBoard> list = new List<Models.Home.HomeBoard>();
            Models.Home.HomeBoard tmp;
            while (reader.Read())
            {
                tmp = new Models.Home.HomeBoard();

                tmp.Name = reader.IsDBNull(0)? null: reader.GetString(0);
                tmp.Description = reader.IsDBNull(1) ? null : reader.GetString(1);
                tmp.PhotoPath = reader.IsDBNull(2) ? null : reader.GetString(2);
                tmp.Path = reader.IsDBNull(3) ? null : reader.GetString(3);

                list.Add(tmp);
            }

            reader.Close();
            reader.DisposeAsync();

            conn.Close();
            command.Dispose();

            return list.ToArray();
        }

        public static Models.Home.HomeBoard[] getArtDatas()
        {
            var conn = CreateConnection();
            var command = new NpgsqlCommand("SELECT \"Name\", \"Description\", \"photoPath\",\"RealName\" FROM schema.\"Articles\" ORDER BY \"dateAdded\" DESC LIMIT 3", conn);
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Controllers.Exceptions.SQL();
            }
            var reader = command.ExecuteReader();
            List<Models.Home.HomeBoard> list = new List<Models.Home.HomeBoard>();
            Models.Home.HomeBoard tmp;
            while (reader.Read())
            {
                tmp = new Models.Home.HomeBoard();

                tmp.Name = reader.GetString(0);
                tmp.Description = reader.GetString(1);
                tmp.PhotoPath = reader.GetString(2);
                tmp.Path = reader.GetString(3);

                list.Add(tmp);
            }

            reader.Close();
            reader.DisposeAsync();

            conn.Close();
            command.Dispose();

            return list.ToArray();
        }
    }
}
