using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class TreeView:Control
	{
		private static int numElem=0;
		public TreeView ():base(){
			this.Dock=DockStyle.Top;
			this.Name="ToolBar"+TreeView.numElem.ToString();
			System.Windows.Forms.TreeView tree = new System.Windows.Forms.TreeView();
			this.Size=tree.Size;
		}

		public override Element CopyElem (){
			var tree = new WinformsGenerator.TreeView();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Element).GetProperties()) {
				prop.SetValue(tree,prop.GetValue(this,null),null);
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
			tree.Click+=delegate(object sender, EventArgs elementos){
				Controller.ClickItem(this);
			};
			return tree;
		}

		public override Element NewName ()
		{
			var tree = this.CopyElem();
			tree.Name="TreeView"+TreeView.numElem.ToString();
			TreeView.numElem++;
			return tree;
		}
	}
}


