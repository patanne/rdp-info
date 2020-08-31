using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security;

namespace hb.app.rdpinfo.lib
{
	public class LogonEventLog
	{
		public static string GetIP(int session_id)
		{
			var query_str = $"*[System[(EventID=21 or EventID=25)]] and *[UserData[EventXML[@xmlns='Event_NS'][(SessionID='{session_id}')]]]";
			var query_log = new EventLogQuery("Microsoft-Windows-TerminalServices-LocalSessionManager/Operational", PathType.LogName,query_str);
			query_log.ReverseDirection = true;
			
			var reader = new System.Diagnostics.Eventing.Reader.EventLogReader(query_log);
			EventRecord eventInstance = reader.ReadEvent();
			if (eventInstance.Properties.Count > 2)
				return (string) eventInstance.Properties[2].Value;
			return string.Empty;
		}
		
	}
}