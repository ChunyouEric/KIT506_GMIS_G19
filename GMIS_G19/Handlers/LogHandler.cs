using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using System.Threading;
using GMIS_G19.Common;

namespace GMIS_G19.Handlers
{
	public enum LogLevel
	{
		Error = 1,
		Warning,
		Info,
		Debug,
		Test,
		Verbose
	}

	public class LogHandler
	{
		private static Mutex _Mutex = new Mutex();

		public static void Log(LogLevel logLevel, string message = "", Exception ex = null)
		{
			_Mutex.WaitOne();
			if (File.Exists(Constants.Log.LogFileName) == false)
			{
				File.Create(Constants.Log.LogFileName);
			}

			try
			{
				StackTrace stackTrace = new StackTrace();
				if (logLevel == LogLevel.Error && ex != null)
				{
					using (StreamWriter sw =
						new StreamWriter(File.Open(Constants.Log.LogFileName, FileMode.Append, FileAccess.Write)))
					{
						sw.WriteLine(
							$"[{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt")}] [{logLevel.ToString()}] [{stackTrace.GetFrame(1).GetMethod().Name}] Message: {message}\r\nException: {ex.Message}\r\n StackTrace: {ex.StackTrace}");
					}
				}
				else if ((int) logLevel <= Constants.Log.LogLevel)
				{
					using (StreamWriter sw =
						new StreamWriter(File.Open(Constants.Log.LogFileName, FileMode.Append, FileAccess.Write)))
					{
						if (stackTrace.GetFrame(1).GetMethod().DeclaringType == null)
						{
							sw.WriteLine(
								$"[{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt")}] [{logLevel.ToString()}] [{stackTrace.GetFrame(1).GetMethod().Name}] Message: {message}");
						}
						else
						{
							sw.WriteLine(
								$"[{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt")}] [{logLevel.ToString()}] [{stackTrace.GetFrame(1).GetMethod().DeclaringType.FullName}] Message: {message}");
						}
					}
				}
			}
			catch
			{
			}

			_Mutex.ReleaseMutex();
		}
	}
}