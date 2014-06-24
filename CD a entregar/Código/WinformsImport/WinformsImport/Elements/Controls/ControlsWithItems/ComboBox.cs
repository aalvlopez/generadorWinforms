using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsImport
{
	public class ComboBox:ControlItems
	{
		public ComboBox ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.ComboBox combo = new System.Windows.Forms.ComboBox ();
			combo.Name = this.Name;
			combo.Text = this.Text;
			combo.Location = new Point (this.Location.X, this.Location.Y);
			if (this.Anchor != AnchorStyles.None) {
				combo.Anchor = this.Anchor;
			}
			combo.Dock = this.Dock;
			combo.Size = this.Size;
			combo.BackColor = this.BackColor;

			foreach (Item i in this.items) {
				combo.Items.Add(i.Text);
			}
			return combo;
		}
	}
}

