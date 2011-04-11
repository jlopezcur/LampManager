using System;

namespace LampManager {

	[System.ComponentModel.ToolboxItem(true)]
	public partial class ApachePanel : Gtk.Bin {
		
		public ApachePanel () {
			this.Build ();
			
			versionLabel.Text = ApacheCommands.getVersion();
			if (ApacheCommands.isRunning()) {
				statusLabel1.Text = "On";
				//(cell as Gtk.CellRendererText).Foreground = "darkgreen";
			} else {
				statusLabel1.Text = "Off";
			}
			
			initMods();
			initSites();
		}
		
		private void initMods() {
			apacheModsList.setCollection(ApacheMod.ReadMods());
		}
		
		private void initSites() {
			apacheSitesList.setCollection(ApacheSite.ReadSites());
		}
	}
}