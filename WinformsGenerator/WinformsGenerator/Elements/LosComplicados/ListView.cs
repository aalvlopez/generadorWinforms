using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinformsGenerator
{
	public class ListView:Control
	{
		private static int numElem=0;
		public ListView ():base(){
			this.Dock=DockStyle.Top;
			this.Name="ListView"+ListView.numElem.ToString();
			System.Windows.Forms.ListView listV = new System.Windows.Forms.ListView();
			this.Size=listV.Size;
		}

		public override Element CopyElem (){
			var listV = new WinformsGenerator.ListView();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.Element).GetProperties()) {
				prop.SetValue(listV,prop.GetValue(this,null),null);
			}
			return listV;
		}

		public override System.Windows.Forms.Control DrawElement ()
		{
			System.Windows.Forms.ListView listV = new System.Windows.Forms.ListView();
			listV.Name = this.Name;
			listV.Location = new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				listV.Anchor = this.Anchor;
			}
			listV.Dock=this.Dock;
			listV.Size=this.Size;
			listV.BackColor=this.BackColor;
			listV.Click+=delegate(object sender, EventArgs elementos){
				Controller.ClickItem(this);
			};
			return listV;
		}

		public override Element NewName ()
		{
			var listV = this.CopyElem();
			listV.Name="ListView"+ListView.numElem.ToString();
			ListView.numElem++;
			return listV;
		}
	}
}



