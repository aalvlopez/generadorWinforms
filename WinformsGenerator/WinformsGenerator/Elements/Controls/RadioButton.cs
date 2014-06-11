using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class RadioButton:Control
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
		public RadioButton ():base(){
			this.Name="RadioButton"+RadioButton.numElem.ToString();
			System.Windows.Forms.RadioButton combo = new System.Windows.Forms.RadioButton();
			this.Size=combo.Size;
			this.TextAlign=combo.TextAlign;
			this.Checked=false;
		}



		public override Element CopyElem (){
			var radio = new WinformsGenerator.RadioButton();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.RadioButton).GetProperties()) {
				prop.SetValue(radio,prop.GetValue(this,null),null);
			}
			return radio;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.RadioButton radio = new System.Windows.Forms.RadioButton ();
			radio.Name = this.Name;
			radio.Text = this.Text;
			radio.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				radio.Anchor = this.Anchor;
			}
			radio.Dock=this.Dock;
			radio.Size=this.Size;
			radio.BackColor=this.BackColor;

			radio.TextAlign=this.TextAlign;
			radio.Checked=this.Checked;
		
			return radio;
		}

		public override Element NewName ()
		{
			var radio = this.CopyElem();
			radio.Name="RadioButton"+RadioButton.numElem.ToString();
			RadioButton.numElem++;
			return radio;
		}
		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row = { "TextAlign"};
			dataGridView.Rows.Add (row);


			var combo=new DataGridViewComboBoxCell();
			foreach(ContentAlignment i in Enum.GetValues(typeof(ContentAlignment))){
				combo.Items.Add(i.ToString());
			}
			combo.Value = this.TextAlign.ToString();
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
					if(((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString()!=""){
						this.TextAlign=(ContentAlignment) Enum.Parse(typeof(ContentAlignment),((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString());
					}
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

