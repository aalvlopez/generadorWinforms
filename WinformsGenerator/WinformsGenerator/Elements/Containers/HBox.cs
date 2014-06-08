using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace WinformsGenerator
{
	public class HBox:Grid
	{
		private static int numElem=0;
		public HBox ():base()
		{
			this.Name="HBox"+HBox.numElem.ToString();
			this.NumRows=1;
			this.NumColumns=0;
			this.Dock=DockStyle.Top;
		}



		public override Element CopyElem (){
			var hBox = new WinformsGenerator.Border();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Element).GetProperties()) {
				prop.SetValue(hBox,prop.GetValue(this,null),null);
			}
			foreach (Element e in this.elementos) {
				hBox.AddElem(e.CopyElem());
			}
			return hBox;
		}

		public override void AddElem (Element e)

		{if (this.elementos.Count >= this.NumColumns) {
				this.AddColumn();
			}
		this.elementos.Add(e);

		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			TableLayoutPanel table=(TableLayoutPanel) base.DrawElement();
			return table;

		}
		public override DataGridView GenerateDataGrid ()
		{
			return base.GenerateDataGrid();

		}
		public override Element NewName ()
		{
			var hBox = this.CopyElem();
			hBox.Name="HBox"+HBox.numElem.ToString();
			HBox.numElem++;
			return hBox;
		}
	}
}

