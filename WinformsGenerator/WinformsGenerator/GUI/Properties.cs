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
			this.tab= new System.Windows.Forms.TabControl();
			this.page1 = new System.Windows.Forms.TabPage();
			this.page2 = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			
			this.page1.SuspendLayout();
			this.page2.SuspendLayout();
			this.tab.SuspendLayout();
			this.SuspendLayout();

			// 
          	// dataGridView1
			//
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Name = "dataGridView1";

			// 
          	// dataGridView2
			//
			this.dataGridView2.Dock = DockStyle.Fill;
            this.dataGridView2.Name = "dataGridView2";

			// 
          	// Tab
			//
			this.page1.Text = "Propietries";
			this.page1.Dock = DockStyle.Fill;
        	this.page1.TabIndex = 0;
			this.page1.Controls.Add(this.dataGridView1);
	
			this.page2.Text = "Events";
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
		
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DataGridView dataGridView2;
		public System.Windows.Forms.TabControl tab;
		public System.Windows.Forms.TabPage page1;
		public System.Windows.Forms.TabPage page2;
	}
}

