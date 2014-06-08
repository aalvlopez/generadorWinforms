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

		public static void init ()
		{
			 Controller.formulario= new WinformsGenerator.Form();
			Controller.window = new MainWindow();
		}
		public static void SelectItem (Element elemento)
		{
			Controller.window.GenerateDataGrid(elemento.GenerateDataGrid(),elemento.EventDataGrid());
		}

		public static void addElemnt (Element elemento, Container parent)
		{
			parent.AddElem(elemento);
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		public static void RemoveElement (Element elemento, Container parent){
			parent.RemoveElem(elemento);
			Controller.window.ReDraw((Panel)Controller.formulario.DrawElement());
		}

		public static WinformsGenerator.Form GetForm ()
		{
			return Controller.formulario;
		}

		public static void RefreshTreeView ()
		{
			Controller.window.panelTreeView.RefreshTreeView ();
		}

		public static MainWindow GetWindow ()
		{
			return Controller.window;
		}
		public static System.Windows.Forms.Panel Draw(){
			return (Panel) Controller.formulario.DrawElement();
		}

		public static void ReDraw ()
		{
			Controller.window.ReDraw(Controller.Draw());
		}

		public static void NuevoForm ()
		{
			Controller.formulario = new WinformsGenerator.Form();
			Controller.ReDraw();
			Controller.RefreshTreeView();
		}

		public static void CopyNode ()
		{
			Controller.window.panelTreeView.Copy ();
			Controller.window.EnablePaste();
		}
		public static void PasteNode ()
		{
			Controller.window.panelTreeView.Paste ();
		}

		public static void RemoveNode ()
		{
			Controller.window.panelTreeView.Remove ();
		}

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

		public static void SaveAsFile ()
		{
			System.Xml.Serialization.XmlSerializer writer = 
				new System.Xml.Serialization.XmlSerializer(typeof(WinformsGenerator.Element));

	        System.IO.StreamWriter file = new System.IO.StreamWriter(Controller.saveFile);
	        writer.Serialize(file,(Element) Controller.GetForm());
	        file.Close();
		}

		public static void Test ()
		{

			Controller.OpenFile();
			Controller.testForm=Controller.formulario.DrawForm();
			Controller.testForm.Show();
		}

		public static void StopTest ()
		{
			Controller.testForm.Close();
		}
		public static void SetSaveFile(String fileName){
			Controller.saveFile=fileName;
		}
		public static String GetSaveFile(){
			return Controller.saveFile;
		}

	}
}