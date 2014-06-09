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
			Controller.init();
            Application.SetCompatibleTextRenderingDefault(false);
			Controller.RefreshTreeView();
            Application.Run(Controller.GetWindow());
		}

		public static void OnClickApp ()
		{
			Console.WriteLine ("FUNCIONAA");
		}

	}
}

