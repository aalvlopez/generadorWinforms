using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public abstract class Control:Element
	{
		public Control ():base(){}

		public override void GetTreeNode (TreeNode node, ContextMenuStrip menu,ContextMenuStrip menuItem)
		{
			TreeNode node2 = node.Nodes.Add (this.Name);
			node2.ContextMenuStrip = menu;
			node2.Tag = this;
			if (this.GetType ().IsSubclassOf (typeof(WinformsGenerator.ControlItems))) {
				foreach (Item i in ((WinformsGenerator.ControlItems)this).items) {
					i.GetTreeNode (node2,menuItem);
				}
			}
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			return base.GenerateDataGrid();
		}

		public override abstract System.Windows.Forms.Control DrawElement ();
		public override abstract Element NewName ();
		public override abstract Element CopyElem ();
	}
}

