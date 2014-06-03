using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	

	public class Formulario:Container
	{
		public Formulario ():base()
		{
		}
		public Formulario (String id, DockStyle style, String name,List<Element> elem):base(id, style, name,elem){
		}
		public override void AddElem (Element elem)
		{
			this.elementos.Add(elem);
		}
		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
			panel.Dock = DockStyle.None;
			panel.BackColor=Color.Chocolate;
			panel.Name=this.Name;
            panel.Size = new Size(600, 420);
			panel.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			foreach(Element e in this.elementos){
				panel.Controls.Add(e.DrawElement());
			}
			return panel;
		}
		public override Element CopyElem (){return null;}
		
	}
}

