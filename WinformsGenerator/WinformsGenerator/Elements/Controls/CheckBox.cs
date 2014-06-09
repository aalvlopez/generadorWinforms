using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{

	public class CheckBox:Control
	{
		private static int numElem=0;
		public Boolean Checked {
			get;
			set;
		}
		ContentAlignment TextAlign {
			get;
			set;
		}

		public CheckBox ():base(){
			this.Name="CheckBox"+CheckBox.numElem.ToString();
			System.Windows.Forms.CheckBox check = new System.Windows.Forms.CheckBox();
			this.Size=check.Size;
			this.TextAlign=check.TextAlign;
			this.Checked=false;
		}



		public override Element CopyElem (){
			var check = new WinformsGenerator.CheckBox();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Element).GetProperties()) {
				prop.SetValue(check,prop.GetValue(this,null),null);
			}
			return check;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.CheckBox check = new System.Windows.Forms.CheckBox();
			check.Name = this.Name;
			check.Text = this.Text;
			check.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				check.Anchor = this.Anchor;
			}
			check.Dock=this.Dock;
			check.Size=this.Size;
			check.BackColor=this.BackColor;

			check.TextAlign=this.TextAlign;
			check.Checked=this.Checked;

			return check;
		}

		public override Element NewName ()
		{
			var check = this.CopyElem();
			check.Name="CheckBox"+CheckBox.numElem.ToString();
			CheckBox.numElem++;
			return check;
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row = { "TextAlign"};
			dataGridView.Rows.Add (row);


			var combo=new DataGridViewComboBoxCell();
			combo.DataSource=Enum.GetValues(typeof(ContentAlignment));
			combo.Value = this.TextAlign;
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=combo;

			string[]row1 ={"Checked"};
			dataGridView.Rows.Add(row1);

			var check=new DataGridViewCheckBoxCell();
			check.Value=this.Checked;
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=check;


			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "TextAlign":
					this.TextAlign=(ContentAlignment) Enum.Parse(typeof(ContentAlignment),((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString());
					break;
				case "Checked":
					this.Checked=(Boolean)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value;
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


