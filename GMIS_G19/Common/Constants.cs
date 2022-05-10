using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMIS_G19.Common
{
    public class Constants
    {
	    public class Database
	    {
		    public static string Server = "alacritas.cis.utas.edu.au";
		    public static string DatabaseName = "gmis";
		    public static string Username = "gmis";
		    public static string Password = "gmis";
	    }

	    public class Log
		{
			public static int LogLevel = 6;
			public static string LogFileName = "log.txt";
		}
    }
}
