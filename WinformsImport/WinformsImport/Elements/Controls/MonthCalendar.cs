using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class MonthCalendar:Control
	{
		public Size CalendarDimensions {
			get;
			set;
		}

		public MonthCalendar ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.MonthCalendar month = new System.Windows.Forms.MonthCalendar();
			month.Name = this.Name;
			month.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				month.Anchor = this.Anchor;
			}
			month.Dock=this.Dock;
			month.Size=this.Size;
			month.BackColor=this.BackColor;

			month.CalendarDimensions=this.CalendarDimensions;
			month.ShowWeekNumbers=true;

			return month;
		}
	}
}


