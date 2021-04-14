using System;

namespace LibraryDemo
{
	public interface ILogging
	{
		void WriteError(Exception ex);

		void WriteInfo(string message);
	}
}