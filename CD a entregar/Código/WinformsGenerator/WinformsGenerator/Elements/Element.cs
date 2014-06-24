using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace WinformsGenerator
{
	[XmlInclude(typeof(WinformsGenerator.Form))]

	[XmlInclude(typeof(WinformsGenerator.Button))]
	[XmlInclude(typeof(WinformsGenerator.TextBox))]
	[XmlInclude(typeof(WinformsGenerator.Label))]
	[XmlInclude(typeof(WinformsGenerator.CheckBox))]
	[XmlInclude(typeof(WinformsGenerator.RadioButton))]
	[XmlInclude(typeof(WinformsGenerator.DateTimePicker))]
	[XmlInclude(typeof(WinformsGenerator.MonthCalendar))]
	[XmlInclude(typeof(WinformsGenerator.PictureBox))]
	[XmlInclude(typeof(WinformsGenerator.ProgressBar))]
	[XmlInclude(typeof(WinformsGenerator.Splitter))]
	
	[XmlInclude(typeof(WinformsGenerator.ComboBox))]
	[XmlInclude(typeof(WinformsGenerator.ToolBar))]
	[XmlInclude(typeof(WinformsGenerator.StatusBar))]
	[XmlInclude(typeof(WinformsGenerator.MenuStrip))]
	[XmlInclude(typeof(WinformsGenerator.TreeView))]
	[XmlInclude(typeof(WinformsGenerator.DataGridView))]
	[XmlInclude(typeof(WinformsGenerator.ListView))]
	
	[XmlInclude(typeof(WinformsGenerator.ComboBoxItem))]
	[XmlInclude(typeof(WinformsGenerator.DataGridRow))]
	[XmlInclude(typeof(WinformsGenerator.ToolBarItem))]
	[XmlInclude(typeof(WinformsGenerator.StatusBarItem))]
	[XmlInclude(typeof(WinformsGenerator.MenuStripItem))]
	[XmlInclude(typeof(WinformsGenerator.TreeViewItem))]
	[XmlInclude(typeof(WinformsGenerator.ListViewItem))]
	[XmlInclude(typeof(WinformsGenerator.ListViewSubItem))]
	
	[XmlInclude(typeof(WinformsGenerator.GroupBox))]
	[XmlInclude(typeof(WinformsGenerator.Border))]
	[XmlInclude(typeof(WinformsGenerator.HBox))]
	[XmlInclude(typeof(WinformsGenerator.VBox))]
	[XmlInclude(typeof(WinformsGenerator.Grid))]
	[XmlInclude(typeof(WinformsGenerator.TabControl))]
	[XmlInclude(typeof(WinformsGenerator.TabPage))]

	public abstract class Element
	{ 
		public static ColorDialog c = new ColorDialog();
		public DockStyle Dock {
			get;
			set;
		}
		public String Name {
			get;
			set;
		}
		public String Text {
			get;
			set;
		}
		public Point Location{
			get;
			set;
		}
		public Size Size{
			get;
			set;
		}
		public AnchorStyles Anchor {
			get;
			set;
		}

		private Color backColor;
		[XmlIgnore]
		public Color BackColor 
		{
		    get { return backColor; }
		    set { backColor = value; }
		}
		[XmlElement("BackColor")]
		public string BackColorHtml
		{
		    get { return ColorTranslator.ToHtml(backColor); }
		    set { BackColor = ColorTranslator.FromHtml(value); }
		}

		//Eventos
		public string Click {
			get;
			set;
		}
		public string DoubleClick {
			get;
			set;
		}
		public string Enter {
			get;
			set;
		}
		public string GotFocus {
			get;
			set;
		}
		public string LostFocus {
			get;
			set;
		}
		public string Leave {
			get;
			set;
		}
		public string KeyDown {
			get;
			set;
		}
		public string KeyPress {
			get;
			set;
		}
		public string KeyUp {
			get;
			set;
		}
		public string MouseClick {
			get;
			set;
		}
		public string MouseDoubleClick {
			get;
			set;
		}
		public string MouseDown {
			get;
			set;
		}
		public string MouseEnter {
			get;
			set;
		}
		public string MouseLeave {
			get;
			set;
		}
		public string MouseHover {
			get;
			set;
		}
		public string MouseUp {
			get;
			set;
		}
		public string MouseWheel {
			get;
			set;
		}
		public string Resize {
			get;
			set;
		}

		public Element ()
		{
			
			this.Text="prueba";
			this.Dock=DockStyle.None;
			this.Location=new Point(0,0);
			this.Anchor=AnchorStyles.None;
			this.BackColor=Color.White;
			this.Click="";
			this.DoubleClick="";
			this.Enter="";
			this.GotFocus="";
			this.LostFocus="";
			this.Leave="";
			this.KeyDown="";
			this.KeyPress="";
			this.KeyUp="";
			this.MouseClick="";
			this.MouseDoubleClick="";
			this.MouseDown="";
			this.MouseEnter="";
			this.MouseLeave="";
			this.MouseHover="";
			this.MouseUp="";
			this.MouseWheel="";
			this.Resize="";
		
		}

		public virtual System.Windows.Forms.DataGridView GenerateDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = new System.Windows.Forms.DataGridView ();
			dataGridView.SuspendLayout ();
			dataGridView.ColumnCount = 2;

			dataGridView.Columns [0].Name = "Propiedad";
			dataGridView.Columns [1].Name = "Valor";
			dataGridView.Columns [0].ReadOnly = true;
			dataGridView.RowHeadersVisible = false;
			dataGridView.Columns [0].MinimumWidth = 50;
			dataGridView.Columns [1].MinimumWidth = 50;
			dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.AllowUserToOrderColumns = false;
			dataGridView.Columns [0].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView.Columns [1].SortMode = DataGridViewColumnSortMode.NotSortable;

			string[] row1 = { "Name", this.Name};
			dataGridView.Rows.Add (row1);
			if (!this.GetType ().Equals (typeof(WinformsGenerator.DateTimePicker))&&
			    !this.GetType ().Equals (typeof(WinformsGenerator.MonthCalendar))&&
				!this.GetType ().Equals (typeof(WinformsGenerator.Splitter))&&
				!this.GetType ().Equals (typeof(WinformsGenerator.DataGridView))&&
				!this.GetType ().Equals (typeof(WinformsGenerator.ListView))&&
				!this.GetType ().Equals (typeof(WinformsGenerator.MenuStrip))&&
				!this.GetType ().Equals (typeof(WinformsGenerator.ToolBar))&&
				!this.GetType ().Equals (typeof(WinformsGenerator.TreeView))&&
			    !this.GetType ().Equals (typeof(WinformsGenerator.ProgressBar))) {
				string[] row7 = {"Text",this.Text };
				dataGridView.Rows.Add (row7);
			}

			if (!this.GetType ().Equals (typeof(WinformsGenerator.Form))) {
				string[] row0 = { "Dock"};
				dataGridView.Rows.Add (row0);
				var combo = new DataGridViewComboBoxCell ();
				if(!this.GetType().Equals(typeof(WinformsGenerator.Splitter))){
					foreach(DockStyle i in Enum.GetValues(typeof(DockStyle))){
						combo.Items.Add(i.ToString());
					}
				}else{
					DockStyle[] x =(DockStyle[])Enum.GetValues(typeof(DockStyle));
					var l = new List<DockStyle>(x);
					l.Remove(DockStyle.None);
					foreach(DockStyle i in l){
						combo.Items.Add(i.ToString());
					}
				}
				combo.Value = this.Dock.ToString();
				dataGridView.Rows [dataGridView.Rows.Count-1].Cells [1] = combo;
			}

			string[] row2 = { "Size.Height", this.Size.Height.ToString () };
			dataGridView.Rows.Add (row2);

			string[] row3 = { "Size.Width", this.Size.Width.ToString () };
			dataGridView.Rows.Add (row3);

			if (!this.GetType ().Equals (typeof(WinformsGenerator.Form))) {
				string[] row4 = { "Location.X", this.Location.X.ToString () };
				dataGridView.Rows.Add (row4);

				string[] row5 = { "Location.Y", this.Location.Y.ToString () };
				dataGridView.Rows.Add (row5);

				string[] row6 = { "Anchor"};
				dataGridView.Rows.Add (row6);
				var combo2 = new DataGridViewComboBoxCell ();
				List<AnchorStyles> xx = new List<AnchorStyles> ();
				foreach (AnchorStyles style in (AnchorStyles[])Enum.GetValues(typeof(AnchorStyles))) {
					xx.Add (style);
					if (!style.Equals (AnchorStyles.None)) {
						foreach (AnchorStyles style2 in (AnchorStyles[])Enum.GetValues(typeof(AnchorStyles))) {
							if (!style2.Equals (style) && !style2.Equals (AnchorStyles.None) && !xx.Contains (style2 | style)) {
								xx.Add (style | style2);
							}
						}
					}
				}
				foreach(AnchorStyles i in xx){
						combo2.Items.Add(i.ToString());
					}
				combo2.Value = this.Anchor.ToString();
				dataGridView.Rows [dataGridView.RowCount - 1].Cells [1] = combo2;
			}

			string[] row8 = { "BackColor"};
			dataGridView.Rows.Add (row8);
			((DataGridViewTextBoxCell)(dataGridView.Rows [dataGridView.Rows.Count - 1].Cells [1])).ReadOnly=true;
			((DataGridViewTextBoxCell)(dataGridView.Rows [dataGridView.Rows.Count - 1].Cells [1])).Style.BackColor=this.BackColor;

			dataGridView.CellMouseClick+=delegate(object sender, DataGridViewCellMouseEventArgs e){
				if((String)((System.Windows.Forms.DataGridView)sender).Rows[((System.Windows.Forms.DataGridView)sender).SelectedCells[0].RowIndex].Cells[0].Value=="BackColor"&&
				   ((System.Windows.Forms.DataGridView)sender).Rows[((System.Windows.Forms.DataGridView)sender).SelectedCells[0].RowIndex].Cells[1]==((System.Windows.Forms.DataGridView)sender).SelectedCells[0]){
					DataGridViewCell btn = (DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0];
					Element.c.Color = btn.Style.BackColor;
					Element.c.FullOpen=true;
					if (Element.c.ShowDialog() == DialogResult.OK){
						btn.Style.BackColor=Element.c.Color;
					}
					this.BackColor=btn.Style.BackColor;
					
					Controller.RefreshTreeView();
					Controller.ReDraw();
				}
			};

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				bool isNum;
				int rowEdited = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[0].Value){
				case "Dock":
					Console.WriteLine("--");
					Console.WriteLine(((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString());
					Console.WriteLine("--");
					if(((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString()!=""){
						this.Dock=(DockStyle) Enum.Parse(typeof(DockStyle),(String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value);
					}
					break;
				case "Name":
					this.Name=((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString();
					break;
				case "Size.Height":
					int height;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value, out height);
					if(isNum){
						this.Size=new Size(this.Size.Width,height);
					}
					break;
				case "Size.Width":
					int width;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value, out width);
					if(isNum){
						this.Size=new Size(width,this.Size.Height);
					}
					break;
				case "Location.X":
					int x;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value, out x);
					if(isNum){
						this.Location=new Point(x,this.Location.Y);
					}
					break;
				case "Location.Y":
					int y;
					isNum = int.TryParse((String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value, out y);
					if(isNum){
						this.Location=new Point(this.Location.X,y);
					}
					break;
				case "Anchor":
					if(((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString()!=""){
						this.Anchor=(AnchorStyles) Enum.Parse(typeof(AnchorStyles),(String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value);
					}
					break;
				case "Text":
					this.Text=((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString();
					break;
				default:
					break;
				}
				Controller.RefreshTreeView();
				Controller.ReDraw();
			};

            dataGridView.Dock = DockStyle.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView1";
			dataGridView.ResumeLayout(false);

			return dataGridView;
		}

		public virtual System.Windows.Forms.DataGridView EventDataGrid ()
		{
			System.Windows.Forms.DataGridView dataGridView = new System.Windows.Forms.DataGridView ();
			dataGridView.SuspendLayout ();
			dataGridView.ColumnCount = 2;
			dataGridView.Columns [0].Name = "Propiedad";
			dataGridView.Columns [1].Name = "Valor";
			dataGridView.Columns [0].ReadOnly = true;
			dataGridView.RowHeadersVisible = false;
			dataGridView.Columns [0].MinimumWidth = 50;
			dataGridView.Columns [1].MinimumWidth = 50;
			dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.AllowUserToOrderColumns = false;
			dataGridView.Columns [0].SortMode = DataGridViewColumnSortMode.NotSortable;
			dataGridView.Columns [1].SortMode = DataGridViewColumnSortMode.NotSortable;

			foreach (PropertyInfo prop in typeof(WinformsGenerator.Element).GetProperties()) {
				if(prop.GetValue(this,null).GetType()==typeof(String)&& prop.Name!="Name"&& prop.Name!="Text"&& prop.Name!="BackColorHtml"){
					string[] row1 = { prop.Name,(string)prop.GetValue(this,null) };
					dataGridView.Rows.Add (row1);
				}
			}

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				int rowEdited = ((System.Windows.Forms.DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				PropertyInfo prop =(PropertyInfo) (typeof(WinformsGenerator.Element).GetProperty((String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[0].Value));
					prop.SetValue(this,(string)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString(),null);
			
			};

			dataGridView.Dock = DockStyle.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView1";
			dataGridView.ResumeLayout(false);
			return dataGridView;
		}

		public abstract System.Windows.Forms.Control DrawElement();
		public abstract void GetTreeNode(TreeNode node,ContextMenuStrip menu,ContextMenuStrip menuItem);
		public abstract Element NewElem();
		public abstract Element CopyElem();
	}
}

