using System;
using System.Reflection;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class StatusBarItem:Item
	{
		private static int  numelem=0;
		public int Width {
			get;
			set;
		}
		public StatusBarPanelBorderStyle BorderStyle {
			get;
			set;
		}
		public StatusBarItem ():base()
		{
			this.Name="StatusBarItem"+StatusBarItem.numelem.ToString();
			StatusBarItem.numelem++;
			this.Text=this.Name;
			StatusBarPanel panel= new StatusBarPanel();
			this.Width=panel.Width;
			this.BorderStyle=panel.BorderStyle;
		}
		public override Item CopyItem ()
		{
			var item = new StatusBarItem();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.StatusBarItem).GetProperties()) {
				prop.SetValue(item,prop.GetValue(this,null),null);
			}
			return item;
		}
		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row2 = { "Width",this.Width.ToString ()};
			dataGridView.Rows.Add (row2);

			string[] row0 = { "BorderStyle"};
			dataGridView.Rows.Add (row0);
			var combo = new DataGridViewComboBoxCell ();
			combo.DataSource = Enum.GetValues (typeof(StatusBarPanelBorderStyle));
			combo.Value = this.BorderStyle.ToString();
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [1] = combo;
			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				Boolean isNum ;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "Width":
					int width;
					isNum= int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out width);
					if(isNum){
						this.Width=width;
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.Width.ToString();
					}
					break;
				case "BorderStyle":
					this.BorderStyle=(StatusBarPanelBorderStyle) Enum.Parse(typeof(StatusBarPanelBorderStyle),((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString());
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

