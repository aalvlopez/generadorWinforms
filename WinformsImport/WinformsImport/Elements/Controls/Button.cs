using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsImport
{
	public class Button:Control
	{
		ContentAlignment TextAlign {
			get;
			set;
		}
		public Button ():base(){
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
			this.Size=btn.Size;
			this.TextAlign = btn.TextAlign;
		}

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
			return btn;
		}
	}
}
