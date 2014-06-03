using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class TextBox:Control
	{
		HorizontalAlignment TextAlign {
			get;
			set;
		}

		public TextBox ():base(){
			this.TextAlign=HorizontalAlignment.Center;
		}

		public TextBox (String id, DockStyle style, String name, String text,HorizontalAlignment textAlign):base(id, style, name,text){
			this.TextAlign=textAlign;
		}

		public TextBox (TextBox t):base(t.Id, t.Dock, t.Name,t.Text){
			this.TextAlign=t.TextAlign;
		}

		public override Element CopyElem (){
			return new WinformsGenerator.TextBox(this);
		}

		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
			textBox.Dock=this.Dock;
			textBox.Name=this.Name;
			textBox.Text = this.Text;
			textBox.TextAlign = this.TextAlign;
			textBox.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			return textBox;
		}


		public override DataGridView GenerateDataGrid (){
			DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row = { "TextAlign"};
			dataGridView.Rows.Add (row);


			var combo=new DataGridViewComboBoxCell();
			combo.DataSource=Enum.GetValues(typeof(HorizontalAlignment));
			combo.Value = this.TextAlign;
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=combo;

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((DataGridView)sender).Rows[y].Cells[0].Value){
				case "TextAlign":
					this.TextAlign=(HorizontalAlignment) Enum.Parse(typeof(HorizontalAlignment),((DataGridView)sender).Rows[y].Cells[1].Value.ToString());
					break;
				
				default:
					break;
				}
				MainWindow.panelTreeView.RefreshTreeView();
				MainWindow.ReDraw((Panel)App.formulario.DrawElement());
			};

			return dataGridView;
		}
	}
}

