using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace WinformsImport
{
	public class TabPage:Container
	{
		public TabPage ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			throw new System.NotImplementedException ();
		}

		public System.Windows.Forms.TabPage DrawPage ()
		{
			System.Windows.Forms.TabPage tool = new System.Windows.Forms.TabPage();
			tool.Name = this.Name;
			tool.Text=this.Text;
			tool.Location = new Point(this.Location.X,this.Location.Y);
			tool.BackColor=this.BackColor;
			foreach(Element e in this.elementos){
				tool.Controls.Add(e.DrawElement());
			}
			return tool;
		}
	}
}

