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
			//

            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Name = "dataGridView1";



			this.Controls.Add(this.dataGridView1);
			this.ResumeLayout(false);
		}
		
        public DataGridView dataGridView1;
	}
}

