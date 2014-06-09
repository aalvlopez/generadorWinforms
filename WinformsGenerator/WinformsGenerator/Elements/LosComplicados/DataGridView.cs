using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class DataGridView:Control
	{
		private static int numElem=0;
		public DataGridView ():base(){
			this.Dock=DockStyle.Top;
			this.Name="DataGridView"+DataGridView.numElem.ToString();
			System.Windows.Forms.DataGridView dataG = new System.Windows.Forms.DataGridView();
			this.Size=dataG.Size;
		}

		public override Element CopyElem (){
			var dataG = new WinformsGenerator.DataGridView();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Element).GetProperties()) {
				prop.SetValue(dataG,prop.GetValue(this,null),null);
			}
			return dataG;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.DataGridView dataG = new System.Windows.Forms.DataGridView();
			dataG.Name = this.Name;
			dataG.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				dataG.Anchor = this.Anchor;
			}
			dataG.Dock=this.Dock;
			dataG.Size=this.Size;
			dataG.BackColor=this.BackColor;
			dataG.Click+=delegate(object sender, EventArgs elementos){
				Controller.ClickItem(this);
			};
			return dataG;
		}

		public override Element NewName ()
		{
			var dataG = this.CopyElem();
			dataG.Name="DataGridView"+DataGridView.numElem.ToString();
			DataGridView.numElem++;
			return dataG;
		}
	}
}


