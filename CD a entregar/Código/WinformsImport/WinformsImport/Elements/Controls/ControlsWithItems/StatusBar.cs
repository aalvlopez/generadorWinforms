using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class StatusBar:ControlItems
	{
		public StatusBar ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.StatusBar status = new System.Windows.Forms.StatusBar();
			status.Name = this.Name;
			status.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				status.Anchor = this.Anchor;
			}
			status.Text=this.Text;
			status.Dock=this.Dock;
			status.Size=this.Size;
			status.BackColor=this.BackColor;
			foreach (Item i in this.items) {
				StatusBarPanel panel= new StatusBarPanel();
				panel.Text = i.Text;
				panel.BorderStyle = ((StatusBarItem)i).BorderStyle;
				panel.Width = ((StatusBarItem)i).Width;
				status.Panels.Add(panel);
			}
			status.ShowPanels=true;

			return status;
		}
	}
}


