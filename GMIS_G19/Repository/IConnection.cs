using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GMIS_G19.Repository
{
    interface IConnection
    {
        string Server { get; set; }
        string Database { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        MySqlConnection Connection { get; set; }
        void Open();
        void Close();
    }
}
