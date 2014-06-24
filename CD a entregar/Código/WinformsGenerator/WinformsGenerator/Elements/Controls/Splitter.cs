using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class Splitter:Control
	{
		private static int numElem=0;
		public Splitter ():base(){
			this.Name="Splitter"+Splitter.numElem.ToString();
			System.Windows.Forms.Splitter split = new System.Windows.Forms.Splitter();
			this.Size=split.Size;
			this.Dock=split.Dock;
		}

		public override Element CopyElem (){
			var split = new WinformsGenerator.Splitter();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Splitter).GetProperties()) {
				prop.SetValue(split,prop.GetValue(this,null),null);
			}
			return split;
		}

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

		public override Element NewElem ()
		{
			var split = this.CopyElem();
			split.Name="Splitter"+Splitter.numElem.ToString();
			Splitter.numElem++;
			return split;
		}
	}
}


