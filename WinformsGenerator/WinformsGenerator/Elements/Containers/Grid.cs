using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class Grid:Container
	{
		private static int numElem=0;
		public int NumColumns {
			get;
			set;
		}

		public int NumRows {
			get;
			set;
		}

		public Grid ():base(){
			this.Name="Grid"+Grid.numElem.ToString();
			Grid.numElem++;
			this.NumColumns=0;
			this.NumRows=0;
			System.Windows.Forms.TableLayoutPanel table = new System.Windows.Forms.TableLayoutPanel();
			this.Size=table.Size;
		}


		public Grid(Grid g):base(g.Dock, g.Name,g.elementos,g.Size,g.Location,g.Anchor,g.BackColor){
			this.NumColumns=g.NumColumns;
			this.NumRows=g.NumRows;
		}

		public override Element CopyElem (){
			return new WinformsGenerator.Grid(this);
		}

		public void AddColumn ()
		{
			this.NumColumns++;
		}

		public void AddRow ()
		{
			this.NumRows++;
		}
		public override void AddElem (Element elem)
		{
			if (this.elementos.Count >= this.NumRows * this.NumColumns) {
				this.AddRow();
			}
			this.elementos.Add(elem);
		}
		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.TableLayoutPanel table = new System.Windows.Forms.TableLayoutPanel();
			table.Name=this.Name;
			table.ColumnCount=this.NumColumns;
			table.RowCount=this.NumRows;
			table.Size=this.Size;
			table.Location=new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				table.Anchor = this.Anchor;
			}
			table.Dock = this.Dock;
			table.BackColor=this.BackColor;
			table.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			for(int a = 0; a<table.RowCount;a++){
				table.RowStyles.Add(new RowStyle(SizeType.Percent,(100/table.RowCount)));
			}

			for(int b = 0; b<table.ColumnCount;b++){
				table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,(100/table.ColumnCount)));
			}

			int i=0;
			int j =0;
			foreach(Element e in this.elementos){
				table.Controls.Add(e.DrawElement(),i,j);
				if(i<table.ColumnCount-1){
					i++;
				}else{
					if(j<table.RowCount-1){
						j++;
						i=0;
					}
				}
			}
			return table;
			
		}
		public override DataGridView GenerateDataGrid ()
		{
			DataGridView dataGridView = base.GenerateDataGrid ();
			if (this.GetType () != typeof(WinformsGenerator.HBox)) {
				string[] row = { "Rows",this.NumRows.ToString ()};
				dataGridView.Rows.Add (row);
			}
			if (this.GetType () != typeof(WinformsGenerator.VBox)) {
				string[] row2 = { "Columns",this.NumColumns.ToString ()};
				dataGridView.Rows.Add (row2);
			}
			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				Boolean isNum ;
				switch((String)((DataGridView)sender).Rows[y].Cells[0].Value){
				case "Columns":
					int colNum;
					isNum= int.TryParse((String)((DataGridView)sender).Rows[y].Cells[1].Value, out colNum);
					if(isNum){
						this.NumColumns=colNum;
					}else{
							this.NumColumns=0;
						}
					break;
				case "Rows":
					int rowNum;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[y].Cells[1].Value, out rowNum);
					if(isNum){
						this.NumRows=rowNum;
					}else{
							this.NumRows=0;
						}
					break;
				default:
					break;
				}
				Controller.RefreshTreeView();
				Controller.ReDraw();
			};
			return dataGridView;
		}
		public override Element NewName ()
		{
			this.Name="Grid"+Grid.numElem.ToString();
			Grid.numElem++;
			return this;
		}

	}
}

