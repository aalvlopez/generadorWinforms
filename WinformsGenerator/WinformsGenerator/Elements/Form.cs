using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class Form:Container
	{
		private static int numElem=0;

		public Form ():base(){
			this.Name="Form"+Form.numElem.ToString();
			Form.numElem++;
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

			panel.BackColor=this.BackColor;
			panel.Name=this.Name;
			panel.Text=this.Text;
			panel.Size = new Size(this.Size.Width,this.Size.Height);
			if (this.Anchor!=AnchorStyles.None) {
				panel.Anchor = this.Anchor;
			}
			panel.Dock = DockStyle.None;

			foreach(Element e in this.elementos){
				panel.Controls.Add(e.DrawElement());
			}
			return panel;
		}

		public System.Windows.Forms.Form DrawForm ()
		{
			System.Windows.Forms.Form form = new  System.Windows.Forms.Form();
			form.Name=this.Name;
			form.Size = this.Size;
			form.Text=this.Text;
			form.BackColor=this.BackColor;
			Panel panel =Controller.Draw();
			panel.Dock=DockStyle.Fill;
			form.Controls.Add(panel);
			return form;
		}

		public override Element CopyElem (){
			return null;
		}

		public override Element NewName ()
		{
			this.Name="Form"+Form.numElem.ToString();
			Form.numElem++;
			return this;
		}
	}
}

