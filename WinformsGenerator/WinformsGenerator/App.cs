using System;
using System.Windows.Forms;

// Main class

namespace WinformsGenerator
{
	public class App
	{
		public static Formulario formulario = new Formulario();
		public static MainWindow m= new MainWindow();
		public static void Main ()
		{
			App.formulario.Name="Formulario";
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			MainWindow.panelTreeView.RefreshTreeView();
            Application.Run(App.m);

		}
	}
}

