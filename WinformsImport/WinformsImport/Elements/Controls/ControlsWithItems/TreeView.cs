using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class TreeView:ControlItems
	{
		public TreeView ():base(){}

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

	}
}


