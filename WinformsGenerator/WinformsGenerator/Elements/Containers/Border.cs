using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace WinformsGenerator
{
	public class Border:Container
	{
		private static int numElem=0; 
		public Border ():base(){
			this.Name="Border"+Border.numElem.ToString();
			System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
			this.Size=panel.Size;
			this.Dock = DockStyle.Fill;
		}


		public override Element CopyElem ()
		{
			var border = new WinformsGenerator.Border ();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Border).GetProperties()) {
				prop.SetValue (border, prop.GetValue (this, null), null);
			}
			foreach (Element e in this.elementos) {
				border.AddElem(e.CopyElem());
			}
			return border;
		}

		public override void AddElem (Element elem)
		{
			this.elementos.Add(elem);
		}

		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
			panel.Name=this.Name;
			panel.Size=this.Size;
			panel.Location=new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				panel.Anchor = this.Anchor;
			}
			panel.Dock = this.Dock;
			panel.BackColor=this.BackColor;

			foreach(Element e in this.elementos){
				panel.Controls.Add(e.DrawElement());
			}
			return panel;
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid (){
			return base.GenerateDataGrid ();
		}
		public override Element NewName ()
		{
			var border = this.CopyElem ();
			border.Name = "Border" + Border.numElem.ToString ();
			Border.numElem++;
			return border;
		}
	}
}

