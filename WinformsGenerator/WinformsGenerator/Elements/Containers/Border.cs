using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Border:Container
	{
		public Border ():base()
		{
		}
		public Border(String id, DockStyle style, String name):base(id, style, name)
		{
		}
		public override void AddElem (Element elem)
		{
			this.elementos.Add(elem);
		}
		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
			panel.Dock = this.Dock;
			panel.Name=this.Name;
			panel.BackColor=Color.Azure;
			foreach(Element e in this.elementos){
				panel.Controls.Add(e.DrawElement());
			}
			return panel;
		}
		public override DataGridView GenerateDataGrid ()
		{
			return base.GenerateDataGrid ();
		}
	}
}

