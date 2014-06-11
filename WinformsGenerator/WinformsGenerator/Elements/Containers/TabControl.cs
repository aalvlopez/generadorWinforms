using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class TabControl:Container
	{
		private static int numElem=0;
		public TabControl ():base(){
			this.Dock = DockStyle.None;
			this.Name="TabControl"+TabControl.numElem.ToString();
			System.Windows.Forms.TabControl tool = new System.Windows.Forms.TabControl();
			this.Size=tool.Size;
		}

		public override Element CopyElem (){
			var tool = new WinformsGenerator.TabControl();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.TabControl).GetProperties()) {
				prop.SetValue(tool,prop.GetValue(this,null),null);
			}
			foreach (Element e in this.elementos) {
				tool.AddElem(e.CopyElem());
			}
			return tool;
		}

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

		public override Element NewName ()
		{
			var tool = this.CopyElem();
			tool.Name="TabControl"+TabControl.numElem.ToString();
			TabControl.numElem++;
			return tool;
		}
		public override void AddElem (Element elem)
		{
			this.elementos.Add(elem);
		}
	}
}


