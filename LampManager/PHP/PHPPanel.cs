using System;
using System.Diagnostics;

namespace LampManager {
	[System.ComponentModel.ToolboxItem(true)]
	public partial class PHPPanel : Gtk.Bin {
		
		public PHPPanel () {
			this.Build ();
			
			versionLabel.Text = PHPCommands.getVersion();
			readPHPInfo();
		}
		
		public void readPHPInfo() {
			infoTextView.Buffer.Text = PHPCommands.getInfo();
		}
		
		public void OnEditPHPIni(object o, EventArgs a) {
			string path = PHPCommands.getPHPIniPath();
			if (path != "") {
				string command = "gksudo";
				string args = "gedit " + path;
				PHPCommands.executeCommand(command, args);
			}
		}
	}
}

