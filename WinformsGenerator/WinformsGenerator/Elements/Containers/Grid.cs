using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Grid:Container
	{
		public int NumColumns {
			get;
			set;
		}
		public int NumRows {
			get;
			set;
		}
		public Grid ():base()
		{
			this.NumColumns=1;
			this.NumRows=1;
		}
		public Grid (String id, DockStyle style, String name, int numCols, int numRows):base(id, style, name){
			this.NumColumns=numCols;
			this.NumRows=numRows;
		}

		public override void drawElement (){
			System.Windows.Forms.TableLayoutPanel table = new System.Windows.Forms.TableLayoutPanel();
			table.Dock = this.Dock;
			table.Name=this.Name;
			table.ColumnCount=this.NumColumns;
			table.RowCount=this.NumRows;
			
			WorkSpace.panelWork.SuspendLayout();
			WorkSpace.panelWork.Controls.Add(table);
			WorkSpace.panelWork.ResumeLayout(false);
		}
	}
}

