using System;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

// Main class

namespace WinformsGenerator
{
	 
	public class App
	{

		public static void Main ()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Controller.GetForm().Name="Formulario";
            Application.SetCompatibleTextRenderingDefault(false);
			Controller.RefreshTreeView();
            Application.Run(Controller.GetWindow());
		}

	}
}

