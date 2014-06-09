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
            this.panelWork = (Panel)Controller.Draw();
			this.panelWork.SuspendLayout();
			this.SuspendLayout();
			this.BackColor=Color.DarkGray;
			this.Controls.Add(this.panelWork);
			this.panelWork.ResumeLayout(false);
			this.HScroll=true;
			this.VScroll=true;
			this.ResumeLayout(false);
		}

        public Panel panelWork;
	}
}

