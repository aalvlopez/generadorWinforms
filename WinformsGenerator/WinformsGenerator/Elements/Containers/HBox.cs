using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class HBox:Container
	{
		public int NumColumns {
			get;
			set;
		}

		public HBox ():base()
		{
		}
		public HBox(String id, DockStyle style, String name, int numCols,List<Element> elems):base(id, style, name,elems){
			
		}

		public HBox(HBox hb):base(hb.Id, hb.Dock, hb.Name,hb.elementos){
			this.NumColumns=hb.NumColumns;
		}

		public override Element CopyElem (){
			return new WinformsGenerator.HBox(this);
		}

		public void AddColumn ()
		{
			this.NumColumns++;
		}

		public override void AddElem (Element e)

		{if (this.elementos.Count >= this.NumColumns) {
				this.AddColumn();
			}
		this.elementos.Add(e);

		}


		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.TableLayoutPanel table = new System.Windows.Forms.TableLayoutPanel();
			table.Dock = this.Dock;
			table.Name=this.Name;
			table.ColumnCount=this.NumColumns;
			table.RowCount=1;
			table.BackColor=Color.Crimson;
			table.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			for(int j = 0; j<table.ColumnCount;j++){
				table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,(100/table.ColumnCount)));
			}

			int i=0;
			foreach(Element e in this.elementos){
				table.Controls.Add(e.DrawElement(),i,0);
				if(i<table.ColumnCount){
					i++;
				}
			}

			return table;

		}
		public override DataGridView GenerateDataGrid ()
		{
			DataGridView dataGridView = base.GenerateDataGrid();
			string[] row = { "Columns",this.NumColumns.ToString()};
			dataGridView.Rows.Add (row);
			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				Boolean isNum;
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
				default:
					break;
				}
				MainWindow.panelTreeView.RefreshTreeView();
				MainWindow.ReDraw((Panel)App.formulario.DrawElement());
			};
			return dataGridView;
		}
	}
}

