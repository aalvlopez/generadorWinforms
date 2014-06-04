using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	

	public class Formulario:Container
	{
		public Formulario ():base(){
			System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
			this.Size=panel.Size;
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
			panel.Size = this.Size;
			panel.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			foreach(Element e in this.elementos){
				panel.Controls.Add(e.DrawElement());
			}
			return panel;
		}
		public Form DrawForm ()
		{
			Form form = new Form();
			form.Name=this.Name;
			form.Size = this.Size;
			form.Controls.Add(this.DrawElement());
			return form;
		}
		public override Element CopyElem (){return null;}
		
	}
}

