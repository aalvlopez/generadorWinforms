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
			
            this.panelWork = (Panel)App.formulario.DrawElement();

			this.panelWork.SuspendLayout();
			this.SuspendLayout();
			
            


			this.Controls.Add(this.panelWork);

			this.panelWork.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		
        public Panel panelWork;
	}
}

