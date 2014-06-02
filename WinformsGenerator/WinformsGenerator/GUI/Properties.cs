using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace WinformsGenerator
{
	public class Properties:Panel
	{
		public Properties ()
		{
			this.InitializeComponent();
		}

		private void InitializeComponent(){

			this.dataGridView1 = new DataGridView();


			this.SuspendLayout();
			// 
            // dataGridView1
            this.dataGridView1.ColumnCount = 2;
            this.dataGridView1.Columns[0].Name = "Nombre";
            this.dataGridView1.Columns[1].Name = "Valor";
            this.dataGridView1.Columns[0].ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Columns[0].MinimumWidth = 50;
            this.dataGridView1.Columns[1].MinimumWidth = 50;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns=false;
			this.dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridView1.Columns[1].SortMode=DataGridViewColumnSortMode.NotSortable;
            string[] row0 = { "Dock"};
            this.dataGridView1.Rows.Add(row0);

            this.dataGridView1.Rows[0].Cells[1] = new DataGridViewComboBoxCell();
			((DataGridViewComboBoxCell)this.dataGridView1.Rows[0].Cells[1]).Items.Add("fill");
            ((DataGridViewComboBoxCell)this.dataGridView1.Rows[0].Cells[1]).Items.Add("center");
            ((DataGridViewComboBoxCell)this.dataGridView1.Rows[0].Cells[1]).Items.Add("left");
            ((DataGridViewComboBoxCell)this.dataGridView1.Rows[0].Cells[1]).Items.Add("right");
            ((DataGridViewComboBoxCell)this.dataGridView1.Rows[0].Cells[1]).Items.Add("top");
            ((DataGridViewComboBoxCell)this.dataGridView1.Rows[0].Cells[1]).Items.Add("bottom");
            ((DataGridViewComboBoxCell)this.dataGridView1.Rows[0].Cells[1]).Value = "fill";

            string[] row1 = { "Name", "Holaaa" };
            this.dataGridView1.Rows.Add(row1);


            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";



			this.Controls.Add(this.dataGridView1);
			this.ResumeLayout(false);
		}
		
        private DataGridView dataGridView1;
	}
}

