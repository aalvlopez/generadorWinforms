using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

namespace WinformsGenerator
{
	public class TreeViewComponents:Panel
	{
		public TreeViewComponents(){
			this.InitializeComponent();
		}

		private void InitializeComponent ()
		{
			this.contextMenuElement = new ElementContextMenu ();
			this.contextMenuItem = new ItemContextMenu();
			this.treeView1 = new System.Windows.Forms.TreeView ();
			this.contextMenuElement.SuspendLayout ();
			this.SuspendLayout ();

// 
            // treeView1
            // 
            this.treeView1.Dock = DockStyle.Fill;
            this.treeView1.Name = "treeView1";
			this.BuildTreeView();
            this.treeView1.Size = new Size(124, 317);
            this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect+=delegate(object sender , TreeViewEventArgs e){
				if(this.treeView1.SelectedNode.Tag.GetType().Equals(typeof(WinformsGenerator.Form))||this.treeView1.SelectedNode.Tag.GetType().IsSubclassOf(typeof(WinformsGenerator.Item))){
					Controller.GetWindow().DisableCopy();
					Controller.GetWindow().DisableCut();
					if(this.treeView1.SelectedNode.Tag.GetType().Equals(typeof(WinformsGenerator.Form))){
						Controller.GetWindow().DisableDelete();
					}else{
						Controller.GetWindow().EnableDelete();
					}
				}else{
					Controller.GetWindow().EnableCopy();
					Controller.GetWindow().EnableCut();
					Controller.GetWindow().EnableDelete();
				}
				if(this.treeView1.SelectedNode.Tag.GetType().IsSubclassOf(typeof(WinformsGenerator.Control))||this.treeView1.SelectedNode.Tag.GetType().IsSubclassOf(typeof(WinformsGenerator.Item))){
					Controller.GetWindow().DisablePaste();
				}else{
					if(this.nodeCopied!=null){
						Controller.GetWindow().EnablePaste();
					}
				}

			};

			this.treeView1.NodeMouseClick+=delegate(object sender, TreeNodeMouseClickEventArgs e){
				this.treeView1.SelectedNode=e.Node;
				if(e.Node.Tag.GetType().IsSubclassOf(typeof(WinformsGenerator.Item))){
					Controller.SelectItem((Item)e.Node.Tag);
				}else{
					Controller.SelectElement((Element)e.Node.Tag);
				}
				if(e.Button==MouseButtons.Right){
					if(this.treeView1.SelectedNode.Tag.GetType ().IsSubclassOf (typeof(WinformsGenerator.ItemAnidado))) {
						this.contextMenuItem.EnableAddItem();
					}else{
						this.contextMenuItem.DisableAddItem();
					}
					if (this.treeView1.SelectedNode.Tag.GetType ().IsSubclassOf (typeof(WinformsGenerator.ControlItems))) {
						this.contextMenuElement.EnableAddItem();
					}else{
						this.contextMenuElement.DisableAddItem();
					}
					if (this.treeView1.SelectedNode.Tag.GetType ().IsSubclassOf (typeof(WinformsGenerator.Control))) {
						this.contextMenuElement.DisableAdd();
						this.contextMenuElement.DisablePaste();
					} else {
						this.contextMenuElement.EnableAdd();
						if (this.nodeCopied != null) {
							this.contextMenuElement.EnablePaste();
						}
					}
					if (this.treeView1.SelectedNode.Tag.GetType () == typeof(WinformsGenerator.Form)) {
						this.contextMenuElement.DisableRemove();
						this.contextMenuElement.DisableCopy();
						this.contextMenuElement.DisableCut();
					} else {
						this.contextMenuElement.EnableRemove();
						this.contextMenuElement.EnableCopy();
						this.contextMenuElement.EnableCut();
					}
					if(this.treeView1.SelectedNode.Tag.GetType().Equals(typeof(WinformsGenerator.TabControl))){
						this.contextMenuElement.DisableAdd();
						this.contextMenuElement.VisibleAddPanel();
					}else{
						this.contextMenuElement.OcultAddPanel();
					}
				}
			};

			this.treeView1.KeyDown+=delegate(object sender, KeyEventArgs e){
				if(!this.treeView1.SelectedNode.Tag.GetType().IsSubclassOf(typeof(WinformsGenerator.Item))){
					if(!this.treeView1.SelectedNode.Tag.GetType().Equals(typeof(WinformsGenerator.Form))){
						if(e.Control && (e.KeyCode == Keys.C||e.KeyCode == Keys.X)){
							this.Copy();
						}
					}
					if(e.Control && e.KeyCode == Keys.V&&this.nodeCopied!=null){
						this.Paste();
					}
				}
				if(!this.treeView1.SelectedNode.Tag.GetType().Equals(typeof(WinformsGenerator.Form))){
					if((e.Control && e.KeyCode == Keys.X)||e.KeyCode==Keys.Delete){
						this.Remove();
					}
				}

			};

            this.Controls.Add(this.treeView1);
            this.contextMenuElement.ResumeLayout(false);
			this.ResumeLayout(false);
		}


		public void RefreshTreeView(){
			this.treeView1.BeginUpdate();
			this.treeView1.Nodes.Clear(); 
			this.BuildTreeView();
			this.treeView1.EndUpdate();
			this.treeView1.Controls.Clear();
		}

		private void BuildTreeView ()
		{
			TreeNode node;
			node = this.treeView1.Nodes.Add (Controller.GetForm().Name);
			node.Tag=Controller.GetForm();
			this.treeView1.SelectedNode=this.treeView1.Nodes[0];
			foreach (Element elem in Controller.GetForm().elementos) {
				elem.GetTreeNode(node,this.contextMenuElement,this.contextMenuItem);
			}
			node.ContextMenuStrip = this.contextMenuElement;
            node.ExpandAll(); 
		}

		//
		//Acciones
		//
		public void Copy(){
			this.nodeCopied=this.treeView1.SelectedNode;
			this.contextMenuElement.EnablePaste();
			Controller.GetWindow().EnablePaste();
		}

		public void Paste ()
		{
			Controller.AddElemnt (((Element)this.nodeCopied.Tag).CopyElem ());
			this.nodeCopied.Tag=((Element)this.nodeCopied.Tag).CopyElem();
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		public void Remove ()
		{
			if(this.treeView1.SelectedNode.Tag.GetType().IsSubclassOf(typeof(WinformsGenerator.Item))){
				Controller.RemoveItem();
			}else{
				Controller.RemoveElement();
			}
			this.RefreshTreeView();
		}

		public TreeNode GetSelectedNode(){
			return this.treeView1.SelectedNode;
		}

		public System.Windows.Forms.TreeView treeView1;
        private ElementContextMenu contextMenuElement;
		private ItemContextMenu contextMenuItem;

		public System.Windows.Forms.TreeNode nodeCopied;

	}
}

