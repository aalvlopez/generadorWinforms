using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace WinformsImport
{
	public class DataGridView:ControlItems
	{
		public int NumColumns {
			get;
			set;
		}
		public List<String> Columns {
			get;
			set;
		}
		public DataGridView ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.DataGridView dataG = new System.Windows.Forms.DataGridView ();
			dataG.Name = this.Name;
			dataG.Location = new Point (this.Location.X, this.Location.Y);
			if (this.Anchor != AnchorStyles.None) {
				dataG.Anchor = this.Anchor;
			}
			dataG.Dock = this.Dock;
			dataG.Size = this.Size;
			dataG.BackColor = this.BackColor;
			dataG.ColumnCount = this.NumColumns;
			dataG.AllowUserToAddRows = false;
			for (int i=0; i<this.NumColumns; i++) {
				if (i <= this.Columns.Count - 1) {
					dataG.Columns [i].Name = this.Columns [i];
				} else {
					dataG.Columns [i].Name = "Column" + i.ToString ();
				}
			}
			if (this.NumColumns != 0) {
				foreach (Item item in this.items) {
					string[] stringSeparators = new string[] {","};
					string[] result;
					result = ((DataGridRow)item).Values.Split (stringSeparators, StringSplitOptions.None);
					if (result.Length <= this.NumColumns) {
						dataG.Rows.Add (result);
					} else {
						List<String> subresult = new List<string> ();
						for (int j=0; j<this.NumColumns; j++) {
							subresult.Add (result [j]);
						}
						dataG.Rows.Add (subresult.ToArray ());
					}
				}
				if (this.items.Count != 0) {
					dataG.RowCount = this.items.Count;
				
				}
			}
			return dataG;
		}
	}
}


