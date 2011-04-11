using System;
using System.Collections;
using System.Diagnostics;

namespace LampManager {
	
	public class ApacheMod {
		
		public string name;
		public bool active;
		public System.IO.FileInfo configFile;
		
		public ApacheMod(string name, bool active, System.IO.FileInfo configFile)	{
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
				proc.StartInfo.FileName = "gksudo";
				proc.StartInfo.Arguments = "gedit " + configFile.FullName;
				proc.Start();
			}
		}
		
		public void changeStatus() {
			if (active)
				ApacheCommands.DeactivateModuleAndReload(name);
			else
				ApacheCommands.ActivateModuleAndReload(name);
			
			/*Process proc = new Process();
			if (active)
				proc = ApacheCommands.DeactivateModule(name);
			else
				proc = ApacheCommands.ActivateModule(name);
			
			proc.Exited += delegate(object sender, EventArgs e) {
				ApacheCommands.Reload();
			};*/
			active = !active;
		}
		
		/**
		 * Read all the mods
		 * /etc/apache2/mods-available/
		 * /etc/apache2/mods-enabled/
		 **/
		public static ArrayList ReadMods() {
			ArrayList list = new ArrayList();
			
			string[] mods_available = System.IO.Directory.GetFiles("/etc/apache2/mods-available/", "*.load");
			string[] mods_config = System.IO.Directory.GetFiles("/etc/apache2/mods-available/", "*.conf");
			string[] mods_enabled = System.IO.Directory.GetFiles("/etc/apache2/mods-enabled/", "*.load");
			
			for (int i = 0; i < mods_available.Length; i++) {
				string tmpName = Utils.FileNameWithoutExt(mods_available[i]);
				
				bool tmpActive = false;
				for (int j = 0; j < mods_enabled.Length; j++)
					if (Utils.FileName(mods_available[i]) == Utils.FileName(mods_enabled[j]))
						tmpActive = true;
				
				System.IO.FileInfo tmpConfigFile = null;
				for (int k = 0; k < mods_config.Length; k++)
					if (Utils.FileNameWithoutExt(mods_available[i]) == Utils.FileNameWithoutExt(mods_config[k]))
						tmpConfigFile = new System.IO.FileInfo(mods_config[k]);
				
				ApacheMod apacheMod = new ApacheMod(tmpName, tmpActive, tmpConfigFile);
				list.Add(apacheMod);
			}
			
			return list;
		}
	}
}

