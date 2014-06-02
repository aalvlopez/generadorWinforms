using System;
using System.Windows.Forms;

// Main class

namespace WinformsGenerator
{
	public class App
	{
		public static Formulario formulario = new Formulario();
		public static void Main ()
		{
			App.formulario.Name="Formulario";
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

		}
	}
}

