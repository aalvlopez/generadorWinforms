using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class TreeView:ControlItems
	{
		private static int numElem=0;
		public TreeView ():base(){
			this.Dock = DockStyle.None;
			this.Name="ToolBar"+TreeView.numElem.ToString();
			System.Windows.Forms.TreeView tree = new System.Windows.Forms.TreeView();
			this.Size=tree.Size;
		}

		public override Element CopyElem (){
			var tree = new WinformsGenerator.TreeView();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.TreeView).GetProperties()) {
				prop.SetValue(tree,prop.GetValue(this,null),null);
			}
			
			foreach (ItemAnidado i in this.items) {
				tree.items.Add (i.CopyItem ());
			}
			return tree;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.TreeView tree = new System.Windows.Forms.TreeView();
			tree.Name = this.Name;
			tree.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				tree.Anchor = this.Anchor;
			}
			tree.Dock=this.Dock;
			tree.Size=this.Size;
			tree.BackColor=this.BackColor;
			foreach (Item i in this.items) {
				TreeNode Node = new TreeNode(i.Text);
				this.DrawSubItems(Node,(ItemAnidado)i);
				tree.Nodes.Add(Node);
			}

			return tree;
		}
		public void DrawSubItems (TreeNode menuItem, ItemAnidado item)
		{
			foreach (ItemAnidado i in item.items) {
				TreeNode subNode = new TreeNode(i.Text);
				this.DrawSubItems(subNode,i);
				menuItem.Nodes.Add(subNode);
			}
		}

		public override Element NewElem ()
		{
			var tree = this.CopyElem();
			tree.Name="TreeView"+TreeView.numElem.ToString();
			TreeView.numElem++;
			return tree;
		}
		public override void AddItem ()
		{
			this.items.Add(new WinformsGenerator.TreeViewItem());
		}
	}
}


