using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class Border:Container
	{
		public Border ():base(){}

		public Border(String id, DockStyle style, String name,List<Element> elems):base(id, style, name,elems){}

		public Border(Border b):base(b.Id, b.Dock, b.Name,b.elementos){}

		public override Element CopyElem ()
		{
			Border b = new WinformsGenerator.Border (this);
			return b;
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
			panel.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			foreach(Element e in this.elementos){
				panel.Controls.Add(e.DrawElement());
			}
			return panel;
		}

		public override DataGridView GenerateDataGrid (){
			return base.GenerateDataGrid ();
		}
	}
}

