using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class VBox:Grid
	{
		private static int numElem=0;
		public VBox ():base()
		{
			this.Name="VBox"+VBox.numElem.ToString();
			VBox.numElem++;
			this.NumRows=0;
			this.NumColumns=1;
		}


		public VBox(VBox vb):base( (Grid)vb){
			this.NumRows=vb.NumRows;
			this.NumColumns=vb.NumColumns;
		}

		public override Element CopyElem (){
			return (Element)(new WinformsGenerator.VBox(this));
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


		public override DataGridView GenerateDataGrid ()
		{
			return base.GenerateDataGrid();
		}
		public override Element NewName ()
		{
			this.Name="VBox"+VBox.numElem.ToString();
			VBox.numElem++;
			return this;
		}
	}
}

