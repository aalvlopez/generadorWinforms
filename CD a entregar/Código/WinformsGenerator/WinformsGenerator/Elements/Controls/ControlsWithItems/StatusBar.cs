using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class StatusBar:ControlItems
	{
		private static int numElem=0;
		public StatusBar ():base(){
			this.Dock=DockStyle.Bottom;
			this.Name="StatusBar"+StatusBar.numElem.ToString();
			System.Windows.Forms.StatusBar status = new System.Windows.Forms.StatusBar();
			this.Size=status.Size;
		}

		public override Element CopyElem (){
			var status = new WinformsGenerator.StatusBar();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.StatusBar).GetProperties()) {
				prop.SetValue(status,prop.GetValue(this,null),null);
			}
			return status;
		}

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

		public override Element NewElem ()
		{
			var status = this.CopyElem();
			status.Name="StatusBar"+StatusBar.numElem.ToString();
			StatusBar.numElem++;
			return status;
		}
		public override void AddItem ()
		{
			this.items.Add(new WinformsGenerator.StatusBarItem());
		}
	}
}


