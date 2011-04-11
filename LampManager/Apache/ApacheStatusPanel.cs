using System;
using System.Diagnostics;

namespace LampManager {
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ApacheStatusPanel : Gtk.Bin {
		
		public ApacheStatusPanel () {
			this.Build ();
			refresh();
		}
		
		private void OnRefresh(object o, EventArgs args) {
			refresh();
		}
		
		private void refresh() {
			Process proc = ApacheCommands.FullStatus();
			string output = proc.StandardOutput.ReadToEnd();
 			proc.WaitForExit();
			textview1.Buffer.Text = output;
		}
	}
}

