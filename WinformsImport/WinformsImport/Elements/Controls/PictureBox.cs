using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

namespace WinformsImport
{
	public class PictureBox:Control
	{
		public String Image {
			get;
			set;
		}

		public PictureBox ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.PictureBox pict = new System.Windows.Forms.PictureBox();
			pict.Name = this.Name;
			pict.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				pict.Anchor = this.Anchor;
			}
			pict.Text=this.Text;
			pict.Dock=this.Dock;
			pict.Size=this.Size;
			pict.BackColor=this.BackColor;
			if (File.Exists (this.Image)) {
				pict.Image = System.Drawing.Image.FromFile(this.Image);
			}

			return pict;
		}
	}
}


