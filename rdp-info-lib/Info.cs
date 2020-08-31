using System;
using System.Collections.Generic;
using Cassia;

namespace hb.app.rdpinfo.lib
{
	public class Info
	{
		public static List<ITerminalServicesSession> GetList()
		{
			List<ITerminalServicesSession> session_list = new List<ITerminalServicesSession>();
			
			ITerminalServicesManager manager = new TerminalServicesManager();
			using (ITerminalServer server = manager.GetLocalServer())
			{
				server.Open();
				foreach (ITerminalServicesSession session in server.GetSessions())
				{
					// skip the SYSTEM session
					if (session.SessionId == 0) continue;
					
					// if there is no username the session is special accounts
					if (session.UserName == String.Empty) continue;
					
					session_list.Add(session);
				}
			}

			return session_list;
		}
	}
}