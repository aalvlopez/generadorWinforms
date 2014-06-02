using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class WorkSpace:Panel
	{
		public WorkSpace ()
		{
			this.InitializeComponent();
		}

		private void InitializeComponent(){
			
            this.panelWork = new Panel();

			this.panelWork.SuspendLayout();
			this.SuspendLayout();
			
            // 
            // panelWork
            // 
            this.panelWork.BackColor = SystemColors.ActiveCaption;
            this.panelWork.Name = "panel2";
            this.panelWork.Size = new Size(500, 372);


			this.Controls.Add(this.panelWork);

			this.panelWork.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		
        public Panel panelWork;
	}
}

