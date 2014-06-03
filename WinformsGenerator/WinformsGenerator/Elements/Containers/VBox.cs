using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class VBox:Container
	{
		public int NumRows {
			get;
			set;
		}
		public VBox ():base()
		{
		}
		public VBox(String id, DockStyle style, String name, int numRows,List<Element> elems):base(id, style, name,elems){
			this.NumRows=numRows;
		}

		public VBox(VBox vb):base(vb.Id, vb.Dock, vb.Name,vb.elementos){
			this.NumRows=vb.NumRows;
		}

		public override Element CopyElem (){
			return (Element)(new WinformsGenerator.VBox(this));
		}

		public void AddRow ()
		{
			this.NumRows++;
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
			System.Windows.Forms.TableLayoutPanel table = new System.Windows.Forms.TableLayoutPanel();
			table.Dock = this.Dock;
			table.Name=this.Name;
			table.ColumnCount=1;
			table.RowCount=this.NumRows;
			table.BackColor=Color.Beige;
			table.AutoSize=true;
			table.Click+=delegate(object sender, EventArgs elementos){
				Console.WriteLine(sender.GetType().ToString());
				this.ClickItem();
			};
			for(int i = 0; i<table.RowCount;i++){
				table.RowStyles.Add(new RowStyle(SizeType.Percent,(100/table.RowCount)));
			}

			int j=0;
			foreach(Element e in this.elementos){
				table.Controls.Add(e.DrawElement(),0,j);
				if(j<table.RowCount){
					j++;
				}
			}

			return table;
		}
		public override DataGridView GenerateDataGrid ()
		{
			DataGridView dataGridView = base.GenerateDataGrid();
			string[] row = { "Rows",this.NumRows.ToString()};
			dataGridView.Rows.Add (row);

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				Boolean isNum;
				switch((String)((DataGridView)sender).Rows[y].Cells[0].Value){
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
				MainWindow.panelTreeView.RefreshTreeView();
				MainWindow.ReDraw((Panel)App.formulario.DrawElement());
			};
			return dataGridView;
		}

	}
}

