using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public abstract class Container:Element
	{
		public List<Element> elementos;
		public Container ():base(){
			elementos=new List<Element>();
		}


		public override void GetTreeNode (TreeNode node,ContextMenuStrip menu,ContextMenuStrip menuItem){
			TreeNode node2=node.Nodes.Add(this.Name);
			node2.Tag=this;
			foreach (Element elem in this.elementos) {
				elem.GetTreeNode (node2,menu,menuItem);
			}
			node2.ContextMenuStrip = menu;
			node2.ExpandAll ();
		}

		public override System.Windows.Forms.DataGridView GenerateDataGrid (){
			return base.GenerateDataGrid ();
		}
		
		public void RemoveElem (Element elem){
			this.elementos.Remove(elem);
		}
		public abstract void AddElem(Element elem);
		public override abstract System.Windows.Forms.Control DrawElement ();
		public override abstract Element NewElem ();
	}
}

