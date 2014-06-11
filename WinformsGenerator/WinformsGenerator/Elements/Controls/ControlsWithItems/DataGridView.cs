using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class DataGridView:ControlItems
	{
		private static int numElem=0;
		public int NumColumns {
			get;
			set;
		}
		public List<String> Columns {
			get;
			set;
		}
		public DataGridView ():base(){
			this.Dock = DockStyle.None;
			this.Name="DataGridView"+DataGridView.numElem.ToString();
			System.Windows.Forms.DataGridView dataG = new System.Windows.Forms.DataGridView();
			this.Size=dataG.Size;
			this.NumColumns=0;
			this.Columns = new List<string>();
		}

		public override Element CopyElem (){
			var dataG = new WinformsGenerator.DataGridView();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.DataGridView).GetProperties()) {
				prop.SetValue(dataG,prop.GetValue(this,null),null);
			}
			foreach (Item i in this.items) {
				dataG.items.Add (i.CopyItem ());
			}
			return dataG;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.DataGridView dataG = new System.Windows.Forms.DataGridView ();
			dataG.Name = this.Name;
			dataG.Location = new Point (this.Location.X, this.Location.Y);
			if (this.Anchor != AnchorStyles.None) {
				dataG.Anchor = this.Anchor;
			}
			dataG.Dock = this.Dock;
			dataG.Size = this.Size;
			dataG.BackColor = this.BackColor;
			dataG.ColumnCount = this.NumColumns;
			dataG.AllowUserToAddRows = false;
			for (int i=0; i<this.NumColumns; i++) {
				if (i <= this.Columns.Count - 1) {
					dataG.Columns [i].Name = this.Columns [i];
				} else {
					dataG.Columns [i].Name = "Column" + i.ToString ();
				}
			}
			if (this.NumColumns != 0) {
				foreach (Item item in this.items) {
					string[] stringSeparators = new string[] {","};
					string[] result;
					result = ((DataGridRow)item).Values.Split (stringSeparators, StringSplitOptions.None);
					if (result.Length <= this.NumColumns) {
						dataG.Rows.Add (result);
					} else {
						List<String> subresult = new List<string> ();
						for (int j=0; j<this.NumColumns; j++) {
							subresult.Add (result [j]);
						}
						dataG.Rows.Add (subresult.ToArray ());
					}
				}
				if (this.items.Count != 0) {
					dataG.RowCount = this.items.Count;
				
				}
			}
			return dataG;
		}

		public override Element NewName ()
		{
			var dataG = this.CopyElem();
			dataG.Name="DataGridView"+DataGridView.numElem.ToString();
			DataGridView.numElem++;
			return dataG;
		}
		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row2 = { "Columns",this.NumColumns.ToString ()};
			dataGridView.Rows.Add (row2);
			for (int i=0; i<this.NumColumns; i++) {
				if (i < this.Columns.Count) {
					String[] row3 = { "Column"+i.ToString(),this.Columns[i]};
					dataGridView.Rows.Add (row3);
				} else {
					String[] row3 = { "Column"+i.ToString(),"Column"+i.ToString()};
					dataGridView.Rows.Add (row3);
				}
			}


			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				Boolean isNum ;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "Columns":
					int colNum;
					isNum= int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out colNum);
					if(isNum){
						List<string> newcolumns = new List<string>();
						for(int i=this.NumColumns;i>0;i--){
							newcolumns.Add(dataGridView.Rows [dataGridView.Rows.Count-i].Cells [1].Value.ToString());
						}
						this.Columns = newcolumns;
						this.NumColumns=colNum;
					}else{
							((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.NumColumns.ToString();
						}
					break;
				default:
					List<string> newcolumns2 = new List<string>();
					for(int i=this.NumColumns;i>0;i--){
						newcolumns2.Add(dataGridView.Rows [dataGridView.Rows.Count-i].Cells [1].Value.ToString());
					}
					this.Columns = newcolumns2;
					break;
				}
				
				Controller.SelectElement(this);
				Controller.RefreshTreeView();
				Controller.ReDraw();};

			return dataGridView;
		}

		public override void AddItem ()
		{
			this.items.Add(new WinformsGenerator.DataGridRow());
		}
	}
}


