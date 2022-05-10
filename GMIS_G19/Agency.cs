using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; //for generating a MessageBox upon encountering an error


namespace GMIS_G19
{
    abstract class Agency
    {
        //If including error reporting within this class (as this sample does) then you'll need a way
        //to control whether the errors are actually shown or silently ignored, since once you have
        //connected the GUI to the Boss object then the GUI designer will execute its code, which
        //will try to connect to the database to load live data into the GUI at design time.
        private static bool reportingErrors = false;

        //These would not be hard coded in the source file normally, but read from the application's settings (and, ideally, with some amount of basic encryption applied)
        private const string db = "gmis";
        private const string user = "gmis";
        private const string pass = "gmis";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        //Part of step 2.3.3 in Week 8 tutorial. This method is a gift to you because .NET's approach to converting strings to enums is so horribly broken
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        //For step 2.2 in Week 8 tutorial
        public static List<Class> LoadAll()
        {
            List <Class> student = new List<Class>();

            MySqlConnection conn = GetConnection();
        MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("class id, group_id, day, start, end, room from class", conn);
        rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.
                    student.Add(new Class { Class_id = rdr.GetInt32(0), Group_id = rdr.GetInt32(1), Day = rdr.GetDay32(2), Start= rdr.GetInt32(3), Room= rdr.GetInt32(4) });
                }
            }
            catch (MySqlException e)
{
    ReportError("loading student", e);
}
finally
{
    if (rdr != null)
    {
        rdr.Close();
    }
    if (conn != null)
    {
        conn.Close();
    }
}

return student;
        }
    }
}
