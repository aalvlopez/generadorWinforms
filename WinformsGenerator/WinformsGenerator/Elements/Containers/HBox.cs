using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class HBox:Grid
	{
		private static int numElem=0;
		public HBox ():base()
		{
			this.Name="HBox"+HBox.numElem.ToString();
			HBox.numElem++;
			this.NumRows=1;
			this.NumColumns=0;
			this.Dock=DockStyle.Top;
		}


		public HBox(HBox hb):base( (Grid)hb){
			this.NumRows=hb.NumRows;
			this.NumColumns=hb.NumColumns;
		}

		public override Element CopyElem (){
			return new WinformsGenerator.HBox(this);
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
			this.Name="HBox"+HBox.numElem.ToString();
			HBox.numElem++;
			return this;
		}
	}
}

