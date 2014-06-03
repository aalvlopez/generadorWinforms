using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Button:Control
	{
		public Button ():base(){}

		public Button (String id, DockStyle style, String name, String text):base(id, style, name,text){
		}

		public Button (Button b):base(b.Id,b.Dock,b.Name,b.Text){}

		public override Element CopyElem (){
			return new WinformsGenerator.Button(this);
		}

		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
			btn.Dock=this.Dock;
			btn.Name=this.Name;
			btn.Text=this.Text;
			btn.Click+=delegate(object sender, EventArgs elementos){
				this.ClickItem();
			};
			return btn;
		}

		public override DataGridView GenerateDataGrid (){
			return base.GenerateDataGrid();
		}
	}
}

