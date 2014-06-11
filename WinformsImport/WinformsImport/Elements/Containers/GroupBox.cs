using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace WinformsImport
{
	public class GroupBox:Container
	{ 
		public GroupBox ():base(){}


		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.GroupBox group = new System.Windows.Forms.GroupBox();
			group.Name=this.Name;
			group.Size=this.Size;
			group.Location=new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				group.Anchor = this.Anchor;
			}
			group.Dock = this.Dock;
			group.BackColor=this.BackColor;
			group.Text = this.Text;

			foreach(Element e in this.elementos){
				group.Controls.Add(e.DrawElement());
			}
			return group;
		}

	}
}

