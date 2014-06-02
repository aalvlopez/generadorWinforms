using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class VBox:Grid
	{

		public VBox ():base()
		{
		}
		public VBox(String id, DockStyle style, String name, int numRows):base(id, style, name, 1, numRows){
			
		}
		public void addRow ()
		{
			base.NumRows++;
		}

	}
}

