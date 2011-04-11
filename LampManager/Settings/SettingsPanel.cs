using System;

namespace LampManager {
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SettingsPanel : Gtk.Bin {
		
		GConf.Client client;
		
		public static string GCONF_APP_PATH = "/apps/lamp-manager";
		
		public SettingsPanel () {
			this.Build ();
			
			client = new GConf.Client();
			client.AddNotify(GCONF_APP_PATH, new GConf.NotifyEventHandler (GConf_Changed));
			UpdateFromGConf();
			
			// General
			webDirectoryEntry.Changed += on_web_directory_activate;
			// Apache
			apachectlEntry.Changed += on_apachectl_path_activate;
		}
		
		void UpdateFromGConf() {
			try {
				// General
				webDirectoryEntry.Text = (string) client.Get(GCONF_APP_PATH + "/web_directory");
				// Apache
				apachectlEntry.Text = (string) client.Get(GCONF_APP_PATH + "/apachectl_path");
			} catch (GConf.NoSuchKeyException e) {
				Console.WriteLine("Error: A key with that name doesn't exist.");
			} catch (System.InvalidCastException e) {
				Console.WriteLine("Error: Cannot typecast.");
			}
		}
		
		public void GConf_Changed (object sender, GConf.NotifyEventArgs args) {
			UpdateFromGConf();
		}
		
		public void on_web_directory_activate (object o, EventArgs args) {
			client.Set (GCONF_APP_PATH + "/web_directory", webDirectoryEntry.Text);
		}
		
		public void on_apachectl_path_activate (object o, EventArgs args) {
			client.Set (GCONF_APP_PATH + "/apachectl_path", apachectlEntry.Text);
		}
	}
}

