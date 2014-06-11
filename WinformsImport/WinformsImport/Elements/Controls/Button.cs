using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class Button:Control
	{
		ContentAlignment TextAlign {
			get;
			set;
		}
		public Button ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button ();
			btn.Name = this.Name;
			btn.Text = this.Text;
			btn.TextAlign = this.TextAlign;
			btn.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				btn.Anchor = this.Anchor;
			}
			btn.Dock=this.Dock;
			btn.Size=this.Size;
			btn.BackColor=this.BackColor;
			this.SetEvents(btn);

			return btn;
		}
	}
}

