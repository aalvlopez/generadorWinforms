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
			
            WorkSpace.panelWork = new Panel();

			WorkSpace.panelWork.SuspendLayout();
			this.SuspendLayout();
			
            // 
            // panelWork
            // 
            WorkSpace.panelWork.BackColor = SystemColors.ActiveCaption;
            WorkSpace.panelWork.Name = "panel2";
            WorkSpace.panelWork.Size = new Size(500, 372);


			this.Controls.Add(WorkSpace.panelWork);

			WorkSpace.panelWork.ResumeLayout(false);
			this.ResumeLayout(false);
		}


		
        public static Panel panelWork;
	}
}

