using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class ProgressBar:Control
	{
		public int Value {
			get;
			set; 
		}

		public ProgressBar ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.ProgressBar prog = new System.Windows.Forms.ProgressBar();
			prog.Name = this.Name;
			prog.Text = this.Text;
			prog.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				prog.Anchor = this.Anchor;
			}
			prog.Dock=this.Dock;
			prog.Size=this.Size;
			prog.BackColor=this.BackColor;
			prog.Text=this.Text;

			prog.Value = this.Value;

			return prog;
		}
	}
}


