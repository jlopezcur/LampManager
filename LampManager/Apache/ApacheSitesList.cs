using System;
using System.Collections;
using System.Diagnostics;
using JLWidgets;
using Gtk;

namespace LampManager {
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ApacheSitesList : Gtk.Bin {
		
		private IconLabel iconLabelStatusButton;
		private TreeStore model;
		
		public ApacheSitesList () {
			this.Build ();
			
			/*model = new TreeStore(typeof (string), typeof (string), typeof (string));
			treeView.Model = model;
			treeView.HeadersVisible = true;
			
			treeView.AppendColumn("Sites", new CellRendererText (), "text", 0);
			treeView.AppendColumn("Status", new CellRendererText (), "text", 1);
			treeView.AppendColumn("Config File", new CellRendererText (), "text", 2);*/
			
			// TreeView
			
			model = new TreeStore(typeof (ApacheSite));
			treeView.Model = model;
			treeView.HeadersVisible = true;
			
			// Name Column
			TreeViewColumn nameColumn = new TreeViewColumn ();
			nameColumn.Title = "Sites";
			CellRendererText nameCell = new CellRendererText();
			nameColumn.PackStart (nameCell, true);
			// Status Column
			TreeViewColumn statusColumn = new TreeViewColumn ();
			statusColumn.Title = "Status";
			CellRendererText statusCell = new CellRendererText();
			statusColumn.PackStart (statusCell, true);
			// Config Column
			TreeViewColumn configColumn = new TreeViewColumn ();
			configColumn.Title = "Config File";
			CellRendererText configCell = new CellRendererText();
			configColumn.PackStart (configCell, true);
			
			treeView.AppendColumn (nameColumn);
			treeView.AppendColumn (statusColumn);
			treeView.AppendColumn (configColumn);
			
			nameColumn.SetCellDataFunc (nameCell, new TreeCellDataFunc (RenderName));
			statusColumn.SetCellDataFunc (statusCell, new TreeCellDataFunc (RenderStatus));
			configColumn.SetCellDataFunc (configCell, new TreeCellDataFunc (RenderConfig));
			
			treeView.Selection.Changed += OnSelectionChanged;
			
			// Buttons
			
			iconLabelStatusButton = new JLWidgets.IconLabel();
			iconLabelStatusButton.SetImageFromIcon("gtk-ok");
			iconLabelStatusButton.SetText("Activate");
			
			statusButton.Remove(statusButton.Child);
			statusButton.Add(iconLabelStatusButton);
			
			statusButton.Sensitive = false;
			editButton.Sensitive = false;
		}
		
		private void RenderName(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter) {
			ApacheSite site = (ApacheSite) model.GetValue (iter, 0);
			(cell as CellRendererText).Text = site.name;
		}
		
		private void RenderStatus(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter) {
			ApacheSite site = (ApacheSite) model.GetValue (iter, 0);
			if (site.active) {
				(cell as Gtk.CellRendererText).Foreground = "darkgreen";
				(cell as CellRendererText).Text = "Active";
			} else {
				(cell as Gtk.CellRendererText).Foreground = "red";
				(cell as CellRendererText).Text = "Inactive";
			}
		}
		
		private void RenderConfig(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter) {
			ApacheSite site = (ApacheSite) model.GetValue (iter, 0);
			(cell as CellRendererText).Text = site.getConfigFullPath();
		}
		
		public void setCollection(ArrayList list) {
			model.Clear();
			foreach (ApacheSite item in list) {
				model.AppendValues(item);
			}
		}
		
		private void OnSelectionChanged (object o, EventArgs args) {
            TreeIter iter; TreeModel model;
            if (((TreeSelection)o).GetSelected(out model, out iter)) {
				ApacheSite site = (ApacheSite) model.GetValue(iter, 0);
				statusButton.Sensitive = true;
				changeStatusButton(site.active);
				editButton.Sensitive = site.hasConfigFile();
            }
        }
		
		private void OnStatusButtonToggled(object o, EventArgs args) {
			TreeIter iter; TreeModel model;
            if (treeView.Selection.GetSelected(out model, out iter)) {
				ApacheSite site = (ApacheSite) model.GetValue(iter, 0);
				site.changeStatus();
			}
			treeView.ShowAll();
		}
		
		private void changeStatusButton(bool status) {
			if (statusButton.Active) {
				iconLabelStatusButton.SetText("Deactivate");
				iconLabelStatusButton.SetImageFromIcon("gtk-cancel");
			} else {
				iconLabelStatusButton.SetText("Activate");
				iconLabelStatusButton.SetImageFromIcon("gtk-ok");
			}
		}
		
		private void OnEditButtonClicked(object o, EventArgs args) {
			TreeIter iter; TreeModel model;
			if (treeView.Selection.GetSelected(out model, out iter)) {
				ApacheSite site = (ApacheSite) model.GetValue(iter, 0);
				site.edit();
			}
		}
	}
}