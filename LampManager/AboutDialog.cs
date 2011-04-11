using System;
namespace LampManager
{
	public partial class AboutDialog : Gtk.Dialog
	{
		protected virtual void OnButtonOkActivated (object sender, System.EventArgs e) {
			//this.HideOnDelete();
			this.Dispose();
		}
		
		
		public AboutDialog ()
		{
			this.Build ();
		}
	}
}

