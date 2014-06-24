using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class TextBox:Control
	{
		private static int numElem=0;
		public HorizontalAlignment TextAlign {
			get;
			set;
		}

		public TextBox ():base(){
			this.Name="TextBox"+TextBox.numElem.ToString();
			this.TextAlign=HorizontalAlignment.Center;
			System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
			this.Size=tb.Size;
		}

		public override Element CopyElem (){
			var textBox = new WinformsGenerator.TextBox();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.TextBox).GetProperties()) {
				prop.SetValue(textBox,prop.GetValue(this,null),null);
			}
			return textBox;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox ();
			textBox.Name = this.Name;
			textBox.Text = this.Text;
			textBox.TextAlign = this.TextAlign;
			textBox.Size = this.Size;
			textBox.Location = new Point(this.Location.X,this.Location.Y);
			textBox.BackColor=this.BackColor;
			if (this.Anchor!=AnchorStyles.None) {
				textBox.Anchor = this.Anchor;
			}
			textBox.Dock=this.Dock;

			return textBox;
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid (){
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();

			string[] row = { "TextAlign"};
			dataGridView.Rows.Add (row);
			var combo=new DataGridViewComboBoxCell();
			foreach(HorizontalAlignment i in Enum.GetValues(typeof(HorizontalAlignment))){
				combo.Items.Add(i.ToString());
			}
			combo.Value = this.TextAlign.ToString();
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=combo;

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "TextAlign":
					if(((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString()!=""){
						this.TextAlign=(HorizontalAlignment) Enum.Parse(typeof(HorizontalAlignment),((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString());
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
			var textbox = this.CopyElem();
			textbox.Name="TextBox"+TextBox.numElem.ToString();
			TextBox.numElem++;
			return textbox;
		}
	}
}

