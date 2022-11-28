using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class DAL
    {
        public Response GetAllAccounts(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM accounts", connection);
            DataTable dt = new DataTable();
            List<PlayerAccounts> PlayerAccountsList = new List<PlayerAccounts>();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                
            }

            return response;

        }
    }
}
