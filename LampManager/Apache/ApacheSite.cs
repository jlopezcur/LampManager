using System;
using System.Collections;
using System.Diagnostics;

namespace LampManager {
	
	public class ApacheSite	{
		
		public string name;
		public bool active;
		public System.IO.FileInfo configFile;
		
		public ApacheSite (string name, bool active, System.IO.FileInfo configFile) {
			this.name = name;
			this.active = active;
			this.configFile = configFile;
		}
		
		public string getConfigFullPath() {
			if (hasConfigFile()) return configFile.FullName;
			return "";
		}
		
		public bool hasConfigFile() {
			if (configFile != null) return true;
			return false;
		}
		
		public void edit() {
			if (hasConfigFile()) {
				Process proc = new Process();
				proc.StartInfo.FileName = "gedit";
				proc.StartInfo.Arguments = configFile.FullName;
				proc.Start();
			}
		}
		
		public void changeStatus() {
			Process proc = new Process();
			if (active)
				proc.StartInfo.FileName = "a2dissite";
			else
				proc.StartInfo.FileName = "a2ensite";
			proc.StartInfo.Arguments = name;
			proc.WaitForExit();
			proc.Start();
			
			proc = new Process();
			proc.StartInfo.FileName = "/etc/init.d/apache2";
			proc.StartInfo.Arguments = "reload";
			proc.WaitForExit();
			proc.Start();
			
			active = !active;
		}
		
		/**
		 * Read all the sites
		 * /etc/apache2/mods-available/
		 * /etc/apache2/mods-enabled/
		 **/
		public static ArrayList ReadSites() {
			ArrayList list = new ArrayList();
			
			string[] sites_available = System.IO.Directory.GetFiles("/etc/apache2/sites-available/");
			string[] sites_enabled = System.IO.Directory.GetFiles("/etc/apache2/sites-enabled/");
			
			for (int i = 0; i < sites_available.Length; i++) {
				string tmpName = Utils.FileName(sites_available[i]);
				
				bool tmpActive = false;
				for (int j = 0; j < sites_enabled.Length; j++)
					if (tmpName == Utils.FileName(sites_enabled[j]).Substring(4))
						tmpActive = true;
				
				System.IO.FileInfo tmpConfigFile = new System.IO.FileInfo(sites_available[i]);
				
				ApacheSite apacheSite = new ApacheSite(tmpName, tmpActive, tmpConfigFile);
				list.Add(apacheSite);
			}
			
			return list;
		}
	}
}