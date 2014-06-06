using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class Border:Container
	{
		public Border ():base(){
			System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
			this.Size=panel.Size;
		}

		public Border(Border b):base(b.Dock, b.Name,b.elementos,b.Size,b.Location,b.Anchor,b.BackColor){}

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
			panel.Name=this.Name;
			panel.Size=this.Size;
			panel.Location=new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				panel.Anchor = this.Anchor;
			}
			panel.Dock = this.Dock;
			panel.BackColor=this.BackColor;
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

