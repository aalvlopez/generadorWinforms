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
		public Container ():base()
		{
			elementos=new List<Element>();
		}
		public Container(String id, DockStyle style, String name):base(id, style, name){
			elementos=new List<Element>();
		}
		public override void getTreeNode (TreeNode node,ContextMenuStrip menu)
		{
			TreeNode node2=node.Nodes.Add(this.Name);
			node2.Tag=this;
			foreach (Element elem in this.elementos) {
				elem.getTreeNode (node2,menu);
			}
			node2.ContextMenuStrip = menu;
			node2.ExpandAll ();
		}
		public void addElem(Element elem){
			this.elementos.Add(elem);
		}
		public override abstract void drawElement ();
	}
}
