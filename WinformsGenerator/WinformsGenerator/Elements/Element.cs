using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace WinformsGenerator
{

	
	[XmlInclude(typeof(WinformsGenerator.Form))]
	[XmlInclude(typeof(WinformsGenerator.Button))]
	[XmlInclude(typeof(WinformsGenerator.TextBox))]
	[XmlInclude(typeof(WinformsGenerator.Label))]
	[XmlInclude(typeof(WinformsGenerator.Border))]
	[XmlInclude(typeof(WinformsGenerator.HBox))]
	[XmlInclude(typeof(WinformsGenerator.VBox))]
	[XmlInclude(typeof(WinformsGenerator.Grid))]
	public abstract class Element
	{ 
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

		Color backColor = Color.FromArgb(255,255,255);

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


		public Element ()
		{
			
			this.Text="prueba";
			this.Dock=DockStyle.None;
			this.Name=this.GetType().ToString();
			this.Location=new Point(0,0);
			this.Anchor=AnchorStyles.None;
			this.BackColor=Color.Gray;
		}
		public Element (DockStyle style, String name,Size size,Point location,AnchorStyles anchor,String text,Color backColor)
		{
			
			this.Text=text;
			this.Dock=style;
			this.Name=name;
			this.Location=location;
			this.Size= size;
			this.Anchor=anchor;
			this.BackColor=backColor;
		}


		public void ClickItem(){
			foreach(TreeNode t in Controller.GetWindow().panelTreeView.treeView1.Nodes){
				if((Element)t.Tag == this){
					Controller.GetWindow().panelTreeView.treeView1.SelectedNode=t;
					Controller.GetWindow().panelTreeView.treeView1.Select();
					Controller.SelectItem((Element)t.Tag);
				}else{
					if(t.Nodes.Count>0){
						if(this.findTag(t)){
							break;
						}
					}
				}
			}
		}
		public Boolean findTag (TreeNode node)
		{
			foreach(TreeNode t in node.Nodes){
				if((Element)t.Tag==(this)){
					Controller.GetWindow().panelTreeView.treeView1.SelectedNode=t;
					Controller.GetWindow().panelTreeView.treeView1.Select();
					Controller.SelectItem((Element)t.Tag);
					return true;
				}else{
					if( this.findTag(t)){
						return true;
					}
				}
			}
			return false;
		}
		public virtual DataGridView GenerateDataGrid ()
		{
			DataGridView dataGridView = new DataGridView ();
      		


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

			string[] row1 = { "Name", this.Name };
			dataGridView.Rows.Add (row1);

			string[] row7 = {"Text",this.Text };
			dataGridView.Rows.Add (row7);

			if (!this.GetType ().Equals (typeof(WinformsGenerator.Form))) {
				string[] row0 = { "Dock"};
				dataGridView.Rows.Add (row0);
				var combo = new DataGridViewComboBoxCell ();
				combo.DataSource = Enum.GetValues (typeof(DockStyle));
				combo.Value = this.Dock;
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
				combo2.DataSource = xx;
				combo2.Value = this.Anchor;
				dataGridView.Rows [dataGridView.RowCount - 1].Cells [1] = combo2;
			}

			string[] row8 = { "BackColor"};
			dataGridView.Rows.Add (row8);
			((DataGridViewTextBoxCell)(dataGridView.Rows [dataGridView.Rows.Count - 1].Cells [1])).ReadOnly=true;
			((DataGridViewTextBoxCell)(dataGridView.Rows [dataGridView.Rows.Count - 1].Cells [1])).Style.BackColor=this.BackColor;

			dataGridView.CellMouseClick+=delegate(object sender, DataGridViewCellMouseEventArgs e){
				if((String)((DataGridView)sender).Rows[((DataGridView)sender).SelectedCells[0].RowIndex].Cells[0].Value=="BackColor"&&
				   ((DataGridView)sender).Rows[((DataGridView)sender).SelectedCells[0].RowIndex].Cells[1]==((DataGridView)sender).SelectedCells[0]){
					DataGridViewCell btn = (DataGridViewCell)((DataGridView)sender).SelectedCells[0];
					ColorDialog c = new ColorDialog();
					c.FullOpen=true;
					c.Color = btn.Style.BackColor;
					if (c.ShowDialog() == DialogResult.OK){
						btn.Style.BackColor=c.Color;
					}
					this.BackColor=btn.Style.BackColor;
					
					Controller.RefreshTreeView();
					Controller.ReDraw();
				}
			};
			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				bool isNum;
				int rowEdited = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((DataGridView)sender).Rows[rowEdited].Cells[0].Value){
				case "Dock":
					this.Dock=(DockStyle) Enum.Parse(typeof(DockStyle),((DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString());
					break;
				case "Name":
					this.Name=((DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString();
					break;
				case "Size.Height":
					int height;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[rowEdited].Cells[1].Value, out height);
					if(isNum){
						this.Size=new Size(this.Size.Width,height);
					}
					break;
				case "Size.Width":
					int width;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[rowEdited].Cells[1].Value, out width);
					if(isNum){
						this.Size=new Size(width,this.Size.Height);
					}
					break;
				case "Location.X":
					int x;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[rowEdited].Cells[1].Value, out x);
					if(isNum){
						this.Location=new Point(x,this.Location.Y);
						Console.WriteLine(this.Location.ToString());
					}
					break;
				case "Location.Y":
					int y;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[rowEdited].Cells[1].Value, out y);
					if(isNum){
						this.Location=new Point(this.Location.X,y);
						Console.WriteLine(this.Location.ToString());
					}
					break;
				case "Anchor":
					this.Anchor=(AnchorStyles) Enum.Parse(typeof(AnchorStyles),((DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString());
					Console.WriteLine(this.Anchor.ToString());
					break;
				case "Text":
					this.Text=((DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString();
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

		public abstract System.Windows.Forms.Control DrawElement();
		public abstract void GetTreeNode(TreeNode node,ContextMenuStrip menu);
		public abstract Element CopyElem();
	}
}

