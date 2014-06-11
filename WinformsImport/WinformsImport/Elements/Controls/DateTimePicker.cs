using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class DateTimePicker:Control
	{
		public DateTimePickerFormat Format {
			get;
			set;
		}
		public DateTime Value {
			get;
			set;
		}

		public DateTimePicker ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.DateTimePicker dtPic = new System.Windows.Forms.DateTimePicker();
			dtPic.Name = this.Name;
			dtPic.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				dtPic.Anchor = this.Anchor;
			}
			dtPic.Dock=this.Dock;
			dtPic.Size=this.Size;
			dtPic.BackColor=this.BackColor;

			dtPic.Format = this.Format;
			dtPic.Value=this.Value;

			return dtPic;
		}
	}
}


