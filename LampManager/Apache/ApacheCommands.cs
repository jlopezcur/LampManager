using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LampManager {
	
	public static class ApacheCommands {
		
		/* > General
		 * ************************************************************* */
		
		public static string getVersion() {
			Process proc = ApacheCommands.Status();
			string output = proc.StandardOutput.ReadToEnd();
 			proc.WaitForExit();
			
			var regex = new Regex(@"Server Version: (.*)");
			var match = regex.Match(output);
			
			if (match.Success) {
				return match.Groups[1].Value;
			} else {
				return "Unknown";
			}
		}
		
		public static bool isRunning() {
			Process[] procs = Process.GetProcesses();
			string pid = "";
			foreach (Process p in procs) {
				p.Refresh();
				string name = p.ProcessName;
				if (name == "/usr/sbin/apache2") pid = p.Id.ToString();
			}
			return (pid != "");
		}
		
		/* > Modules
		 * ************************************************************* */
		
		public static Process ActivateModule(string module) {		
			string command = "gksudo";
			string args = "a2enmod " + module;
			return executeCommand(command, args);
		}
		
		public static void ActivateModuleAndReload(string module) {		
			string command = "gksudo";
			string args = "a2enmod " + module;
			Process proc = executeCommand(command, args);
			proc.Exited += delegate(object sender, EventArgs e) {
				Reload();
			};
		}
		
		public static Process DeactivateModule(string module) {
			string command = "gksudo";
			string args = "a2dismod " + module;
			return executeCommand(command, args);
		}
		
		public static void DeactivateModuleAndReload(string module) {		
			string command = "gksudo";
			string args = "a2dismod " + module;
			Process proc = executeCommand(command, args);
			proc.Exited += delegate(object sender, EventArgs e) {
				Reload();
			};
		}
		
		/* > Actions
		 * ************************************************************* */
		
		public static Process Status() {
			string command = "apachectl";
			string args = "status";
			return executeCommand(command, args);
		}
		
		public static Process FullStatus() {
			string command = "apachectl";
			string args = "fullstatus";
			return executeCommand(command, args);
		}
		
		public static Process Start() {
			string command = "apachectl";
			string args = "start";
			return executeCommand(command, args);
		}
		
		public static Process Stop() {
			string command = "apachectl";
			string args = "stop";
			return executeCommand(command, args);
		}
		
		public static Process Reload() {
			string command = "apachectl";
			string args = "graceful";
			return executeCommand(command, args);
		}
		
		/* > Utils
		 * ************************************************************* */
		
		public static Process executeCommand(string command, string args) {
			Process proc = new Process();
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.FileName = command;
			proc.StartInfo.Arguments = args;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.Start();
			return proc;
		}
	}
}

