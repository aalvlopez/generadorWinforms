using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class DateTimePicker:Control
	{
		private static int numElem=0;

		public DateTimePickerFormat Format {
			get;
			set;
		}
		public DateTime Value {
			get;
			set;
		}


		public DateTimePicker ():base(){
			this.Name="DateTimePicker"+DateTimePicker.numElem.ToString();
			System.Windows.Forms.DateTimePicker dtPic = new System.Windows.Forms.DateTimePicker();
			this.Size=dtPic.Size;
			this.Format=dtPic.Format;
			this.Value=dtPic.Value;
		}

		public override Element CopyElem (){
			var dtPic = new WinformsGenerator.DateTimePicker();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.DateTimePicker).GetProperties()) {
				prop.SetValue(dtPic,prop.GetValue(this,null),null);
			}
			return dtPic;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.DateTimePicker dtPic = new System.Windows.Forms.DateTimePicker();
			dtPic.Name = this.Name;
			dtPic.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				dtPic.Anchor = this.Anchor;
			}
			dtPic.Dock=this.Dock;
			dtPic.Size=this.Size;
			dtPic.BackColor=this.BackColor;

			dtPic.Format = this.Format;
			dtPic.Value=this.Value;

			return dtPic;
		}

		public override Element NewElem ()
		{
			var dtPic = this.CopyElem();
			dtPic.Name="DateTimePicker"+DateTimePicker.numElem.ToString();
			DateTimePicker.numElem++;
			return dtPic;
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = base.GenerateDataGrid ();
			string[] row = { "Format"};
			dataGridView.Rows.Add (row);


			var combo=new DataGridViewComboBoxCell();
			foreach(DateTimePickerFormat i in Enum.GetValues(typeof(DateTimePickerFormat))){
				combo.Items.Add(i.ToString());
			}
			combo.Value = this.Format.ToString();
			dataGridView.Rows [dataGridView.Rows.Count-1].Cells [dataGridView.Columns.Count-1]=combo;

			string[] row1 = { "Year",this.Value.Year.ToString()};
			dataGridView.Rows.Add (row1);
			string[] row2 = { "Month",this.Value.Month.ToString()};
			dataGridView.Rows.Add (row2);
			String[] row3 = { "Day",this.Value.Day.ToString()};
			dataGridView.Rows.Add (row3);
			string[] row4 = { "Hour",this.Value.Hour.ToString()};
			dataGridView.Rows.Add (row4);
			string[] row5 = { "Minute",this.Value.Minute.ToString()};
			dataGridView.Rows.Add (row5);
			String[] row6 = { "Second",this.Value.Second.ToString()};
			dataGridView.Rows.Add (row6);

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				Boolean isNum;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[0].Value){
				case "Format":
					if(((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString()!=""){
						this.Format=(DateTimePickerFormat) Enum.Parse(typeof(DateTimePickerFormat),((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value.ToString());
					}
					break;
				case "Year":
					int year;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out year);
					if(isNum){
						this.Value = new DateTime(year,this.Value.Month,this.Value.Day,this.Value.Hour,this.Value.Minute,this.Value.Second);
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.Value.Year.ToString();
					}
					break;
				case "Month":
					int month;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out month);
					if(isNum){
						this.Value = new DateTime(this.Value.Year,month,this.Value.Day,this.Value.Hour,this.Value.Minute,this.Value.Second);
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.Value.Month.ToString();
					}
					break;
				case "Day":
					int day;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out day);
					if(isNum){
						this.Value = new DateTime(this.Value.Year,this.Value.Month,day,this.Value.Hour,this.Value.Minute,this.Value.Second);
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.Value.Day.ToString();
					}
					break;
				case "Hour":
					int hour;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out hour);
					if(isNum){
						this.Value = new DateTime(this.Value.Year,this.Value.Month,this.Value.Day,hour,this.Value.Minute,this.Value.Second);
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.Value.Hour.ToString();
					}
					break;
				case "Minute":
					int min;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out min);
					if(isNum){
						this.Value = new DateTime(this.Value.Year,this.Value.Month,this.Value.Day,this.Value.Hour,min,this.Value.Second);
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.Value.Minute.ToString();
					}
					break;
				case "Second":
					int sec;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value, out sec);
					if(isNum){
						this.Value = new DateTime(this.Value.Year,this.Value.Month,this.Value.Day,this.Value.Hour,this.Value.Minute,sec);
					}else{
						((System.Windows.Forms.DataGridView)sender).Rows[y].Cells[1].Value=this.Value.Second.ToString();
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


