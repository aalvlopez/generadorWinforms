using System;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class ItemContextMenu:System.Windows.Forms.ContextMenuStrip
	{
		public ItemContextMenu ()
		{
			this.addItemMenuItem = new ToolStripMenuItem ();
			this.removeMenuItem = new ToolStripMenuItem ();
			
			// 
			// contextMenuStrip1
			// 
			this.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.addItemMenuItem,
            this.removeMenuItem}
			);
			this.Name = "contextMenuStrip1";
			this.Size = new System.Drawing.Size (111, 70);

			// 
            // addItemMenuItem
            // 
            this.addItemMenuItem.Name = "addItemMenuItem";
            this.addItemMenuItem.Size = new System.Drawing.Size(110, 22);
            this.addItemMenuItem.Text = "Add Item";
			this.addItemMenuItem.Enabled=false;
			this.addItemMenuItem.Click+=delegate(object sender, EventArgs e) {
				Controller.addItem();
				Controller.RefreshTreeView();
			};

			// 
            // removeMenuItem
            // 
            this.removeMenuItem.Name = "removeMenuItem";
            this.removeMenuItem.Size = new System.Drawing.Size(110, 22);
            this.removeMenuItem.Text = "Remove";
			this.removeMenuItem.Click+=delegate(object sender,EventArgs e){
				Controller.RemoveItem();
				Controller.RefreshTreeView();
			};

		}

		public void EnableAddItem ()
		{
			this.addItemMenuItem.Enabled=true;
		}
		public void DisableAddItem ()
		{
			this.addItemMenuItem.Enabled=false;
		}
		public void EnableRemove ()
		{
			this.removeMenuItem.Enabled=true;
		}
		public void DisableRemove ()
		{
			this.removeMenuItem.Enabled=false;
		}

		private System.Windows.Forms.ToolStripMenuItem addItemMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeMenuItem;
	}
}

