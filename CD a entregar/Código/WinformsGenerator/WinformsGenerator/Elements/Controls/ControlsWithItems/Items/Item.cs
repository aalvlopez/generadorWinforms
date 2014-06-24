using System;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public abstract class Item
	{
		public String Name {
			get;
			set;
		}
		public String Text {
			get;
			set;
		}
		public Item ()
		{
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

			string[] row1 = { "Name", this.Name };
			dataGridView.Rows.Add (row1);
			string[] row2 = { "Text", this.Text };
			dataGridView.Rows.Add (row2);

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {
				int rowEdited = ((DataGridViewCell)((System.Windows.Forms.DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[0].Value){
				case "Name":
					this.Name=((System.Windows.Forms.DataGridView)sender).Rows[rowEdited].Cells[1].Value.ToString();
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
			System.Windows.Forms.DataGridView dataGridView = new System.Windows.Forms.DataGridView();
			dataGridView.Dock = DockStyle.Fill;
			return dataGridView;
		}

		public void GetTreeNode (TreeNode node, ContextMenuStrip menu)
		{
			TreeNode node2 = node.Nodes.Add (this.Name);
			node2.ContextMenuStrip = menu;
			node2.Tag = this;
			if (this.GetType ().IsSubclassOf (typeof(WinformsGenerator.ItemAnidado))) {
				foreach(Item i in ((ItemAnidado)this).items){
					i.GetTreeNode(node2,menu);
				}
			}
		}
		
		public abstract Item CopyItem ();
	}
}

