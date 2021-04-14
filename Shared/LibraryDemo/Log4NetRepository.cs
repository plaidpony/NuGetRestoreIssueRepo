using System;
using System.Web;

namespace LibraryDemo
{
	public class Log4NetRepository : ILogging
	{
		private log4net.ILog log;

		public Log4NetRepository()
		{
			log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		}

		private string BuildExceptionMessage(Exception ex)
		{
			string error = "Error in Path:" + HttpContext.Current.Request.Path;
			error += string.Format("{0}Raw Url:{1}", Environment.NewLine, HttpContext.Current.Request.RawUrl);
			error += string.Format("{0}Message:{1}", Environment.NewLine, ex.Message);
			error += string.Format("{0}Source:{1}", Environment.NewLine, ex.Source);
			error += string.Format("{0}Stack Trace:{1}", Environment.NewLine, ex.StackTrace);
			error += string.Format("{0}TargetSite:{1}", Environment.NewLine, ex.TargetSite);
			return error;
		}

		public void WriteError(Exception ex)
		{
			log.Error(BuildExceptionMessage(ex));
		}

		public void WriteInfo(string message)
		{
			log.Info(message);
		}
	}
}