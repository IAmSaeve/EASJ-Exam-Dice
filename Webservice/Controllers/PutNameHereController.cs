using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutNameHere : ControllerBase
    {
        // MSSQL connection string.
        private const string connection = "Server=tcp:easjexam.database.windows.net,1433; Initial Catalog=examdb;" +
        "Persist Security Info=False; User ID=sebastian; Password=P@ssw0rd;" +
        "MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;";

        // GET: api/Meassurement
        [HttpGet]
        public List<object> Get()
        {
            throw new NotImplementedException("Delete this before build");
            var result = new List<object>();
            var sql = "SELECT * FROM Meassurement";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // result.Add(new Meassurement(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                    result.Add(new object());
                }
            }

            db.Dispose();
            return result;
        }

        // GET: api/Meassurements/1
        [HttpGet("{id}")]
        public object Get(int id)
        {
            throw new NotImplementedException("Delete this before build");
            object result = null;
            var sql = $"SELECT * FROM Meassurement WHERE id = '{id}'";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // result = new Meassurement(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    result = new object();
                }
            }

            db.Dispose();
            return result;
        }

        // POST api/Meassurements
        [HttpPost]
        public int InsertObject(object o)
        {
            throw new NotImplementedException("Delete this before build");
            var sql = "INSERT INTO dbo.Meassurement (Pressure, Humidity, Temperature, [TimeStamp])" + "TODO: Fix later";
            // $"VALUES ('{Meassurement.Pressure}', '{Meassurement.Humidity}', '{Meassurement.Temperature}', '{Meassurement.TimeStamp}')";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            db.Dispose();
            return reader.RecordsAffected;
        }

        // PUT api/Meassurements/5
        [HttpPut("{id}")]
        public int UpdateObject(int id, [FromBody] object o)
        {
            throw new NotImplementedException("Delete this before build");
            var sql = $"UPDATE Meassurement SET Pressure = "; // TODO: Fix later '{Meassurement.Pressure}', " +
            // $"Humidity = '{Meassurement.Humidity}', Temperature = '{Meassurement.Temperature}'" +
            // $"TimeStamp = '{Meassurement.TimeStamp}' WHERE id='{id}'";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            db.Dispose();
            return reader.RecordsAffected;
        }

        // DELETE api/Meassurements/5
        [HttpDelete("{id}")]
        public int DeleteObject(int id)
        {
            throw new NotImplementedException("Delete this before build");
            var sql = $"DELETE FROM Meassurement WHERE id='{id}'";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            db.Dispose();
            return reader.RecordsAffected;
        }
    }
}
