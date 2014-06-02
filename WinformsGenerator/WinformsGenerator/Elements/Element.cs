using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace WinformsGenerator
{
	public abstract class Element
	{ 
		public string Id {
			get;
			set;
		}
		public DockStyle Dock {
			get;
			set;
		}
		public String Name {
			get;
			set;
		}

		public Element ()
		{
			this.Dock=DockStyle.None;
			this.Name="Elemento";
			this.Id="0";
		}
		public Element (String id, DockStyle style, String name)
		{
			this.Dock=style;
			this.Name=name;
			this.Id=id;
		}
		public abstract void drawElement();
		public abstract void getTreeNode(TreeNode node,ContextMenuStrip menu);
	}
}

