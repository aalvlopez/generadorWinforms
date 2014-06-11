using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{

	public class CheckBox:Control
	{
		public Boolean Checked {
			get;
			set;
		}
		ContentAlignment TextAlign {
			get;
			set;
		}

		public CheckBox ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.CheckBox check = new System.Windows.Forms.CheckBox();
			check.Name = this.Name;
			check.Text = this.Text;
			check.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				check.Anchor = this.Anchor;
			}
			check.Dock=this.Dock;
			check.Size=this.Size;
			check.BackColor=this.BackColor;

			check.TextAlign=this.TextAlign;
			check.Checked=this.Checked;

			return check;
		}
	}
}


