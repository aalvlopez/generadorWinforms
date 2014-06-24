using System;
using System.Reflection;
using System.Windows.Forms;

namespace WinformsImport
{
	public class StatusBarItem:Item
	{
		public int Width {
			get;
			set;
		}
		public StatusBarPanelBorderStyle BorderStyle {
			get;
			set;
		}
		public StatusBarItem ():base(){}
	}
}

