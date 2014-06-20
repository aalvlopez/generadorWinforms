using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class MenuStrip:ControlItems
	{
		private static int numElem=0;
		public MenuStrip ():base(){
			this.Dock=DockStyle.Top;
			this.Name="MenuStrip"+MenuStrip.numElem.ToString();
			System.Windows.Forms.MenuStrip menu = new System.Windows.Forms.MenuStrip();
			this.Size=menu.Size;
		}

		public override Element CopyElem (){
			var menu = new WinformsGenerator.MenuStrip();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.MenuStrip).GetProperties()) {
				prop.SetValue(menu,prop.GetValue(this,null),null);
			}
			return menu;
		}

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

		public override Element NewElem ()
		{
			var menu = this.CopyElem();
			menu.Name="MenuStrip"+MenuStrip.numElem.ToString();
			MenuStrip.numElem++;
			return menu;
		}
		public override void AddItem ()
		{
			this.items.Add(new WinformsGenerator.MenuStripItem());
		}
	}
}


