using System;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;
using System.Reflection;

// Main class

namespace WinformsGenerator
{
	 
	public class App
	{
		[STAThread]
		public static void Main ()
		{


			Application.Run(Controller.init());
		}

		public static void OnClickApp ()
		{
			Console.WriteLine ("FUNCIONAA");
		}

	}
}

