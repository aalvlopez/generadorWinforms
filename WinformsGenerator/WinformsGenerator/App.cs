using System;
using System.Windows.Forms;
using System.Xml.Serialization;

// Main class

namespace WinformsGenerator
{
	 
	public class App
	{

		public static void Main ()
		{


			Controller.GetForm().Name="Formulario";
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Controller.RefreshTreeView();
            Application.Run(Controller.GetWindow());
		}
	}
}

