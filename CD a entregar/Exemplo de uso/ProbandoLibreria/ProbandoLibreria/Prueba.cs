using System;
using System.Windows.Forms;

namespace ProbandoLibreria
{
	public static class  Prueba
	{
		public static void ShowName(Object sender, EventArgs e){
			System.Windows.Forms.TextBox name = (System.Windows.Forms.TextBox)((System.Windows.Forms.Form)((System.Windows.Forms.Button)sender).GetContainerControl ()).Controls.Find ("nametxt", true)[0];
			System.Windows.Forms.Label showName = (System.Windows.Forms.Label)((System.Windows.Forms.Form)((System.Windows.Forms.Button)sender).GetContainerControl ()).Controls.Find ("show", true)[0];
			showName.Text = name.Text;
		}
	}
}

