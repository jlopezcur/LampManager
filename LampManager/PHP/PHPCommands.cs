using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LampManager {
	
	public static class PHPCommands {
		
		/* > General
		 * ************************************************************* */
		
		public static string getVersion() {
			string command = "php";
			string args = "-r \"phpinfo();\"";
			Process proc = executeCommand(command, args);
			string output = proc.StandardOutput.ReadToEnd();
 			proc.WaitForExit();
			
			var regex = new Regex(@"PHP Version => (.*)");
			var match = regex.Match(output);
			
			if (match.Success) {
				return match.Groups[1].Value;
			} else {
				return "Unknown";
			}
		}
		
		public static string getPHPIniPath() {
			string command = "php";
			string args = "-r \"phpinfo();\"";
			Process proc = executeCommand(command, args);
			string output = proc.StandardOutput.ReadToEnd();
 			proc.WaitForExit();
			
			var regex = new Regex(@"Loaded Configuration File => (.*)");
			var match = regex.Match(output);
			
			if (match.Success) {
				return match.Groups[1].Value;
			} else {
				return "";
			}
		}
		
		public static string getInfo() {
			string command = "php";
			string args = "-r \"phpinfo();\"";
			Process proc = executeCommand(command, args);
			string output = proc.StandardOutput.ReadToEnd();
 			proc.WaitForExit();
			return output;
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

