using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMIS_G19.Handlers;
using GMIS_G19.Models;
using MySql.Data.MySqlClient;

namespace GMIS_G19.Repository
{
	public class Repository : BaseConnection
	{
		public Repository()
		{
		}

		public Student[] GetAllStudents()
		{
			List<Student> students = new List<Student>();
			try
			{
				Open();
				string sql = "select * from student;";
				var cmd = new MySqlCommand(sql, Connection);
				var reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string someStringFromColumnZero = reader.GetString(0);
					string someStringFromColumnOne = reader.GetString(1);
					Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);

					students.Add(new Student()
					{
						Id = reader.GetInt32(0),
						GivenName = reader.GetString(1),
						FamilyName = reader.GetString(2),
						GroupId = reader.GetInt32(3),
						Title = reader.GetString(4),
						Campus = Enum.Parse<Campus>(reader.GetString(5)),
						Phone = reader.GetString(6),
						Email = reader.GetString(7),
						Photo = reader.GetString(8),
						Category = Enum.Parse<Category>(reader.GetString(9))
					});
				}

				Close();
			}
			catch (Exception e)
			{
				LogHandler.Log(LogLevel.Error, "Unable to get students", e);
			}

			return students.ToArray();
		}
		public Class[] GetAllClasses()
		{
			List<Class> classes = new List<Class>();
			try
			{
				Open();
				string sql = "select * from class;";
				var cmd = new MySqlCommand(sql, Connection);
				var reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string someStringFromColumnZero = reader.GetString(0);
					string someStringFromColumnOne = reader.GetString(1);
					Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);

					classes.Add(new Class()
					{
						Id = reader.GetInt32(0),
						GroupId = reader.GetInt32(1),
						Day = Enum.Parse<Day>(reader.GetString(2)),
						Start = DateTime.Parse(reader.GetString(3)),
						End = DateTime.Parse(reader.GetString(4)),
						Room = reader.GetString(5)
					});
				}

				Close();
			}
			catch (Exception e)
			{
				LogHandler.Log(LogLevel.Error, "Unable to get students", e);
			}

			return classes.ToArray();
		}
	}
}