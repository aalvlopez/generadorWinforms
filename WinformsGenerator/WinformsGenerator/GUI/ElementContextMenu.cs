using System;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class ElementContextMenu:System.Windows.Forms.ContextMenuStrip
	{
		public ElementContextMenu ()
		{
			this.addMenuItem = new ToolStripMenuItem ();
			this.addPanel = new ToolStripMenuItem ();
			this.addItemMenuItem = new ToolStripMenuItem ();
			this.removeMenuItem = new ToolStripMenuItem ();
			this.copyMenuItem = new ToolStripMenuItem ();
			this.cutMenuItem = new ToolStripMenuItem ();
			this.pasteMenuItem = new ToolStripMenuItem ();
			this.containersMenuItem = new ToolStripMenuItem ();
			this.controlsMenuItem = new ToolStripMenuItem ();


			
			// 
			// contextMenuStrip1
			// 
			this.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
			this.addPanel,
            this.addItemMenuItem,
            this.removeMenuItem,
			this.copyMenuItem,
			this.pasteMenuItem,
			this.cutMenuItem}
			);
			this.Name = "contextMenuStrip1";
			this.Size = new System.Drawing.Size (111, 70);
	
			// 
            // addMenuItem
            // 
			this.addMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.containersMenuItem,
            this.controlsMenuItem});
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(110, 22);
            this.addMenuItem.Text = "Add";

			// 
            // addPanel
            // 
            this.addPanel.Name = "addMenuItem";
            this.addPanel.Size = new System.Drawing.Size(110, 22);
            this.addPanel.Text = "Add a Tab";
			this.addPanel.Visible = false;
			this.addPanel.Click+=delegate(object sender, EventArgs e) {
				Controller.AddPanel();
			};

			// 
            // addItemMenuItem
            // 
            this.addItemMenuItem.Name = "addItemMenuItem";
            this.addItemMenuItem.Size = new System.Drawing.Size(110, 22);
            this.addItemMenuItem.Text = "Add Item";
			this.addItemMenuItem.Enabled=false;
			this.addItemMenuItem.Click+=delegate(object sender, EventArgs e) {
				Controller.AddItem();
				Controller.RefreshTreeView();
			};

			// 
            // removeMenuItem
            // 
            this.removeMenuItem.Name = "removeMenuItem";
            this.removeMenuItem.Size = new System.Drawing.Size(110, 22);
            this.removeMenuItem.Text = "Remove";
			this.removeMenuItem.Click+=delegate(object sender,EventArgs e){
				Controller.RemoveElement();
				Controller.RefreshTreeView();
			};

			//
			//copyMenuItem
			//
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.Size = new System.Drawing.Size(110, 22);
            this.copyMenuItem.Text = "Copy Ctr+C";
			this.copyMenuItem.Click+=delegate(object sender,EventArgs e){
				Controller.CopyNode();
				this.pasteMenuItem.Enabled=true;
			};


			// 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.Size = new System.Drawing.Size(110, 22);
            this.pasteMenuItem.Text = "Paste Ctr+V";
			this.pasteMenuItem.Enabled=false;
			this.pasteMenuItem.Click+=delegate(object sender,EventArgs e){
				Controller.PasteNode();
				Controller.ReDraw();
				Controller.RefreshTreeView();

			};

			// 
            // cutMenuItem
            // 
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.Size = new System.Drawing.Size(110, 22);
            this.cutMenuItem.Text = "Cut Ctr+X";
			this.cutMenuItem.Click+=delegate(object sender,EventArgs e){
				Controller.CopyNode();
				Controller.RemoveNode();
				this.pasteMenuItem.Enabled=true;
				Controller.RefreshTreeView();
				
			};

			// 
            // containersMenuItem
            // 

			List<ToolStripItem> l = new List<ToolStripItem>();
			Assembly asm = Assembly.GetExecutingAssembly();
		    foreach (Type type in asm.GetTypes())
		    {
		        if (type.Namespace == "WinformsGenerator"){
					if(type.IsSubclassOf(typeof(WinformsGenerator.Container))&&type.Name!="Form"&&type.Name!="TabPage"){
						ToolStripMenuItem item = new ToolStripMenuItem();
						item.Name = type.Name;
            			item.Size = new System.Drawing.Size(110, 22);
						item.Text = type.Name;
						Element elem = (Element)Activator.CreateInstance(type);
						item.Click+=delegate(object sender,EventArgs e){
							Controller.AddElemnt(elem.NewElem());
						};
						l.Add(item);
					}
				}
		    }
			this.containersMenuItem.DropDownItems.AddRange(l.ToArray());
            this.containersMenuItem.Name = "containersMenuItem";
            this.containersMenuItem.Size = new System.Drawing.Size(110, 22);
            this.containersMenuItem.Text = "Containers";

			
			// 
            // controlsMenuItem
            // 
			l = new List<ToolStripItem>();
		    foreach (Type type in asm.GetTypes())
		    {
		        if (type.Namespace == "WinformsGenerator"){
					if(type.IsSubclassOf(typeof(WinformsGenerator.Control))&&!type.Equals(typeof(WinformsGenerator.ControlItems))){
						ToolStripMenuItem item = new ToolStripMenuItem();
						item.Name = type.Name;
            			item.Size = new System.Drawing.Size(110, 22);
						item.Text = type.Name;
						Element elem = (Element)Activator.CreateInstance(type);
						item.Click+=delegate(object sender,EventArgs e){
							Controller.AddElemnt(elem.NewElem());
						};
						l.Add(item);
					}
				}
		    }
			this.controlsMenuItem.DropDownItems.AddRange(l.ToArray());
            this.controlsMenuItem.Name = "controlsMenuItem";
            this.controlsMenuItem.Size = new System.Drawing.Size(110, 22);
            this.controlsMenuItem.Text = "Controls";

		}

		public void EnableAdd ()
		{
			this.addMenuItem.Enabled=true;
		}
		public void DisableAdd ()
		{
			this.addMenuItem.Enabled=false;
		}
		public void EnableAddItem ()
		{
			this.addItemMenuItem.Enabled=true;
		}
		public void DisableAddItem ()
		{
			this.addItemMenuItem.Enabled=false;
		}
		public void EnablePaste ()
		{
			this.pasteMenuItem.Enabled=true;
		}
		public void DisablePaste ()
		{
			this.pasteMenuItem.Enabled=false;
		}
		public void EnableCopy ()
		{
			this.copyMenuItem.Enabled=true;
		}
		public void DisableCopy ()
		{
			this.copyMenuItem.Enabled=false;
		}
		public void EnableCut ()
		{
			this.cutMenuItem.Enabled=true;
		}
		public void DisableCut ()
		{
			this.cutMenuItem.Enabled=false;
		}
		public void EnableRemove ()
		{
			this.removeMenuItem.Enabled=true;
		}
		public void DisableRemove ()
		{
			this.removeMenuItem.Enabled=false;
		}
		public void VisibleAddPanel ()
		{
			this.addPanel.Visible=true;
		}
		public void OcultAddPanel ()
		{
			this.addPanel.Visible=false;
		}


		private System.Windows.Forms.ToolStripMenuItem addMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addPanel;
		private System.Windows.Forms.ToolStripMenuItem addItemMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutMenuItem;

		private System.Windows.Forms.ToolStripMenuItem containersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem controlsMenuItem;
	}
}

