using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class Button:Control
	{
		public Button ():base(){
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
			this.Size=btn.Size;
		}



		public Button (Button b):base(b.Id,b.Dock,b.Name,b.Text,b.Size,b.Location){}

		public override Element CopyElem (){
			return new WinformsGenerator.Button(this);
		}

		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
			btn.Dock=this.Dock;
			btn.Name=this.Name;
			btn.Text=this.Text;
			btn.Size=this.Size;
			btn.Location=this.Location;
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

