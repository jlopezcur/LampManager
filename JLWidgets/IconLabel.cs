using System;
using Gtk;
namespace JLWidgets {
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class IconLabel : Gtk.Bin {
		public IconLabel () {
			this.Build ();
		}
		
		public Image GetImage() {
			return image;
		}
		
		public void SetImage(Image image) {
			this.image.Pixbuf = image.Pixbuf;
			//this.image.Pixbuf = (Gdk.Pixbuf) image.Pixbuf.Clone();
		}
		
		public void SetImageFromIcon(string icon_id) {
			Image tmp = new Image(Stetic.IconLoader.LoadIcon(this, icon_id, IconSize.Menu));
			this.image.Pixbuf = tmp.Pixbuf;
		}
		
		public String GetText() {
			return label.Text;
		}
		
		public void SetText(string text) {
			label.Text = text;
		}
	}
}

