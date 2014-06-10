using System;
using System.Reflection;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class DataGridRow:Item
	{
		private static int  numelem=0;
		public String Values{
			get;
			set;
		}
		public DataGridRow ():base()
		{
			this.Name="DataGridRow"+DataGridRow.numelem.ToString();
			DataGridRow.numelem++;
			this.Text=this.Name;
			this.Values = "Cell1, Cell2";
		}
		public override Item CopyItem ()
		{
			var item = new DataGridRow();
			item.Values = this.Values;
			foreach (PropertyInfo prop in typeof(WinformsGenerator.DataGridRow).GetProperties()) {
				prop.SetValue(item,prop.GetValue(this,null),null);
			}
			return item;
		}
		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row = { "Values",this.Values};
			dataGridView.Rows.Add (row);

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "Values":
					this.Values=((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString();
					break;
				
				default:
					break;
				}
				Controller.RefreshTreeView();
				Controller.ReDraw();
			};

			return dataGridView;

		}

	}
}

