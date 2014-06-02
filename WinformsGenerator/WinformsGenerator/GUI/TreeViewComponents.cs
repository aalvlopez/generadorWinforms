using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace WinformsGenerator
{
	public class TreeViewComponents:Panel
	{
		public TreeViewComponents(){
			this.InitializeComponent();
		}

		private void InitializeComponent(){

			
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
			this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vBoxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hboxMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BorderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxMenuItem = new System.Windows.Forms.ToolStripMenuItem();


            this.treeView1 = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();

			 // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.removeMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 70);



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
				Controller.addElemnt(new WinformsGenerator.Grid(),(Container) this.treeView1.SelectedNode.Tag);
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
//				Console.WriteLine (this.treeView1.SelectedNode.Text.ToString());
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
				this.treeView1.SelectedNode=e.Node;
				if(e.Node.Tag!=null){
					Console.WriteLine(e.Node.Tag.GetType());
				}
			};

            this.Controls.Add(this.treeView1);
            this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
		}



		private void AddItem(Object sender){
			Console.WriteLine("Click");
			Console.WriteLine(sender.ToString());
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
			foreach (Element elem in App.formulario.elementos) {
				elem.getTreeNode(node,this.contextMenuStrip1);

			}
			node.ContextMenuStrip = this.contextMenuStrip1;
            node.ExpandAll();
            
		}




		public TreeView treeView1;
        private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem addMenuItem;
		private ToolStripMenuItem removeMenuItem;

		private ToolStripMenuItem containersMenuItem;
		private ToolStripMenuItem vBoxMenuItem;
		private ToolStripMenuItem hboxMenuItem;
		private ToolStripMenuItem gridMenuItem;
		private ToolStripMenuItem BorderMenuItem;

		private ToolStripMenuItem controlsMenuItem;
		private ToolStripMenuItem labelMenuItem;
		private ToolStripMenuItem buttonMenuItem;
		private ToolStripMenuItem textBoxMenuItem;


		private TreeNode editNode;

	}
}

