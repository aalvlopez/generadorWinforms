using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsImport
{
	public class Border:Container
	{
		public Border ():base(){}

		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
			panel.Name=this.Name;
			panel.Size=this.Size;
			panel.Location=new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				panel.Anchor = this.Anchor;
			}
			panel.Dock = this.Dock;
			panel.BackColor=this.BackColor;
			foreach(Element e in this.elementos){
				panel.Controls.Add(e.DrawElement());
			}
			return panel;
		}
	}
}

