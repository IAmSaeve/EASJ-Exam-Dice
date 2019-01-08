using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webservice.Model;

namespace webservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KastController : ControllerBase
    {
        // MSSQL connection string.
        private const string connection = "Server=tcp:easjexam.database.windows.net,1433; Initial Catalog=examdb;" +
        "Persist Security Info=False; User ID=sebastian; Password=P@ssw0rd;" +
        "MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;";

        // GET: api/Kast
        [HttpGet]
        public ActionResult<IEnumerable<Kast>> Get()
        {
            var result = new List<Kast>();
            var sql = "SELECT * FROM Kast";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Kast(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
                }
                db.Dispose();
                return Ok(result);
            }
            return NotFound();
        }

        // GET: api/Kast/1
        [HttpGet("{id}")]
        public ActionResult<Kast> Get(int id)
        {
            Kast result = null;
            var sql = $"SELECT * FROM Kast WHERE id = '{id}'";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Kast(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4));
                }
                db.Dispose();
                return Ok(result);
            }
            return NotFound();
        }

        // GET: api/Kast/Navn/Value
        [HttpGet("Navn/{navn}")]
        public ActionResult<IEnumerable<Kast>> Get(string navn)
        {
            var result = new List<Kast>();
            var sql = $"SELECT * FROM Kast WHERE Navn = '{navn}'";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Kast(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
                }
                db.Dispose();
                return Ok(result);
            }
            return NotFound();
        }

        // POST api/Kast
        [HttpPost]
        public int InsertObject(Kast kast)
        {
            var sql = "INSERT INTO dbo.Kast (Navn, Antal, Guess, [Result])" +
            $"VALUES ('{kast.Navn}', '{kast.Antal}', '{kast.Guess}', '{kast.Result}')";
            var db = new SqlConnection(connection);
            db.Open();

            var command = new SqlCommand(sql, db);
            var reader = command.ExecuteReader();

            db.Dispose();
            return reader.RecordsAffected;
        }
    }
}
