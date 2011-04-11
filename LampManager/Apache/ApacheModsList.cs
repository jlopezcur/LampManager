using System;
using System.Collections;
using System.Diagnostics;
using Gtk;
using JLWidgets;

namespace LampManager {
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ApacheModsList : Gtk.Bin {
		
		private IconLabel iconLabelStatusButton;
		private TreeStore model;
		
		public ApacheModsList () {
			this.Build ();
			
			// TreeView
			
			model = new TreeStore(typeof (ApacheMod));
			treeView.Model = model;
			treeView.HeadersVisible = true;
			
			// Name Column
			TreeViewColumn nameColumn = new TreeViewColumn ();
			nameColumn.Title = "Mods";
			CellRendererText modsNameCell = new CellRendererText();
			nameColumn.PackStart (modsNameCell, true);
			// Status Column
			TreeViewColumn statusColumn = new TreeViewColumn ();
			statusColumn.Title = "Status";
			CellRendererText modsStatusCell = new CellRendererText();
			statusColumn.PackStart (modsStatusCell, true);
			// Config Column
			TreeViewColumn configColumn = new TreeViewColumn ();
			configColumn.Title = "Config File";
			CellRendererText modsConfigCell = new CellRendererText();
			configColumn.PackStart (modsConfigCell, true);
			
			treeView.AppendColumn (nameColumn);
			treeView.AppendColumn (statusColumn);
			treeView.AppendColumn (configColumn);
			
			nameColumn.SetCellDataFunc (modsNameCell, new TreeCellDataFunc (RenderModName));
			statusColumn.SetCellDataFunc (modsStatusCell, new TreeCellDataFunc (RenderModStatus));
			configColumn.SetCellDataFunc (modsConfigCell, new TreeCellDataFunc (RenderModConfig));
			
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
		
		private void RenderModName(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter) {
			ApacheMod mod = (ApacheMod) model.GetValue (iter, 0);
			(cell as CellRendererText).Text = mod.name;
		}
		
		private void RenderModStatus(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter) {
			ApacheMod mod = (ApacheMod) model.GetValue (iter, 0);
			if (mod.active) {
				(cell as Gtk.CellRendererText).Foreground = "darkgreen";
				(cell as CellRendererText).Text = "Active";
			} else {
				(cell as Gtk.CellRendererText).Foreground = "red";
				(cell as CellRendererText).Text = "Inactive";
			}
		}
		
		private void RenderModConfig(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter) {
			ApacheMod mod = (ApacheMod) model.GetValue (iter, 0);
			(cell as CellRendererText).Text = mod.getConfigFullPath();
		}
		
		public void setCollection(ArrayList list) {
			model.Clear();
			foreach (ApacheMod item in list) {
				model.AppendValues(item);
			}
		}
		
		private void OnSelectionChanged (object o, EventArgs args) {
            TreeIter iter; TreeModel model;
            if (((TreeSelection)o).GetSelected(out model, out iter)) {
				ApacheMod mod = (ApacheMod) model.GetValue(iter, 0);
				statusButton.Sensitive = true;
				changeStatusButton(mod.active);
				editButton.Sensitive = mod.hasConfigFile();
            }
        }
		
		private void OnStatusButtonToggled(object o, EventArgs args) {
			TreeIter iter; TreeModel model;
			if (treeView.Selection.GetSelected(out model, out iter)) {
				ApacheMod mod = (ApacheMod) model.GetValue(iter, 0);
				mod.changeStatus();
			}
		}
		
		private void changeStatusButton(bool status) {
			if (status) {
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
				ApacheMod mod = (ApacheMod) model.GetValue(iter, 0);
				mod.edit();
			}
		}
	}
}

