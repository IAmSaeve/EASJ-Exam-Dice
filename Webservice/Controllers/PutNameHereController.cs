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
    public class PutNameHereController : ControllerBase
    {
        // MSSQL connection string.
        private const string connection = "Server=tcp:easjexam.database.windows.net,1433; Initial Catalog=examdb;" +
        "Persist Security Info=False; User ID=sebastian; Password=P@ssw0rd;" +
        "MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;";

        // GET: api/TestTable
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var result = new List<object>();
            var sql = "SELECT * FROM TestTable";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new string("ID: " + reader.GetInt32(0).ToString() + " Name: " + reader.GetString(1)));
                }
                db.Dispose();
                return Ok(result);
            }
            return NotFound();
        }

        // GET: api/TestTable/1
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            object result = null;
            var sql = $"SELECT * FROM TestTable WHERE id = '{id}'";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new string("ID: " + reader.GetInt32(0).ToString() + " Name: " + reader.GetString(1));
                }
                db.Dispose();
                return Ok(result);
            }
            return NotFound();
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
