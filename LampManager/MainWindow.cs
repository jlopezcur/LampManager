using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		
		Notebook notebook = new Notebook();
		
		LampManager.ApachePanel apachepanel = new LampManager.ApachePanel();
		notebook.AppendPage(apachepanel, new Label("Apache"));
		
		LampManager.PHPPanel phppanel = new LampManager.PHPPanel();
		notebook.AppendPage(phppanel, new Label("PHP"));
		
		LampManager.SettingsPanel settingsPanel = new LampManager.SettingsPanel();
		notebook.AppendPage(settingsPanel, new Label("Settings"));
		
		hbox1.Add(notebook);
		notebook.Show();
		apachepanel.Show();
		phppanel.Show();
		settingsPanel.Show();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected virtual void OnAboutActionActivated (object sender, System.EventArgs e) {
		LampManager.AboutDialog aboutDialog = new LampManager.AboutDialog();
		aboutDialog.Run ();
		aboutDialog.Destroy ();
	}
	
	
}

