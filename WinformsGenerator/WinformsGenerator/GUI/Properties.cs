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
			this.tab= new TabControl();
			this.page1 = new TabPage();
			this.page2 = new TabPage();
			this.dataGridView1 = new DataGridView();
			this.dataGridView2 = new DataGridView();
			
			this.page1.SuspendLayout();
			this.page2.SuspendLayout();
			this.tab.SuspendLayout();
			this.SuspendLayout();
			// 
          	// dataGridView1
			//

            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Name = "dataGridView1";

			this.dataGridView2.Dock = DockStyle.Fill;
            this.dataGridView2.Name = "dataGridView2";

			this.page1.Text = "Propiedades";
			this.page1.Dock = DockStyle.Fill;
        	this.page1.TabIndex = 0;
			this.page1.Controls.Add(this.dataGridView1);
	
			this.page2.Text = "Eventos";
			this.page2.Dock = DockStyle.Fill;
        	this.page2.TabIndex = 1;
			this.page2.Controls.Add(this.dataGridView2);

			this.tab.Dock=DockStyle.Fill;
			this.tab.Controls.Add(this.page1);
			this.tab.Controls.Add(this.page2);
			this.Controls.Add(this.tab);


			this.page1.ResumeLayout(false);
			this.page2.ResumeLayout(false);
			this.tab.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		
        public DataGridView dataGridView1;
        public DataGridView dataGridView2;
		public TabControl tab;
		public TabPage page1;
		public TabPage page2;
	}
}

