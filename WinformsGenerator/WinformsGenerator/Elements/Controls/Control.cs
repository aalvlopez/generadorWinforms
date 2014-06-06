using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public abstract class Control:Element
	{
		public Control ():base(){}
		public Control (DockStyle style, String name,String text,Size size,Point location, AnchorStyles anchor,Color backColor):base(style, name,size,location,anchor,text,backColor){}
		public override void GetTreeNode (TreeNode node,ContextMenuStrip menu)
		{
			TreeNode node2=node.Nodes.Add (this.Name);
			node2.ContextMenuStrip = menu;
			node2.Tag=this;
		}

		public override DataGridView GenerateDataGrid ()
		{
			return base.GenerateDataGrid();
		}

		public override abstract System.Windows.Forms.Control DrawElement ();
		public override abstract Element NewName ();
	}
}

