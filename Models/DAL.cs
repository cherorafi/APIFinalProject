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
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PlayerAccounts playerAccount = new PlayerAccounts();
                    playerAccount.username = Convert.ToString(dt.Rows[i]["username"]);
                    playerAccount.number_of_characters = Convert.ToInt32(dt.Rows[i]["number_of_characters"]);
                    playerAccount.violations = Convert.ToBoolean(dt.Rows[i]["violations"]);
                    PlayerAccountsList.Add(playerAccount);
                }

            }
            if(PlayerAccountsList.Count>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.PlayerAccountsList = PlayerAccountsList;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.PlayerAccountsList = null;
            }

            return response;

        }
    }
}
