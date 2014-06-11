using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace WinformsImport
{
	public class TabControl:Container
	{
		public TabControl ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.TabControl tool = new System.Windows.Forms.TabControl ();
			tool.Name = this.Name;
			tool.Location = new Point (this.Location.X, this.Location.Y);
			if (this.Anchor != AnchorStyles.None) {
				tool.Anchor = this.Anchor;
			}
			tool.Dock = this.Dock;
			tool.Size = this.Size;
			tool.BackColor = this.BackColor;
			foreach (Element tab in this.elementos) {
				tool.Controls.Add(((TabPage)tab).DrawPage());
			}

			return tool;
		}
	}
}


