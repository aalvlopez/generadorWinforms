using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class ToolBar:ControlItems
	{
		private static int numElem=0;
		public ToolBar ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.ToolBar tool = new System.Windows.Forms.ToolBar();
			tool.Name = this.Name;
			tool.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				tool.Anchor = this.Anchor;
			}
			tool.Dock=this.Dock;
			tool.Size=this.Size;
			tool.BackColor=this.BackColor;
			foreach (Item i in this.items) {
				ToolBarButton btn = new ToolBarButton();
				btn.Text = i.Text;
				tool.Buttons.Add(btn);
			}

			return tool;
		}
	}
}


