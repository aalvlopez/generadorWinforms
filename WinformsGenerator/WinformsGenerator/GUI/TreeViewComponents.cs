using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsGenerator
{
	public class TreeViewComponents:TreeView
	{
		public TreeViewComponents(){
			this.BuildTree();
		}
		private  void BuildTree()
	    {
			this.Dock= DockStyle.Fill;
			this.Nodes.Add ("EII");
			this.Nodes.Add ("Capitulos");
			this.Name = "Elementos";
		}

	}
}

