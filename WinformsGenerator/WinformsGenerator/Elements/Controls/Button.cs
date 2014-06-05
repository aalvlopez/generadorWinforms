using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Button:Control
	{
		ContentAlignment TextAlign {
			get;
			set;
		}
		public Button ():base(){
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
			this.Size=btn.Size;
			this.TextAlign = btn.TextAlign;
		}



		public Button (Button b):base(b.Dock,b.Name,b.Text,b.Size,b.Location,b.Anchor){
			this.TextAlign=b.TextAlign;
		}

		public override Element CopyElem (){
			return new WinformsGenerator.Button(this);
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button ();
			btn.Name = this.Name;
			btn.Text = this.Text;
			btn.TextAlign = this.TextAlign;
			btn.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				btn.Anchor = this.Anchor;
			}
			btn.Dock=this.Dock;
			btn.Size=this.Size;
			btn.BackColor=this.BackColor;
			btn.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			return btn;
		}

		public override DataGridView GenerateDataGrid (){
			DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row = { "TextAlign"};
			dataGridView.Rows.Add (row);


			var combo=new DataGridViewComboBoxCell();
			combo.DataSource=Enum.GetValues(typeof(ContentAlignment));
			combo.Value = this.TextAlign;
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=combo;

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((DataGridView)sender).Rows[y].Cells[0].Value){
				case "TextAlign":
					this.TextAlign=(ContentAlignment) Enum.Parse(typeof(ContentAlignment),((DataGridView)sender).Rows[y].Cells[1].Value.ToString());
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

