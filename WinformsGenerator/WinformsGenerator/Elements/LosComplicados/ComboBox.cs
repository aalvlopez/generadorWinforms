using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class ComboBox:Control
	{
		private static int numElem=0;
		public ComboBox ():base(){
			this.Name="ComboBox"+ComboBox.numElem.ToString();
			System.Windows.Forms.ComboBox combo = new System.Windows.Forms.ComboBox();
			this.Size=combo.Size;
		}



		public override Element CopyElem (){
			var combo = new WinformsGenerator.ComboBox();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Element).GetProperties()) {
				prop.SetValue(combo,prop.GetValue(this,null),null);
			}
			return combo;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.ComboBox combo = new System.Windows.Forms.ComboBox ();
			combo.Name = this.Name;
			combo.Text = this.Text;
			combo.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				combo.Anchor = this.Anchor;
			}
			combo.Dock=this.Dock;
			combo.Size=this.Size;
			combo.BackColor=this.BackColor;
			combo.Click+=delegate(object sender, EventArgs elementos){
				Controller.ClickItem(this);
			};
			return combo;
		}

		public override Element NewName ()
		{
			var combo = this.CopyElem();
			combo.Name="ComboBox"+ComboBox.numElem.ToString();
			ComboBox.numElem++;
			return combo;
		}
	}
}

