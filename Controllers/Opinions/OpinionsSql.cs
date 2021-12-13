using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteBackEnd.Controllers.Opinions
{
    public static class OpinionsSql
    {
        public static SiteBackEnd.Models.Home.HomeBoard[] GetBoard(int i) {
            var conn = Controllers.SQL.CreateConnection();
            var command = new NpgsqlCommand("SELECT \"Name\", \"comment\", \"photoPath\",\"Path\" FROM schema.opinions ORDER BY \"dateAdded\" DESC LIMIT 5 OFFSET " + i*5, conn);
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

        public static int GetCount()
        {
            var conn = Controllers.SQL.CreateConnection();
            var command = new NpgsqlCommand("SELECT COUNT(\"ID\") FROM schema.opinions", conn);

            try
            {
                conn.Open();
            }
            catch
            {
                throw new Controllers.Exceptions.SQL();
            }

            var reader = command.ExecuteReader();

            reader.Read();
            int i = reader.GetInt32(0);

            reader.CloseAsync();
            reader.DisposeAsync();

            command.DisposeAsync();

            conn.CloseAsync();

            return i;
        }
        public static Models.Home.QueryModel.PathModel GetPath(string str)
        {
            var conn = Controllers.SQL.CreateConnection();
            var command = new NpgsqlCommand("SELECT \"RealName\", \"Path\" FROM schema.\"Opinions\" WHERE \"RealName\" = \'" + str + "\'", conn);
            try
            {
                conn.Open();
            }
            catch
            {
                throw new Controllers.Exceptions.SQL();
            }
            var reader = command.ExecuteReader();

            Models.Home.QueryModel.PathModel path = new Models.Home.QueryModel.PathModel();

            if (!reader.Read())
                throw new Exceptions.NotFound();

            path.RealName = reader.GetString(0);
            path.Path = reader.GetString(1);


            reader.Close();
            reader.DisposeAsync();

            conn.Close();
            command.Dispose();

            return path;
        }

    }
}
