
// This file has been generated by the GUI designer. Do not modify.
namespace LampManager
{
	public partial class SettingsPanel
	{
		private global::Gtk.Notebook notebook1;

		private global::Gtk.Table table2;

		private global::Gtk.FileChooserButton filechooserbutton2;

		private global::Gtk.Label label13;

		private global::Gtk.Label label14;

		private global::Gtk.Entry webDirectoryEntry;

		private global::Gtk.Label label6;

		private global::Gtk.Table table3;

		private global::Gtk.Entry apachectlEntry;

		private global::Gtk.Label label8;

		private global::Gtk.Label label7;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LampManager.SettingsPanel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "LampManager.SettingsPanel";
			// Container child LampManager.SettingsPanel.Gtk.Container+ContainerChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 0;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.table2 = new global::Gtk.Table (((uint)(7)), ((uint)(3)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.filechooserbutton2 = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("Seleccione un archivo"), ((global::Gtk.FileChooserAction)(0)));
			this.filechooserbutton2.Name = "filechooserbutton2";
			this.filechooserbutton2.ShowHidden = true;
			this.table2.Add (this.filechooserbutton2);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table2[this.filechooserbutton2]));
			w1.TopAttach = ((uint)(1));
			w1.BottomAttach = ((uint)(2));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label13 = new global::Gtk.Label ();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString ("Web Directory:");
			this.table2.Add (this.label13);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table2[this.label13]));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label14 = new global::Gtk.Label ();
			this.label14.Name = "label14";
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString ("Browser:");
			this.table2.Add (this.label14);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table2[this.label14]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.webDirectoryEntry = new global::Gtk.Entry ();
			this.webDirectoryEntry.CanFocus = true;
			this.webDirectoryEntry.Name = "webDirectoryEntry";
			this.webDirectoryEntry.Text = global::Mono.Unix.Catalog.GetString ("/var/www/");
			this.webDirectoryEntry.IsEditable = true;
			this.webDirectoryEntry.InvisibleChar = '•';
			this.table2.Add (this.webDirectoryEntry);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table2[this.webDirectoryEntry]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			this.notebook1.Add (this.table2);
			// Notebook tab
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("General");
			this.notebook1.SetTabLabel (this.table2, this.label6);
			this.label6.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.table3 = new global::Gtk.Table (((uint)(9)), ((uint)(2)), false);
			this.table3.Name = "table3";
			this.table3.RowSpacing = ((uint)(6));
			this.table3.ColumnSpacing = ((uint)(6));
			// Container child table3.Gtk.Table+TableChild
			this.apachectlEntry = new global::Gtk.Entry ();
			this.apachectlEntry.CanFocus = true;
			this.apachectlEntry.Name = "apachectlEntry";
			this.apachectlEntry.Text = global::Mono.Unix.Catalog.GetString ("/usr/sbin/apachectl");
			this.apachectlEntry.IsEditable = true;
			this.apachectlEntry.InvisibleChar = '•';
			this.table3.Add (this.apachectlEntry);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table3[this.apachectlEntry]));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("apachectl");
			this.table3.Add (this.label8);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table3[this.label8]));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			this.notebook1.Add (this.table3);
			global::Gtk.Notebook.NotebookChild w8 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.table3]));
			w8.Position = 1;
			// Notebook tab
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Paths");
			this.notebook1.SetTabLabel (this.table3, this.label7);
			this.label7.ShowAll ();
			this.Add (this.notebook1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}