using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class MenuStrip:ControlItems
	{
		public MenuStrip ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.MenuStrip menu = new System.Windows.Forms.MenuStrip();
			menu.Name = this.Name;
			menu.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				menu.Anchor = this.Anchor;
			}
			menu.Dock=this.Dock;
			menu.Size=this.Size;
			menu.BackColor=this.BackColor;
			foreach (Item i in this.items) {
				ToolStripMenuItem menuItem = new ToolStripMenuItem(i.Text);
				this.DrawSubItems(menuItem,(ItemAnidado)i);
				menu.Items.Add(menuItem);
			}

			return menu;
		}
		public void DrawSubItems (ToolStripMenuItem menuItem, ItemAnidado item)
		{
			foreach (ItemAnidado i in item.items) {
				ToolStripMenuItem subMenuItem = new ToolStripMenuItem(i.Text);
				this.DrawSubItems(subMenuItem,i);
				menuItem.DropDownItems.Add(subMenuItem);
			}
		}
	}
}


