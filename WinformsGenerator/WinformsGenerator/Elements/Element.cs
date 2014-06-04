using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinformsGenerator
{

	
	[XmlInclude(typeof(WinformsGenerator.Formulario))]
	[XmlInclude(typeof(WinformsGenerator.Control))]
	[XmlInclude(typeof(WinformsGenerator.Container))]
	[XmlInclude(typeof(WinformsGenerator.Button))]
	[XmlInclude(typeof(WinformsGenerator.TextBox))]
	[XmlInclude(typeof(WinformsGenerator.Label))]
	[XmlInclude(typeof(WinformsGenerator.HBox))]
	[XmlInclude(typeof(WinformsGenerator.VBox))]
	[XmlInclude(typeof(WinformsGenerator.Grid))]
	public abstract class Element
	{ 
		public string Id {
			get;
			set;
		}
		public DockStyle Dock {
			get;
			set;
		}
		public String Name {
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
		public Element ()
		{
			this.Dock=DockStyle.None;
			this.Name=this.GetType().ToString();
			this.Id="0";
			this.Location=new Point(0,0);
		}
		public Element (String id, DockStyle style, String name,Size size,Point location)
		{
			this.Dock=style;
			this.Name=name;
			this.Id=id;
			this.Location=location;
			this.Size= size;
		}


		public void ClickItem(){
			foreach(TreeNode t in MainWindow.panelTreeView.treeView1.Nodes){
				if((Element)t.Tag == this){
					MainWindow.panelTreeView.treeView1.SelectedNode=t;
					MainWindow.panelTreeView.treeView1.Select();
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
					MainWindow.panelTreeView.treeView1.SelectedNode=t;
					MainWindow.panelTreeView.treeView1.Select();
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
      		


			dataGridView.SuspendLayout();
			
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


			string[] row0 = { "Dock"};
			dataGridView.Rows.Add (row0);
			var combo=new DataGridViewComboBoxCell();
			combo.DataSource=Enum.GetValues(typeof(DockStyle));
			combo.Value = this.Dock;
			dataGridView.Rows [1].Cells [1]=combo;

			string[] row2 = { "Size.Height", this.Size.Height.ToString() };
			dataGridView.Rows.Add (row2);
			string[] row3 = { "Size.Width", this.Size.Width.ToString() };
			dataGridView.Rows.Add (row3);
			string[] row4 = { "Location.X", this.Location.X.ToString() };
			dataGridView.Rows.Add (row4);
			string[] row5 = { "Location.Y", this.Location.Y.ToString() };
			dataGridView.Rows.Add (row5);

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				bool isNum;
				int towEdited = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((DataGridView)sender).Rows[towEdited].Cells[0].Value){
				case "Dock":
					this.Dock=(DockStyle) Enum.Parse(typeof(DockStyle),((DataGridView)sender).Rows[towEdited].Cells[1].Value.ToString());
					break;
				case "Name":
					this.Name=((DataGridView)sender).Rows[towEdited].Cells[1].Value.ToString();
					break;
				case "Size.Height":
					int height;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[towEdited].Cells[1].Value, out height);
					if(isNum){
						this.Size=new Size(this.Size.Width,height);
					}
					break;
				case "Size.Width":
					int width;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[towEdited].Cells[1].Value, out width);
					if(isNum){
						this.Size=new Size(width,this.Size.Height);
					}
					break;
				case "Location.X":
					int x;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[towEdited].Cells[1].Value, out x);
					if(isNum){
						this.Location=new Point(x,this.Location.Y);
						Console.WriteLine(this.Location.ToString());
					}
					break;
				case "Location.Y":
					int y;
					isNum = int.TryParse((String)((DataGridView)sender).Rows[towEdited].Cells[1].Value, out y);
					if(isNum){
						this.Location=new Point(this.Location.X,y);
						Console.WriteLine(this.Location.ToString());
					}
					break;
				default:
					break;
				}
				MainWindow.panelTreeView.RefreshTreeView();
				MainWindow.ReDraw((Panel)App.formulario.DrawElement());
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

