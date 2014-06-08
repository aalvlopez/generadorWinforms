using System;
using System.Windows.Forms;

namespace ProbandoLibreria
{
	public static class  Prueba
	{
		public static void OnClick(Object sender, EventArgs e){
			Console.WriteLine (sender.GetType().ToString());
			Console.WriteLine("OnClick??");
		
		}
		public static void OnDouble(Object sender, EventArgs e){
			Console.WriteLine (sender.GetType().ToString());
			Console.WriteLine("OnDouble??");
		
		}
		public static void Enter(Object sender, EventArgs e){
			Console.WriteLine("Enter??");
		
		}
		public static void GotFocus(Object sender, EventArgs e){
			Console.WriteLine("GotFocus??");
		
		}
		public static void LostFocus(Object sender, EventArgs e){
			Console.WriteLine("LostFocus??");
		
		}
		public static void Leave(Object sender, EventArgs e){
			Console.WriteLine("Leave??");
		
		}
		public static void KeyDown(Object sender, EventArgs e){
			Console.WriteLine("KeyDown??");
		
		}
		public static void KeyPress(Object sender, EventArgs e){
			Console.WriteLine("KeyPress??");
		
		}
		public static void KeyUp(Object sender, EventArgs e){
			Console.WriteLine("KeyUp??");
		
		}

	}
}

