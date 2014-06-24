using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

namespace WinformsGenerator
{
	public class GroupBox:Container
	{
		private static int numElem=0; 
		public GroupBox ():base(){
			this.Name="GroupBox"+GroupBox.numElem.ToString();
			System.Windows.Forms.GroupBox group = new System.Windows.Forms.GroupBox();
			this.Size=group.Size;
			this.Dock = DockStyle.None;
		}


		public override Element CopyElem ()
		{
			var group = new WinformsGenerator.GroupBox ();
			foreach (PropertyInfo prop in typeof(WinformsGenerator.GroupBox).GetProperties()) {
				prop.SetValue (group, prop.GetValue (this, null), null);
			}
			foreach (Element e in this.elementos) {
				group.AddElem(e.CopyElem());
			}
			return group;
		}

		public override void AddElem (Element elem)
		{
			this.elementos.Add(elem);
		}

		public override System.Windows.Forms.Control DrawElement (){
			System.Windows.Forms.GroupBox group = new System.Windows.Forms.GroupBox();
			group.Name=this.Name;
			group.Size=this.Size;
			group.Location=new Point(this.Location.X,this.Location.Y);
			if (this.Anchor!=AnchorStyles.None) {
				group.Anchor = this.Anchor;
			}
			group.Dock = this.Dock;
			group.BackColor=this.BackColor;
			group.Text = this.Text;

			foreach(Element e in this.elementos){
				group.Controls.Add(e.DrawElement());
			}
			return group;
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid (){
			return base.GenerateDataGrid ();
		}
		public override Element NewElem ()
		{
			var border = this.CopyElem ();
			border.Name = "GroupBox" + GroupBox.numElem.ToString ();
			GroupBox.numElem++;
			return border;
		}
	}
}

