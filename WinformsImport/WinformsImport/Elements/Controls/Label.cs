using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsImport
{
	public class Label:Control
	{
		
		ContentAlignment TextAlign {
			get;
			set;
		}
		public Label ():base()
		{
			this.TextAlign=ContentAlignment.MiddleRight;
			System.Windows.Forms.Label l = new System.Windows.Forms.Label();
			this.Size=l.Size;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.Label label = new System.Windows.Forms.Label ();
			label.Name = this.Name;
			label.Text = this.Text;
			label.TextAlign = this.TextAlign;
			label.Size = this.Size;
			label.Location = new Point(this.Location.X,this.Location.Y);
			label.BackColor=this.BackColor;
			if (this.Anchor!=AnchorStyles.None) {
				label.Anchor = this.Anchor;
			}
			label.Dock=this.Dock;
			return label;
		}
	}
}

