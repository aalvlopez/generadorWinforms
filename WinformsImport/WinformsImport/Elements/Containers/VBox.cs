using System;
using System.Windows.Forms;

namespace WinformsImport
{
	public class VBox:Grid
	{
		public VBox ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			TableLayoutPanel table=(TableLayoutPanel) base.DrawElement();
			return table;
		}


	}
}

