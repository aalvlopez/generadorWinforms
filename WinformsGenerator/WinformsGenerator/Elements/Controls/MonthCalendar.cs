using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class MonthCalendar:Control
	{
		private static int numElem=0;
		public Size CalendarDimensions {
			get;
			set;
		}

		public MonthCalendar ():base(){
			this.Name="MonthCalendar"+MonthCalendar.numElem.ToString();
			System.Windows.Forms.MonthCalendar month = new System.Windows.Forms.MonthCalendar();
			this.Size=month.Size;
			this.CalendarDimensions=month.CalendarDimensions;
		}

		public override Element CopyElem (){
			var month = new WinformsGenerator.MonthCalendar();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Element).GetProperties()) {
				prop.SetValue(month,prop.GetValue(this,null),null);
			}
			return month;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.MonthCalendar month = new System.Windows.Forms.MonthCalendar();
			month.Name = this.Name;
			month.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				month.Anchor = this.Anchor;
			}
			month.Dock=this.Dock;
			month.Size=this.Size;
			month.BackColor=this.BackColor;

			month.CalendarDimensions=this.CalendarDimensions;
			month.ShowWeekNumbers=true;

			return month;
		}

		public override Element NewName ()
		{
			var month = this.CopyElem();
			month.Name="MonthCalendar"+MonthCalendar.numElem.ToString();
			MonthCalendar.numElem++;
			return month;
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			if (this.GetType () != typeof(WinformsGenerator.HBox)) {
				string[] row = { "Rows",this.CalendarDimensions.Height.ToString ()};
				dataGridView.Rows.Add (row);
			}
			if (this.GetType () != typeof(WinformsGenerator.VBox)) {
				string[] row2 = { "Columns",this.CalendarDimensions.Width.ToString ()};
				dataGridView.Rows.Add (row2);
			}
			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				Boolean isNum ;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "Columns":
					int colNum;
					isNum= int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out colNum);
					if(isNum){
						this.CalendarDimensions=new Size(colNum,this.CalendarDimensions.Height);
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.CalendarDimensions.Width.ToString();
						}
					break;
				case "Rows":
					int rowNum;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out rowNum);
					if(isNum){
						this.CalendarDimensions=new Size(this.CalendarDimensions.Width,rowNum);
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.CalendarDimensions.Height.ToString();
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


