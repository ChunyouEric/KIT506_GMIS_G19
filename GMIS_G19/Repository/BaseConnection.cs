using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMIS_G19.Common;
using MySql.Data.MySqlClient;

namespace GMIS_G19.Repository
{
    public class BaseConnection: IConnection
    {
	    public string Server { get; set; }
	    public string Database { get; set; }
	    public string Username { get; set; }
	    public string Password { get; set; }
	    public MySqlConnection Connection { get; set; }

	    public BaseConnection()
	    {
		    Server = Constants.Database.Server;
		    Database = Constants.Database.DatabaseName;
		    Username = Constants.Database.Username;
		    Password = Constants.Database.Password;
	    }

	    public void Open()
	    {
		    if (Connection == null || Connection.State == ConnectionState.Closed)
		    {
			    string connstring = $"Server={Server}; database={Database}; UID={Username}; password={Password}";
			    Connection = new MySqlConnection(connstring);
			    Connection.Open();
			}
	    }

	    public void Close()
	    {
			Connection.Close();
	    }
    }
}
