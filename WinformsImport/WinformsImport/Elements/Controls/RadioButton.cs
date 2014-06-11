using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class RadioButton:Control
	{
		public Boolean Checked {
			get;
			set;
		}
		ContentAlignment TextAlign {
			get;
			set;
		}
		public RadioButton ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.RadioButton radio = new System.Windows.Forms.RadioButton ();
			radio.Name = this.Name;
			radio.Text = this.Text;
			radio.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				radio.Anchor = this.Anchor;
			}
			radio.Dock=this.Dock;
			radio.Size=this.Size;
			radio.BackColor=this.BackColor;

			radio.TextAlign=this.TextAlign;
			radio.Checked=this.Checked;
		
			return radio;
		}
	}
}

