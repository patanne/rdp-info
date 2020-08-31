using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cassia;
using ConsoleTables;
using hb.app.rdpinfo.lib;

namespace hb.app.rdpinfo
{
	class Program
	{
		static void Main(string[] args)
		{
			var table = new ConsoleTable("id","user","state","ip","computer","idle","disconnected");
			List<ITerminalServicesSession> session_list;

			bool disconnected_ip = false;
			session_list = hb.app.rdpinfo.lib.Info.GetList();
			foreach (var session in session_list)
			{
				string state		= session.ConnectionState.ToString().ToLower();
				string idle			= (state == "active" && session.WindowStationName.ToLower() != "console") ? String.Format("{0,6:###,0}",session.IdleTime.TotalMinutes) : String.Empty;
				string disconnected	= (state == "disconnected") ? session.DisconnectTime.ToString() : string.Empty;
				string ip			= LogonEventLog.GetIP(session.SessionId);
				if (state == "disconnected")
				{
					ip = "*" + ip;
					disconnected_ip = true;
				}
				else
				{
					ip = " " + ip;
				}
				
				table.AddRow(String.Format("{0,2}",session.SessionId), session.UserName, state, ip, session.ClientName, idle, disconnected);
			}
			
			Console.WriteLine();
			table.Write(Format.Minimal);

			if (disconnected_ip)
			{
				Console.WriteLine();
				Console.WriteLine("NOTE: An IP marked with an asterisk (*) is the one used before disconnection.");
			}
		}
	}
}