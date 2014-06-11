using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsImport
{
	public class TextBox:Control
	{
		HorizontalAlignment TextAlign {
			get;
			set;
		}

		public TextBox ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox ();
			textBox.Name = this.Name;
			textBox.Text = this.Text;
			textBox.TextAlign = this.TextAlign;
			textBox.Size = this.Size;
			textBox.Location = new Point(this.Location.X,this.Location.Y);
			textBox.BackColor=this.BackColor;
			if (this.Anchor!=AnchorStyles.None) {
				textBox.Anchor = this.Anchor;
			}
			textBox.Dock=this.Dock;
			this.SetEvents(textBox);
			return textBox;
		}
	}
}

