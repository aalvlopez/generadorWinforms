using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WinformsGenerator
{
	public static class Controller
	{

		private static WinformsGenerator.Form formulario;
		private static MainWindow window;
		private static String saveFile;
		private static System.Windows.Forms.Form testForm;


		//Inicia el controlador
		public static MainWindow init ()
		{
			Controller.formulario= new WinformsGenerator.Form();
			Controller.window = new MainWindow();
			Controller.RefreshTreeView();
			return Controller.window;
		}

		//Genera el DataGrid al selectionar un elemento
		public static void SelectElement (Element elemento)
		{
			Controller.window.GenerateDataGrid(elemento.GenerateDataGrid(),elemento.EventDataGrid());
		}
		
		//Genera el DataGrid al selectionar un item de un elemento
		public static void SelectItem (Item item)
		{
			Controller.window.GenerateDataGrid(item.GenerateDataGrid(),item.EventDataGrid());
		}

		//Añade un elemento a un container
		public static void AddElemnt (Element elemento)
		{
			((Container)Controller.window.panelTreeView.GetSelectedNode().Tag).AddElem(elemento);
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		//Añadir tab a un tabControl
		public static void AddPanel ()
		{
			((TabControl)Controller.window.panelTreeView.GetSelectedNode().Tag).AddElem(new TabPage());
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		//Añade un item a un controlador que admite items
		public static void AddItem ()
		{
			if (Controller.window.panelTreeView.GetSelectedNode ().Tag.GetType ().IsSubclassOf(typeof(WinformsGenerator.ControlItems))) {
				((ControlItems)Controller.window.panelTreeView.GetSelectedNode ().Tag).AddItem ();
			} else {
				((ItemAnidado)Controller.window.panelTreeView.GetSelectedNode ().Tag).AddItem ();
			}
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		//elimina un elemento del treeview
		public static void RemoveElement (){
			((Container)Controller.window.panelTreeView.GetSelectedNode().Parent.Tag).RemoveElem((Element)Controller.window.panelTreeView.GetSelectedNode().Tag);
			Controller.ReDraw();
		}

		//elimina un Item de un elemento del treeview
		public static void RemoveItem ()
		{
			if (Controller.window.panelTreeView.GetSelectedNode ().Parent.Tag.GetType ().IsSubclassOf (typeof(ItemAnidado))) {
				((ItemAnidado)Controller.window.panelTreeView.GetSelectedNode().Parent.Tag).RemoveItem((Item)Controller.window.panelTreeView.GetSelectedNode().Tag);
			} else {
				((ControlItems)Controller.window.panelTreeView.GetSelectedNode ().Parent.Tag).RemoveItem ((Item)Controller.window.panelTreeView.GetSelectedNode ().Tag);
			}
			Controller.ReDraw();
		}

		
		//redibuja el treeview
		public static void RefreshTreeView ()
		{
			Controller.window.panelTreeView.RefreshTreeView ();
		}


		//devuleve el formulario principal
		public static WinformsGenerator.Form GetForm ()
		{
			return Controller.formulario;
		}
		
		//devuelve la ventana principal
		public static MainWindow GetWindow ()
		{
			return Controller.window;
		}

		//devuelve el panel de trabajo
		public static System.Windows.Forms.Panel Draw(){
			try{
				return (Panel) Controller.formulario.DrawElement();
			}catch(NullReferenceException e){
				throw new Exception("Error openning the Xml file.", e);
			}
		}

		//redibuja el panel de trabajo
		public static void ReDraw ()
		{
			Controller.window.ReDraw(Controller.Draw());
		}

		//Crea nuevo formulario
		public static void NewForm ()
		{
			Controller.formulario = new WinformsGenerator.Form();
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		//Copia el nodo seleccionado del treeview
		public static void CopyNode ()
		{
			Controller.window.panelTreeView.Copy ();
			Controller.window.EnablePaste();
		}

		//pega el nodo seleccionado del treeview
		public static void PasteNode ()
		{
			Controller.window.panelTreeView.Paste ();
		}

		//elmina el nodo seleccionado del treeview
		public static void RemoveNode ()
		{
			Controller.window.panelTreeView.Remove ();
		}

		//abre un xml con un formulario
		public static void OpenFile ()
		{
			System.Xml.Serialization.XmlSerializer reader = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));
	        StreamReader file = new System.IO.StreamReader(Controller.saveFile);
			Controller.formulario= (WinformsGenerator.Form)reader.Deserialize(file);
	        file.Close();
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		//guarda el fomrulario creado en un xml en una ruta elegida
		public static void SaveAsFile ()
		{
			System.Xml.Serialization.XmlSerializer writer = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));
	        System.IO.StreamWriter file = new System.IO.StreamWriter(Controller.saveFile);
	        writer.Serialize(file,(Element) Controller.GetForm());
	        file.Close();
		}

		//Crea el formulario para probarlo
		public static void Test ()
		{
			Controller.OpenFile();
			Controller.testForm=Controller.formulario.DrawForm();
			Controller.testForm.FormClosed+=delegate(object sender , FormClosedEventArgs e){
				Controller.window.DisableStop();
				Controller.window.EnablePlay();
				Controller.ReSelectElement();
			};
			Controller.testForm.Show();
		}

		//Cierra el formulario de prueba
		public static void StopTest ()
		{
			Controller.testForm.Close();
		}

		//guarda la direccion de guardado del formulario en el fichero XML
		public static void SetSaveFile(String fileName){
			Controller.saveFile=fileName;
		}

		//devuleve la direccion del fichero en el que se guarda el formulario
		public static String GetSaveFile(){
			return Controller.saveFile;
		}

		//Busca el nodo del treeview al que etá asociado un elemento dado
		public static void ClickItem(Element e){
			foreach(TreeNode t in Controller.window.panelTreeView.treeView1.Nodes){
				if((Element)t.Tag == e){
					Controller.SelectElement((Element)t.Tag);
					Controller.window.panelTreeView.treeView1.SelectedNode=t;
				}else{
					if(t.Nodes.Count>0){
						if(Controller.findTag(t,e)){
							break;
						}
					}
				}
			}
		}
		public static Boolean findTag (TreeNode node,Element e)
		{
			foreach(TreeNode t in node.Nodes){
				if((Element)t.Tag==(e)){
					Controller.SelectElement((Element)t.Tag);
					Controller.window.panelTreeView.treeView1.SelectedNode=t;
					return true;
				}else{
					if( Controller.findTag(t,e)){
						return true;
					}
				}
			}
			return false;
		}

		//reselecciona un elemento
		public static void ReSelectElement(){

			SelectElement((Element)Controller.window.panelTreeView.treeView1.SelectedNode.Tag);
		}

	}
}