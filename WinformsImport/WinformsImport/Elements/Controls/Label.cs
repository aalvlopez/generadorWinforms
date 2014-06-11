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
		public Label ():base(){}

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
			this.SetEvents(label);
			return label;
		}
	}
}

