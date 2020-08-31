**PURPOSE**

For years I have struggled with inaccurate information about terminal sessions in Windows. Specifically 'client ip' info has been inaccurate. Read online posts. I was not alone. Microsoft fixed it somewhat, however if a user logs in, gets disconnected, then logs back in to the disconnected session from another ip, that change is not picked up using default tools available. This tool correlates the session id to the event log to retrieve accurate data.

**INCOMPLETE**

This is the first project in C# in many years. To that end this project is an incomplete work. There are no unit tests. Additionally, it is broken into a standalone library and a console app. I intend to create a GUI app as well. No telling when that will happen.

This tool uses the following NuGet packages:
- Cassia
- ConsoleTables
- System.Diagnostics.EventLog
