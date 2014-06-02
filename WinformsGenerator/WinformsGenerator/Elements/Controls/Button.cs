using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Button:Control
	{
		public Button ():base()
		{
		}
		public Button (String id, DockStyle style, String name, String text):base(id, style, name,text){
		}

		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
			btn.Dock=this.Dock;
			btn.Name=this.Name;
			btn.Text=this.Text;

			return btn;
		}
		public override DataGridView GenerateDataGrid ()
		{
			return base.GenerateDataGrid();
		}
	}
}

