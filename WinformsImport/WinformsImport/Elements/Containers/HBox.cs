using System;
using System.Windows.Forms;

namespace WinformsImport
{
	public class HBox:Grid
	{
		public HBox ():base()
		{
			this.NumRows=1;
			this.NumColumns=0;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			TableLayoutPanel table=(TableLayoutPanel) base.DrawElement();
			return table;

		}
	}
}

