using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class Label:Control
	{
		private static int numElem=0;
		ContentAlignment TextAlign {
			get;
			set;
		}
		public Label ():base()
		{
			this.Name="Label"+Label.numElem.ToString();
			this.TextAlign=ContentAlignment.MiddleRight;
			System.Windows.Forms.Label l = new System.Windows.Forms.Label();
			this.Size=l.Size;
		}


		public override Element CopyElem (){
			var label = new WinformsGenerator.Label();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Label).GetProperties()) {
				prop.SetValue(label,prop.GetValue(this,null),null);
			}
			return label;
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

			return label;
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row = { "TextAlign"};
			dataGridView.Rows.Add (row);


			var combo=new DataGridViewComboBoxCell();
			combo.DataSource=Enum.GetValues(typeof(ContentAlignment));
			combo.Value = this.TextAlign.ToString();
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=combo;

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "TextAlign":
					this.TextAlign=(ContentAlignment) Enum.Parse(typeof(ContentAlignment),((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString());
					break;
				
				default:
					break;
				}
				Controller.RefreshTreeView();
				Controller.ReDraw();
			};

			return dataGridView;
		}
		public override Element NewName ()
		{
			var label = this.CopyElem();
			label.Name="Label"+Label.numElem.ToString();
			Label.numElem++;
			return label;
		}
	}
}

