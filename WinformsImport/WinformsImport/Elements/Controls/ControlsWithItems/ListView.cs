using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;

namespace WinformsImport
{
	public class ListView:ControlItems
	{
		private static int numElem=0;
		public int NumColumns {
			get;
			set;
		}
		public List<String> Columns {
			get;
			set;
		}
		public bool CheckBoxes { 
			get;
			set;
		}
		public bool GridLines {
			get;
			set;
		}
		public View View {
			get;
			set;
		}

		public ListView ():base(){}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.ListView listV = new System.Windows.Forms.ListView ();
			listV.Name = this.Name;
			listV.Location = new Point (this.Location.X, this.Location.Y);
			if (this.Anchor != AnchorStyles.None) {
				listV.Anchor = this.Anchor;
			}
			listV.Dock = this.Dock;
			listV.Size = this.Size;
			listV.BackColor = this.BackColor;

			
			listV.View = this.View;
			listV.GridLines = this.GridLines;
			if (this.View != View.Tile) {
				listV.CheckBoxes = this.CheckBoxes;
			}
			for (int i=0; i<this.NumColumns; i++) {
				if (i <= this.Columns.Count - 1) {
					listV.Columns.Add (this.Columns [i], -2);
				} else {
					listV.Columns.Add ("Column" + i.ToString (), -2);
				}
			}
			foreach (Item item in this.items) {
				System.Windows.Forms.ListViewItem listItem = new System.Windows.Forms.ListViewItem (item.Text,-2);
				foreach (Item subitem in ((ItemAnidado)item).items) {
					listItem.SubItems.Add(subitem.Text);
				}
				
            	listV.Items.Add(listItem);
			}

			return listV;
		}
	}
}



