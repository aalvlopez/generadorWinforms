using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class HBox:Grid
	{

		public HBox ():base()
		{
		}
		public HBox(String id, DockStyle style, String name, int numCols):base(id, style, name, numCols, 1){
			
		}
		public void addColumn ()
		{
			base.NumColumns++;
		}
	}
}

