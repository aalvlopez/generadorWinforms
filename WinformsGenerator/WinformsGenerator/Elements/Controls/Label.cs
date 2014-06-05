using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Label:Control
	{
		
		ContentAlignment TextAlign {
			get;
			set;
		}
		public Label ():base()
		{
			this.TextAlign=ContentAlignment.MiddleRight;
			System.Windows.Forms.Label l = new System.Windows.Forms.Label();
			this.Size=l.Size;
		}

		public Label (Label l):base(l.Dock, l.Name,l.Text,l.Size,l.Location,l.Anchor)
		{
			this.TextAlign=l.TextAlign;
		}

		public override Element CopyElem (){
			return new WinformsGenerator.Label(this);
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.Label label = new System.Windows.Forms.Label ();
			label.Name = this.Name;
			label.Text = this.Text;
			label.TextAlign = this.TextAlign;
			label.Size = this.Size;
			label.Location = new Point(this.Location.X,this.Location.Y);
			label.BackColor=this.BackColor;
			if (this.Anchor!=AnchorStyles.None) {
				label.Anchor = this.Anchor;
			}
			label.Dock=this.Dock;
			label.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			return label;
		}

		public override DataGridView GenerateDataGrid ()
		{
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

