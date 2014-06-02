using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Border:Container
	{
		public Border ():base()
		{
		}
		public Border(String id, DockStyle style, String name):base(id, style, name)
		{
		}

		public override void drawElement (){
			System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
			panel.Dock = this.Dock;
			panel.Name=this.Name;
			
			WorkSpace.panelWork.SuspendLayout();
			WorkSpace.panelWork.Controls.Add(panel);
			WorkSpace.panelWork.ResumeLayout(false);
		}
	}
}

