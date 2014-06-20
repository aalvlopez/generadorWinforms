using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.DirectoryServices;
using System.Threading.Tasks;

namespace WinformsGenerator
{
	public class PictureBox:Control
	{
		private static int numElem=0;
		public String Image {
			get;
			set;
		}

		public PictureBox ():base(){
			this.Name="PictureBox"+PictureBox.numElem.ToString();
			System.Windows.Forms.PictureBox pict = new System.Windows.Forms.PictureBox();
			this.Size=pict.Size;
			this.Dock=pict.Dock;
			this.Image="";
		}

		public override Element CopyElem (){
			var pict = new WinformsGenerator.PictureBox();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.PictureBox).GetProperties()) {
				prop.SetValue(pict,prop.GetValue(this,null),null);
			}
			return pict;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.PictureBox pict = new System.Windows.Forms.PictureBox();
			pict.Name = this.Name;
			pict.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				pict.Anchor = this.Anchor;
			}
			pict.Text=this.Text;
			pict.Dock=this.Dock;
			pict.Size=this.Size;
			pict.BackColor=this.BackColor;
			if (File.Exists (this.Image)) {
				pict.Image = System.Drawing.Image.FromFile(this.Image);
			}

			return pict;
		}

		public override Element NewElem ()
		{
			var pict = this.CopyElem();
			pict.Name="PictureBox"+PictureBox.numElem.ToString();
			PictureBox.numElem++;
			return pict;
		}
		public override System.Windows.Forms.DataGridView GenerateDataGrid (){
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();

			string[] row = { "Image",this.Image};
			dataGridView.Rows.Add (row);

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "Image":
					this.Image=((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString();
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


