using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace WinformsGenerator
{
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

		public Element ()
		{
			this.Dock=DockStyle.Fill;
			this.Name=this.GetType().ToString();
			this.Id="0";
		}
		public Element (String id, DockStyle style, String name)
		{
			this.Dock=style;
			this.Name=name;
			this.Id=id;
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

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((DataGridView)sender).Rows[y].Cells[0].Value){
				case "Dock":
					this.Dock=(DockStyle) Enum.Parse(typeof(DockStyle),((DataGridView)sender).Rows[y].Cells[1].Value.ToString());
					break;
				case "Name":
					this.Name=((DataGridView)sender).Rows[y].Cells[1].Value.ToString();
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
	}
}

