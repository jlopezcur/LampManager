using System;
using Gtk;

namespace LampManager
{
	class MainClass
	{
		
		public static String app_name = "LampManager";
		public static String app_ver = "0.1.4a";
		private static StatusIcon trayIcon;
		private static MainWindow window;
		
		public static void Main (string[] args)
		{
			Application.Init ();
			window = new MainWindow ();
			window.Title = app_name + " " + app_ver;
			
			//trayIcon = new StatusIcon (new Gdk.Pixbuf ("tray.png"));
			trayIcon = new StatusIcon (global::Gdk.Pixbuf.LoadFromResource("LampManager.tray.png"));
			trayIcon.Visible = true;
			trayIcon.Tooltip = app_name + " " + app_ver;
			trayIcon.Activate += OnTrayIconClicked;
			trayIcon.PopupMenu += OnTrayIconPopup;
			
			window.Visible = true;
			
			Application.Run ();
		}

		static void OnTrayIconPopup (object o, EventArgs args) {
			Menu popupMenu = new Menu ();
			
			// Localhost
			ImageMenuItem menuItemLocalhost = new ImageMenuItem("Localhost");
			Gtk.Image imgLocalhost = new Gtk.Image(Stock.Home, IconSize.Menu);
			menuItemLocalhost.Image = imgLocalhost;
			popupMenu.Add(menuItemLocalhost);
			menuItemLocalhost.Activated += OnLocalhostClick;
			
			// Localhost
			ImageMenuItem menuItemPhpmyadmin = new ImageMenuItem("PHPMyAdmin");
			Gtk.Image imgPhpmyadmin = new Gtk.Image(Stock.Connect, IconSize.Menu);
			menuItemPhpmyadmin.Image = imgPhpmyadmin;
			popupMenu.Add(menuItemPhpmyadmin);
			menuItemPhpmyadmin.Activated += OnOpenPhpmyadminClick;
			
			// -----------------
			popupMenu.Add(new SeparatorMenuItem());
			
			// Open Web Directory
			ImageMenuItem menuItemOpenDir = new ImageMenuItem("Open Web Directory");
			Gtk.Image imgOpenDir = new Gtk.Image(Stock.Open, IconSize.Menu);
			menuItemOpenDir.Image = imgOpenDir;
			popupMenu.Add(menuItemOpenDir);
			menuItemOpenDir.Activated += OnOpenDirClick;
			
			// -----------------
			popupMenu.Add(new SeparatorMenuItem());
			
			// Quit
			ImageMenuItem menuItemQuit = new ImageMenuItem("Quit");
			Gtk.Image appimg = new Gtk.Image(Stock.Quit, IconSize.Menu);
			menuItemQuit.Image = appimg;
			popupMenu.Add(menuItemQuit);
			menuItemQuit.Activated += OnPopupClick;
			
			popupMenu.ShowAll();
			popupMenu.Popup();
		}
		
		static void OnLocalhostClick (object o, EventArgs a) {
			GConf.Client client = new GConf.Client();
			string args = "http://localhost/";
			string command = (string) client.Get(LampManager.SettingsPanel.GCONF_APP_PATH + "/browser");
			if (command == "") {
				command = args;
				args = "";
			}
			PHPCommands.executeCommand(command, args);
		}
		
		static void OnOpenPhpmyadminClick (object o, EventArgs a) {
			GConf.Client client = new GConf.Client();
			string args = (string) client.Get(LampManager.SettingsPanel.GCONF_APP_PATH + "/phpmyadmin_url");
			if (args == "") args = "http://localhost/phpmyadmin/";
			string command = (string) client.Get(LampManager.SettingsPanel.GCONF_APP_PATH + "/browser");
			if (command == "") {
				command = args;
				args = "";
			}
			
			PHPCommands.executeCommand(command, args);
		}
		
		static void OnOpenDirClick (object o, EventArgs a) {
			GConf.Client client = new GConf.Client();
			string command = "nautilus";
			string args = (string) client.Get(LampManager.SettingsPanel.GCONF_APP_PATH + "/web_directory");
			if (args == "") args = "/var/www/";
			PHPCommands.executeCommand(command, args);
		}

		static void OnPopupClick (object o, EventArgs args) {
			Application.Quit ();
		}

		static void OnTrayIconClicked (object sender, EventArgs a) {
			if (window.Visible) window.Visible = false; else window.Visible = true;
		}
	}
}

