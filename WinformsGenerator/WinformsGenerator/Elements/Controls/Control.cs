using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public abstract class Control:Element
	{
		public String Text {
			get;
			set;
		}
		public Control ():base()
		{
			this.Text="PRUEBA";
		}
		public Control (String id, DockStyle style, String name,String text):base(id, style, name){
			this.Text=text;
		}
		public override void GetTreeNode (TreeNode node,ContextMenuStrip menu)
		{
			TreeNode node2=node.Nodes.Add (this.Name);

			menu.
			node2.ContextMenuStrip = menu;
			node2.Tag=this;
		}

		public override DataGridView GenerateDataGrid ()
		{
			DataGridView dataGridView= base.GenerateDataGrid();
			string[] row = { "Text", this.Text };
			dataGridView.Rows.Add (row);

			dataGridView.CellEndEdit+=delegate(object sender, DataGridViewCellEventArgs e) {

				int y = ((DataGridViewCell)((DataGridView)sender).SelectedCells[0]).RowIndex;
				switch((String)((DataGridView)sender).Rows[y].Cells[0].Value){
				case "Text":
					this.Text=((DataGridView)sender).Rows[y].Cells[1].Value.ToString();
					break;
				default:
					break;
				}
				MainWindow.panelTreeView.RefreshTreeView();
				MainWindow.ReDraw((Panel)App.formulario.DrawElement());
			};

			return dataGridView;
		}

		public override abstract System.Windows.Forms.Control DrawElement ();
	}
}

