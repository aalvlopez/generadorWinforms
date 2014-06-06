using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

namespace WinformsGenerator
{
	public class TreeViewComponents:Panel
	{
		public TreeViewComponents(){
			this.InitializeComponent();
		}

		private void InitializeComponent ()
		{
			this.contextMenuStrip1 = new ContextMenuStrip ();
			this.addMenuItem = new ToolStripMenuItem ();
			this.removeMenuItem = new ToolStripMenuItem ();
			this.copyMenuItem = new ToolStripMenuItem ();
			this.cutMenuItem = new ToolStripMenuItem ();
			this.pasteMenuItem = new ToolStripMenuItem ();
			this.containersMenuItem = new ToolStripMenuItem ();
			this.controlsMenuItem = new ToolStripMenuItem ();


			this.treeView1 = new System.Windows.Forms.TreeView ();
			this.contextMenuStrip1.SuspendLayout ();
			this.SuspendLayout ();

			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.removeMenuItem,
			this.copyMenuItem,
			this.pasteMenuItem,
			this.cutMenuItem}
			);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size (111, 70);
			this.contextMenuStrip1.Opened += delegate(object sender , EventArgs e) {
				if (this.treeView1.SelectedNode.Tag.GetType ().IsSubclassOf (typeof(WinformsGenerator.Control))) {
					this.addMenuItem.Enabled = false;
					this.pasteMenuItem.Enabled = false;
				} else {
					this.addMenuItem.Enabled = true;
					if (this.nodeCopied != null) {
						this.pasteMenuItem.Enabled = true;
					}
				}
				if (this.treeView1.SelectedNode.Tag.GetType () == typeof(WinformsGenerator.Form)) {
					this.removeMenuItem.Enabled = false;
					this.copyMenuItem.Enabled = false;
					this.cutMenuItem.Enabled = false;
				} else {
					this.removeMenuItem.Enabled = true;
					this.copyMenuItem.Enabled = true;
					this.cutMenuItem.Enabled = true;
				}

			};
			 


			//var menus = new System.Windows.Forms.ToolStripItem[]();

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
            // removeMenuItem
            // 

            this.removeMenuItem.Name = "removeMenuItem";
            this.removeMenuItem.Size = new System.Drawing.Size(110, 22);
            this.removeMenuItem.Text = "Remove";
			this.removeMenuItem.Click+=delegate(object sender,EventArgs e){
				Controller.RemoveElement((Element)this.treeView1.SelectedNode.Tag,(Container)this.treeView1.SelectedNode.Parent.Tag);
				this.RefreshTreeView();
			};

			//
			//copyMenuItem
			//


            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.Size = new System.Drawing.Size(110, 22);
            this.copyMenuItem.Text = "Copy Ctr+C";
			this.copyMenuItem.Click+=delegate(object sender,EventArgs e){
				this.nodeCopied=this.treeView1.SelectedNode;
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
				((Container)this.treeView1.SelectedNode.Tag).AddElem(((Element)this.nodeCopied.Tag).CopyElem());
				this.nodeCopied.Tag=((Element)this.nodeCopied.Tag).CopyElem();
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
				this.nodeCopied=this.treeView1.SelectedNode;
				this.pasteMenuItem.Enabled=true;
				Controller.RemoveElement((Element)this.treeView1.SelectedNode.Tag,(Container)this.treeView1.SelectedNode.Parent.Tag);
				this.RefreshTreeView();
				
			};

			List<ToolStripItem> l = new List<ToolStripItem>();
			Assembly asm = Assembly.GetExecutingAssembly();

		    foreach (Type type in asm.GetTypes())
		    {
		        if (type.Namespace == "WinformsGenerator"){
					if(type.IsSubclassOf(typeof(WinformsGenerator.Container))&&type.Name!="Form"){
						ToolStripMenuItem item = new ToolStripMenuItem();
						item.Name = type.Name;
            			item.Size = new System.Drawing.Size(110, 22);
						item.Text = type.Name;
						Element elem = (Element)Activator.CreateInstance(type);
						item.Click+=delegate(object sender,EventArgs e){
							Controller.addElemnt(elem.CopyElem().NewName(),((Container)this.treeView1.SelectedNode.Tag));
						};
						l.Add(item);
					}
				}
		    }

			// 
            // containersMenuItem
            // 

			this.containersMenuItem.DropDownItems.AddRange(l.ToArray());
            this.containersMenuItem.Name = "containersMenuItem";
            this.containersMenuItem.Size = new System.Drawing.Size(110, 22);
            this.containersMenuItem.Text = "Containers";


			l = new List<ToolStripItem>();

		    foreach (Type type in asm.GetTypes())
		    {
		        if (type.Namespace == "WinformsGenerator"){
					if(type.IsSubclassOf(typeof(WinformsGenerator.Control))){
						ToolStripMenuItem item = new ToolStripMenuItem();
						item.Name = type.Name;
            			item.Size = new System.Drawing.Size(110, 22);
						item.Text = type.Name;
						Console.WriteLine(type.Name);
						Element elem = (Element)Activator.CreateInstance(type);
						item.Click+=delegate(object sender,EventArgs e){
							Controller.addElemnt(elem.CopyElem(),((Container)this.treeView1.SelectedNode.Tag));
						};
						l.Add(item);
					}
				}
		    }

			// 
            // controlsMenuItem
            // 
			this.controlsMenuItem.DropDownItems.AddRange(l.ToArray());
            this.controlsMenuItem.Name = "controlsMenuItem";
            this.controlsMenuItem.Size = new System.Drawing.Size(110, 22);
            this.controlsMenuItem.Text = "Controls";



			// 
            // treeView1
            // 
            this.treeView1.Dock = DockStyle.Fill;
            this.treeView1.Name = "treeView1";
			this.BuildTreeView();
            this.treeView1.Size = new Size(124, 317);
            this.treeView1.TabIndex = 0;

			this.treeView1.AfterSelect+=delegate(object sender , TreeViewEventArgs e){
				if(this.treeView1.SelectedNode.Tag.GetType().Equals(typeof(WinformsGenerator.Form))){
					Controller.GetWindow().DisableCopy();
					Controller.GetWindow().DisableCut();
					Controller.GetWindow().DisableDelete();
				}else{
					Controller.GetWindow().EnableCopy();
					Controller.GetWindow().EnableCut();
					Controller.GetWindow().EnableDelete();
				}
				if(this.treeView1.SelectedNode.Tag.GetType().IsSubclassOf(typeof(WinformsGenerator.Control))){
					Controller.GetWindow().DisablePaste();
				}else{
					if(this.nodeCopied!=null){
						Controller.GetWindow().EnablePaste();
					}
				}

			};

			this.treeView1.NodeMouseClick+=delegate(object sender, TreeNodeMouseClickEventArgs e){
				
				this.treeView1.SelectedNode=e.Node;

				Controller.SelectItem((Element)e.Node.Tag);
			};

			this.treeView1.KeyDown+=delegate(object sender, KeyEventArgs e){

				if(e.Control && (e.KeyCode == Keys.C||e.KeyCode == Keys.X)){
					this.Copy();
				}else{
					if(e.Control && e.KeyCode == Keys.V){
						this.Paste();
					}
				}
				if((e.Control && e.KeyCode == Keys.X)||e.KeyCode==Keys.Delete){
					this.Remove();
				}

			};



            this.Controls.Add(this.treeView1);
            this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
		}


		public void RefreshTreeView(){
			this.treeView1.BeginUpdate();
			this.treeView1.Nodes.Clear(); 
			this.BuildTreeView();
			this.treeView1.EndUpdate();
			this.treeView1.Controls.Clear();
		}

		private void BuildTreeView ()
		{
			TreeNode node;
			node = this.treeView1.Nodes.Add (Controller.GetForm().Name);
			node.Tag=Controller.GetForm();
			this.treeView1.SelectedNode=this.treeView1.Nodes[0];
			foreach (Element elem in Controller.GetForm().elementos) {
				elem.GetTreeNode(node,this.contextMenuStrip1);

			}
			node.ContextMenuStrip = this.contextMenuStrip1;
            node.ExpandAll();
            
		}

		public void Copy(){
			this.nodeCopied=this.treeView1.SelectedNode;
			this.pasteMenuItem.Enabled=true;
			Controller.GetWindow().EnablePaste();
		}

		public void Paste ()
		{
			((Container)this.treeView1.SelectedNode.Tag).AddElem(((Element)this.nodeCopied.Tag).CopyElem());
			this.nodeCopied.Tag=((Element)this.nodeCopied.Tag).CopyElem();
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		public void Remove ()
		{
			Controller.RemoveElement((Element)this.treeView1.SelectedNode.Tag,(Container)this.treeView1.SelectedNode.Parent.Tag);
			this.RefreshTreeView();
		}

		public TreeView treeView1;
        private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem addMenuItem;
		private ToolStripMenuItem removeMenuItem;
		private ToolStripMenuItem copyMenuItem;
		private ToolStripMenuItem pasteMenuItem;
		private ToolStripMenuItem cutMenuItem;

		private ToolStripMenuItem containersMenuItem;
		private ToolStripMenuItem controlsMenuItem;

		public TreeNode nodeCopied;

	}
}

