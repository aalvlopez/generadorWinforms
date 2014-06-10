using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class ProgressBar:Control
	{
		private static int numElem=0;
		
		public int Value {
			get;
			set; 
		}

		public ProgressBar ():base(){
			this.Name="ProgressBar"+ProgressBar.numElem.ToString();
			System.Windows.Forms.ProgressBar prog = new System.Windows.Forms.ProgressBar();
			this.Size=prog.Size;
			this.Value=0;
		}

		public override Element CopyElem (){
			var prog = new WinformsGenerator.ProgressBar();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.ProgressBar).GetProperties()) {
				prop.SetValue(prog,prop.GetValue(this,null),null);
			}
			return prog;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.ProgressBar prog = new System.Windows.Forms.ProgressBar();
			prog.Name = this.Name;
			prog.Text = this.Text;
			prog.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				prog.Anchor = this.Anchor;
			}
			prog.Dock=this.Dock;
			prog.Size=this.Size;
			prog.BackColor=this.BackColor;
			prog.Text=this.Text;

			prog.Value = this.Value;

			return prog;
		}

		public override Element NewName ()
		{
			var prog = this.CopyElem();
			prog.Name="ProgressBar"+ProgressBar.numElem.ToString();
			ProgressBar.numElem++;
			return prog;
		}
		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();

			string[] row = { "Value",this.Value.ToString ()};
			dataGridView.Rows.Add (row);
			
			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				Boolean isNum=false ;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "Value":
					int val=0;
					isNum= int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out val);
					if(isNum&&(val<=100&&val>=0)){
						this.Value=val;
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.Value.ToString();
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
	}
}


