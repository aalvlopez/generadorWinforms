using System;
using System.Drawing;
using System.Windows.Forms;

public class form : System.Windows.Forms.Form
{

	public form ()
	{
		CreateMyMainMenu();
	}

public void CreateMyMainMenu()
{
   // Create an empty MainMenu.
   MainMenu mainMenu1 = new MainMenu();

   MenuItem menuItem1 = new MenuItem();
   MenuItem menuItem2 = new MenuItem();

   menuItem1.Text = "File";
		menuItem1.MenuItems.Add(menuItem2);
   menuItem2.Text = "Edit";
   // Add two MenuItem objects to the MainMenu.
   mainMenu1.MenuItems.Add(menuItem1);
//   mainMenu1.MenuItems.Add(menuItem2);

   // Bind the MainMenu to Form1.
   Menu = mainMenu1;   
}
}