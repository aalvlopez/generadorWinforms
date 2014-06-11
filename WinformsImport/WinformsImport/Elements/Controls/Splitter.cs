using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class Splitter:Control
	{
		public Splitter ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.Splitter split = new System.Windows.Forms.Splitter();
			split.Name = this.Name;
			split.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				split.Anchor = this.Anchor;
			}
			split.Text=this.Text;
			split.Dock=this.Dock;
			split.Size=this.Size;
			split.BackColor=this.BackColor;

			return split;
		}
	}
}


