using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Xml.Serialization;

namespace WinformsGenerator
{
	public class Button:Control
	{
		private static int numElem=0;
		public ContentAlignment TextAlign {
			get;
			set;
		}
		public Button ():base(){
			this.Name="Button"+Button.numElem.ToString();
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
			this.Size=btn.Size;
			this.TextAlign = btn.TextAlign;
		}



		public override Element CopyElem (){
			var button = new WinformsGenerator.Button();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Button).GetProperties()) {
				prop.SetValue(button,prop.GetValue(this,null),null);
			}
			return button;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button ();
			btn.Name = this.Name;
			btn.Text = this.Text;
			btn.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				btn.Anchor = this.Anchor;
			}
			btn.Dock=this.Dock;
			btn.Size=this.Size;
			btn.BackColor=this.BackColor;
			
			btn.TextAlign = this.TextAlign;

			return btn;
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid (){
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row = { "TextAlign"};
			dataGridView.Rows.Add (row);


			var combo=new DataGridViewComboBoxCell();
			foreach(ContentAlignment i in Enum.GetValues(typeof(ContentAlignment))){
				combo.Items.Add(i.ToString());
			}
			combo.Value = this.TextAlign.ToString();
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=combo;

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "TextAlign":
					if(((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString()!=""){
						this.TextAlign=(ContentAlignment) Enum.Parse(typeof(ContentAlignment),((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString());
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
		public override Element NewElem ()
		{
			var button = this.CopyElem();
			button.Name="Button"+Button.numElem.ToString();
			Button.numElem++;
			return button;
		}
	}
}

