using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsImport
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

		public Grid ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.TableLayoutPanel table = new System.Windows.Forms.TableLayoutPanel();
			table.Name=this.Name;
			table.ColumnCount=this.NumColumns;
			table.RowCount=this.NumRows;
			table.Size=this.Size;
			table.Location=new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				table.Anchor = this.Anchor;
			}
			table.Dock = this.Dock;
			table.BackColor=this.BackColor;
			for(int a = 0; a<table.RowCount;a++){
				table.RowStyles.Add(new RowStyle(SizeType.Percent,(100/table.RowCount)));
			}

			for(int b = 0; b<table.ColumnCount;b++){
				table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,(100/table.ColumnCount)));
			}

			int i=0;
			int j =0;
			foreach(Element e in this.elementos){
				table.Controls.Add(e.DrawElement(),i,j);
				if(i<table.ColumnCount-1){
					i++;
				}else{
					if(j<table.RowCount-1){
						j++;
						i=0;
					}
				}
			}
			return table;
			
		}
	}
}

