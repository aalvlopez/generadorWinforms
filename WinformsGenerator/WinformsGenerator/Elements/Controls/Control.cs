using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public abstract class Control:Element
	{
		public String Text {
			get;
			set;
		}
		public Control ():base()
		{
			this.Text="PRUEBA";
		}
		public Control (String id, DockStyle style, String name,String text):base(id, style, name){
			this.Text=text;
		}
		public override void getTreeNode (TreeNode node,ContextMenuStrip menu)
		{
			TreeNode node2=node.Nodes.Add (this.Name);
			node2.Tag=this;
		}

		public override abstract void drawElement ();
	}
}

