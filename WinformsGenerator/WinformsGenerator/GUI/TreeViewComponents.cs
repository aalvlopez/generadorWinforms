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

		private void InitializeComponent(){

			
            this.contextMenuStrip1 = new ContextMenuStrip();
			this.addMenuItem = new ToolStripMenuItem();
            this.removeMenuItem = new ToolStripMenuItem();
			this.copyMenuItem = new ToolStripMenuItem();
			this.cutMenuItem = new ToolStripMenuItem();
            this.pasteMenuItem = new ToolStripMenuItem();
            this.containersMenuItem = new ToolStripMenuItem();
            this.vBoxMenuItem = new ToolStripMenuItem();
            this.hboxMenuItem = new ToolStripMenuItem();
            this.gridMenuItem = new ToolStripMenuItem();
            this.BorderMenuItem = new ToolStripMenuItem();
            this.controlsMenuItem = new ToolStripMenuItem();
            this.labelMenuItem = new ToolStripMenuItem();
            this.buttonMenuItem = new ToolStripMenuItem();
            this.textBoxMenuItem = new ToolStripMenuItem();


            this.treeView1 = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();

			 // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.removeMenuItem,
			this.copyMenuItem,
			this.pasteMenuItem,
			this.cutMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 70);
			this.contextMenuStrip1.Opened+=delegate(object sender , EventArgs e){

				if(this.treeView1.SelectedNode.Tag.GetType().IsSubclassOf(typeof(WinformsGenerator.Control))){
					this.addMenuItem.Enabled=false;
					this.pasteMenuItem.Enabled=false;
				}else{
					this.addMenuItem.Enabled=true;
					if(this.nodeCopied!=null){
						this.pasteMenuItem.Enabled=true;
					}
				}
				if(this.treeView1.SelectedNode.Tag.GetType()==typeof(WinformsGenerator.Formulario)){
					this.removeMenuItem.Enabled=false;
					this.copyMenuItem.Enabled=false;
					this.cutMenuItem.Enabled=false;
				}else{
					this.removeMenuItem.Enabled=true;
					this.copyMenuItem.Enabled=true;
					this.cutMenuItem.Enabled=true;
				}

			};

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
				MainWindow.ReDraw((Panel)App.formulario.DrawElement());
				MainWindow.panelTreeView.RefreshTreeView();
				
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

			// 
            // containersMenuItem
            // 

			this.containersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vBoxMenuItem,
            this.hboxMenuItem,
			this.gridMenuItem,
			this.BorderMenuItem});
            this.containersMenuItem.Name = "containersMenuItem";
            this.containersMenuItem.Size = new System.Drawing.Size(110, 22);
            this.containersMenuItem.Text = "Containers";

			// 
            // controlsMenuItem
            // 
			this.controlsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelMenuItem,
            this.buttonMenuItem,
			this.textBoxMenuItem});
            this.controlsMenuItem.Name = "controlsMenuItem";
            this.controlsMenuItem.Size = new System.Drawing.Size(110, 22);
            this.controlsMenuItem.Text = "Controls";

			// 
            // vBoxMenuItem
            // 
			this.vBoxMenuItem.Name = "vBoxMenuItem";
            this.vBoxMenuItem.Size = new System.Drawing.Size(110, 22);
            this.vBoxMenuItem.Text = "VBox";
			this.vBoxMenuItem.Click+=delegate(object sender, EventArgs e){
				Controller.addElemnt(new WinformsGenerator.VBox(),(Container) this.treeView1.SelectedNode.Tag);
				this.AddItem(sender);
			};

			// 
            // hboxMenuItem
            // 
			this.hboxMenuItem.Name = "hboxMenuItem";
            this.hboxMenuItem.Size = new System.Drawing.Size(110, 22);
            this.hboxMenuItem.Text = "HBox";
			this.hboxMenuItem.Click+=delegate(object sender, EventArgs e){
				Controller.addElemnt(new WinformsGenerator.HBox(),(Container) this.treeView1.SelectedNode.Tag);
				this.AddItem(sender);
			};

			// 
            // gridMenuItem
            // 
			this.gridMenuItem.Name = "gridMenuItem";
            this.gridMenuItem.Size = new System.Drawing.Size(110, 22);
            this.gridMenuItem.Text = "Grid";
			this.gridMenuItem.Click+=delegate(object sender, EventArgs e){
				Controller.addElemnt(new WinformsGenerator.Grid(),((Container)this.treeView1.SelectedNode.Tag));
				this.AddItem(sender);
			};

			// 
            // BorderMenuItem
            // 
			this.BorderMenuItem.Name = "BorderMenuItem";
            this.BorderMenuItem.Size = new System.Drawing.Size(110, 22);
            this.BorderMenuItem.Text = "Border";
			this.BorderMenuItem.Click+=delegate(object sender, EventArgs e){
				Controller.addElemnt(new WinformsGenerator.Border(),(Container) this.treeView1.SelectedNode.Tag);
				this.AddItem(sender);
			};

			// 
            // labelMenuItem
            // 
			this.labelMenuItem.Name = "labelMenuItem";
            this.labelMenuItem.Size = new System.Drawing.Size(110, 22);
            this.labelMenuItem.Text = "Label";
			this.labelMenuItem.Click+=delegate(object sender, EventArgs e){
				Controller.addElemnt(new WinformsGenerator.Label(),(Container) this.treeView1.SelectedNode.Tag);
				this.AddItem(sender);
			};

			// 
            // buttonMenuItem
            // 
			this.buttonMenuItem.Name = "buttonMenuItem";
            this.buttonMenuItem.Size = new System.Drawing.Size(110, 22);
            this.buttonMenuItem.Text = "Button";
			this.buttonMenuItem.Click+=delegate(object sender, EventArgs e){
				Controller.addElemnt(new WinformsGenerator.Button(),(Container) this.treeView1.SelectedNode.Tag);
				this.AddItem(sender);
			};

			// 
            // textBoxMenuItem
            // 
			this.textBoxMenuItem.Name = "textBoxMenuItem";
            this.textBoxMenuItem.Size = new System.Drawing.Size(110, 22);
            this.textBoxMenuItem.Text = "TextBox";
			this.textBoxMenuItem.Click+=delegate(object sender, EventArgs e){
				Controller.addElemnt(new WinformsGenerator.TextBox(),(Container) this.treeView1.SelectedNode.Tag);
				this.AddItem(sender);
			};

			// 
            // treeView1
            // 
            this.treeView1.Dock = DockStyle.Fill;
            this.treeView1.Name = "treeView1";
			this.BuildTreeView();
            this.treeView1.Size = new Size(124, 317);
            this.treeView1.TabIndex = 0;

			this.treeView1.NodeMouseClick+=delegate(object sender, TreeNodeMouseClickEventArgs e){
				if (e.Button == MouseButtons.Right)
            	{
                	this.treeView1.SelectedNode=e.Node;

					Controller.SelectItem((Element)e.Node.Tag);
            	}
				this.treeView1.SelectedNode=e.Node;

				Controller.SelectItem((Element)e.Node.Tag);
			};

			this.treeView1.KeyDown+=delegate(object sender, KeyEventArgs e){

				if(e.Control && (e.KeyCode == Keys.C||e.KeyCode == Keys.X)){
					this.nodeCopied=this.treeView1.SelectedNode;
					this.pasteMenuItem.Enabled=true;



				}else{
					if(e.Control && e.KeyCode == Keys.V){
						((Container)this.treeView1.SelectedNode.Tag).AddElem(((Element)this.nodeCopied.Tag).CopyElem());
						this.nodeCopied.Tag=((Element)this.nodeCopied.Tag).CopyElem();
						MainWindow.ReDraw((Panel)App.formulario.DrawElement());
						MainWindow.panelTreeView.RefreshTreeView();
					}
				}
				if((e.Control && e.KeyCode == Keys.X)||e.KeyCode==Keys.Delete){
					Controller.RemoveElement((Element)this.treeView1.SelectedNode.Tag,(Container)this.treeView1.SelectedNode.Parent.Tag);
					this.RefreshTreeView();
				}

			};



            this.Controls.Add(this.treeView1);
            this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
		}



		private void AddItem(Object sender){
			this.RefreshTreeView();
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
			node = this.treeView1.Nodes.Add (App.formulario.Name);
			node.Tag=App.formulario;
			this.treeView1.SelectedNode=this.treeView1.Nodes[0];
			foreach (Element elem in App.formulario.elementos) {
				elem.GetTreeNode(node,this.contextMenuStrip1);

			}
			node.ContextMenuStrip = this.contextMenuStrip1;
            node.ExpandAll();
            
		}




		public TreeView treeView1;
        private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem addMenuItem;
		private ToolStripMenuItem removeMenuItem;
		private ToolStripMenuItem copyMenuItem;
		private ToolStripMenuItem pasteMenuItem;
		private ToolStripMenuItem cutMenuItem;

		private ToolStripMenuItem containersMenuItem;
		private ToolStripMenuItem vBoxMenuItem;
		private ToolStripMenuItem hboxMenuItem;
		private ToolStripMenuItem gridMenuItem;
		private ToolStripMenuItem BorderMenuItem;

		private ToolStripMenuItem controlsMenuItem;
		private ToolStripMenuItem labelMenuItem;
		private ToolStripMenuItem buttonMenuItem;
		private ToolStripMenuItem textBoxMenuItem;

		public TreeNode nodeCopied;

	}
}

