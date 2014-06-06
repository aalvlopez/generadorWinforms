using System;
using System.Windows.Forms;

namespace ProbandoLibreria
{
	public class Probando
	{
		public Probando ()
		{
		}
		public static void Main ()
		{
			Application.Run(WinformsImport.ImportWinform.OpenWinform("prueba.xml"));
		}
	}
}

