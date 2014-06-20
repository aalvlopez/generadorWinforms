using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public class ListView:ControlItems
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
		public bool CheckBoxes { 
			get;
			set;
		}
		public bool GridLines {
			get;
			set;
		}
		public View View {
			get;
			set;
		}

		public ListView ():base(){
			this.Dock = DockStyle.None;
			this.Name="ListView"+ListView.numElem.ToString();
			System.Windows.Forms.ListView listV = new System.Windows.Forms.ListView();
			this.Size=listV.Size;
			this.GridLines = listV.GridLines;
			this.CheckBoxes = listV.CheckBoxes;
			this.View = listV.View;
			this.NumColumns=0;
			this.Columns = new List<string>();
		}

		public override Element CopyElem (){
			var listV = new WinformsGenerator.ListView();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.ListView).GetProperties()) {
				prop.SetValue(listV,prop.GetValue(this,null),null);
			}
			foreach (Item i in this.items) {
				listV.items.Add (i.CopyItem ());
			}
			return listV;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.ListView listV = new System.Windows.Forms.ListView ();
			listV.Name = this.Name;
			listV.Location = new Point (this.Location.X, this.Location.Y);
			if (this.Anchor != AnchorStyles.None) {
				listV.Anchor = this.Anchor;
			}
			listV.Dock = this.Dock;
			listV.Size = this.Size;
			listV.BackColor = this.BackColor;

			
			listV.View = this.View;
			listV.GridLines = this.GridLines;
			if (this.View != View.Tile) {
				listV.CheckBoxes = this.CheckBoxes;
			}
			for (int i=0; i<this.NumColumns; i++) {
				if (i <= this.Columns.Count - 1) {
					listV.Columns.Add (this.Columns [i], -2);
				} else {
					listV.Columns.Add ("Column" + i.ToString (), -2);
				}
			}
			foreach (Item item in this.items) {
				System.Windows.Forms.ListViewItem listItem = new System.Windows.Forms.ListViewItem (item.Text,-2);
				foreach (Item subitem in ((ItemAnidado)item).items) {
					listItem.SubItems.Add(subitem.Text);
				}
				
            	listV.Items.Add(listItem);
			}

			return listV;
		}
		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[]row1 ={"CheckBoxes"};
			dataGridView.Rows.Add(row1);

			var check=new DataGridViewCheckBoxCell();
			check.Value=this.CheckBoxes;
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=check;

			string[]row4 ={"GridLines"};
			dataGridView.Rows.Add(row4);

			var grid=new DataGridViewCheckBoxCell();
			grid.Value=this.GridLines;
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=grid;

			string[] row0 = { "View"};
			dataGridView.Rows.Add (row0);
			var combo = new DataGridViewComboBoxCell ();
			foreach(View i in Enum.GetValues(typeof(View))){
				combo.Items.Add(i.ToString());
			}

			combo.Value = this.View.ToString();
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [1] = combo;

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
				case "CheckBoxes":
					this.CheckBoxes=(Boolean)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value;
					break;
				case "GridLines":
					this.GridLines=(Boolean)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value;
					break;
				case "View":
					if(((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString()!=""){
						this.View=(View) Enum.Parse(typeof(View),((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString());
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

				Controller.RefreshTreeView();
				Controller.SelectElement(this);
				Controller.ReDraw();
			};

			return dataGridView;
		}

		public override Element NewElem ()
		{
			var listV = this.CopyElem();
			listV.Name="ListView"+ListView.numElem.ToString();
			ListView.numElem++;
			return listV;
		}
		public override void AddItem ()
		{
			this.items.Add(new WinformsGenerator.ListViewItem());
		}
	}
}



