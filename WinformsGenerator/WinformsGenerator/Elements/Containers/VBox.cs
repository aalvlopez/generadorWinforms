using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace WinformsGenerator
{
	public class VBox:Grid
	{
		private static int numElem=0;
		public VBox ():base()
		{
			this.Name="VBox"+VBox.numElem.ToString();
			this.NumRows=0;
			this.NumColumns=1;
			this.Dock=DockStyle.Fill;
		}


		public override Element CopyElem (){
			var vBox = new WinformsGenerator.VBox();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.VBox).GetProperties()) {
				prop.SetValue(vBox,prop.GetValue(this,null),null);
			}
			foreach (Element e in this.elementos) {
				vBox.AddElem(e.CopyElem());
			}
			return vBox;
		}


		public override void AddElem (Element e)
		{
			if (this.elementos.Count >= this.NumRows) {
				this.AddRow ();
			}
			this.elementos.Add(e);
		}
		public override System.Windows.Forms.Control DrawElement ()
		{
			TableLayoutPanel table=(TableLayoutPanel) base.DrawElement();
			return table;
			
		}


		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			return base.GenerateDataGrid();
		}
		public override Element NewName ()
		{
			var vBox = this.CopyElem();
			vBox.Name="VBox"+VBox.numElem.ToString();
			VBox.numElem++;
			return vBox;
		}
	}
}

