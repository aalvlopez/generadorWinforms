using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class ToolBar:ControlItems
	{
		private static int numElem=0;
		public ToolBar ():base(){
			this.Dock=DockStyle.Top;
			this.Name="ToolBar"+ToolBar.numElem.ToString();
			System.Windows.Forms.ToolBar tool = new System.Windows.Forms.ToolBar();
			this.Size=tool.Size;
		}

		public override Element CopyElem (){
			var tool = new WinformsGenerator.ToolBar();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.ToolBar).GetProperties()) {
				prop.SetValue(tool,prop.GetValue(this,null),null);
			}
			return tool;
		}

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

		public override Element NewElem ()
		{
			var tool = this.CopyElem();
			tool.Name="ToolBar"+ToolBar.numElem.ToString();
			ToolBar.numElem++;
			return tool;
		}
		public override void AddItem ()
		{
			this.items.Add(new WinformsGenerator.ToolBarItem());
		}
	}
}


