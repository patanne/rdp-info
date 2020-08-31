**PURPOSE**
For years I have struggled with inaccurate information about terminal sessions in Windows. Specifically 'client ip' info has been inaccurate. Microsoft fixed it somewhat, however if a user logs in, gets disconnected, then logs back in to the disconnected session from another ip, that change is not picked up using default tools available. This tool correlates the session id to the event log to retrieve accurate data.

This tool uses the following NuGet packages:
- Cassia
- ConsoleTables
- System.Diagnostics.EventLog
