using System;

namespace WinformsImport
{
	public static class ImportWinform
	{
		public static System.Windows.Forms.Form OpenWinform (String fileName)
		{
			return Controller.OpenFile (fileName);
		}
	}
}

