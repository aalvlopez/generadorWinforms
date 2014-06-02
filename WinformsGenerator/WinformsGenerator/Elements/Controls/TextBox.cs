using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class TextBox:Control
	{
		HorizontalAlignment TextAlign {
			get;
			set;
		}
		public TextBox ():base()
		{
			this.TextAlign=HorizontalAlignment.Center;
		}

		public TextBox (String id, DockStyle style, String name, String text,HorizontalAlignment textAlign):base(id, style, name,text){
			this.TextAlign=textAlign;
		}



		public override void drawElement ()
		{
			System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
			textBox.Dock=this.Dock;
			textBox.Name=this.Name;
			textBox.Text = this.Text;
			textBox.TextAlign = this.TextAlign;

			WorkSpace.panelWork.SuspendLayout ();
			WorkSpace.panelWork.Controls.Add (textBox);
			WorkSpace.panelWork.ResumeLayout (false);
		}
	}
}

