using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class WorkSpace
	{
		public WorkSpace ()
		{
			this.InitializeComponent();
		}

		private void InitializeComponent(){
			this.workPanel = new Panel();
			this.workPanel.SuspendLayout();
			this.workPanel.BackColor = Color.White;
			this.workPanel.Dock = DockStyle.Fill;

			this.constructionPanel = new Panel();
			this.constructionPanel.SuspendLayout();
			this.constructionPanel.Dock = DockStyle.None;
			this.constructionPanel.MinimumSize = new Size(500,500);
			this.constructionPanel.BackColor = Color.Black;
			this.constructionPanel.Location = this.workPanel.Location;

			this.workPanel.Controls.Add(this.constructionPanel);
			this.workPanel.ResumeLayout(false);
			this.constructionPanel.ResumeLayout(false);
		

		}
		public Panel workPanel;
		public Panel constructionPanel;
	}
}

