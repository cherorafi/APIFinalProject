using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public PlayerAccounts PlayerAccounts { get; set; }

        public List<PlayerAccounts> PlayerAccountsList { get; set; }

    }
}
