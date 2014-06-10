using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace WinformsGenerator
{
	public class TabPage:Container
	{
		private static int numElem=0;
		public TabPage ():base(){
			this.Name="TabPanel"+TabPage.numElem.ToString();
			this.Text=this.Name;
			this.Size = new Size(0,0);
		}

		public override Element CopyElem (){
			var tool = new WinformsGenerator.TabPage();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.TabPage).GetProperties()) {
				prop.SetValue(tool,prop.GetValue(this,null),null);
			}
			foreach (Element e in this.elementos) {
				tool.AddElem(e.CopyElem());
			}
			return tool;
		}
		public override System.Windows.Forms.Control DrawElement ()
		{
			throw new System.NotImplementedException ();
		}

		public System.Windows.Forms.TabPage DrawPage ()
		{
			System.Windows.Forms.TabPage tool = new System.Windows.Forms.TabPage();
			tool.Name = this.Name;
			tool.Text=this.Text;
			tool.Location = new Point(this.Location.X,this.Location.Y);
			tool.BackColor=this.BackColor;
			foreach(Element e in this.elementos){
				tool.Controls.Add(e.DrawElement());
			}
			return tool;
		}

		public override Element NewName ()
		{
			var tool = this.CopyElem();
			tool.Name="TabPage"+TabPage.numElem.ToString();
			TabPage.numElem++;
			return tool;
		}

		public override void AddElem (Element elem)
		{
			this.elementos.Add(elem);
		}
	}
}

