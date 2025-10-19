using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			AllocConsole();

			//1) Создаём источник данных
			int[] arr = { 3, 5, 8, 13, 21 };

			//2) Определяем query expression (возвращает коллекцию IEnumerable)
			IEnumerable<int> FibonacciQuery =
				from i in arr
				where i > 10
				orderby i descending
				select i;

			//3) Выполнение запроса
			foreach(int i in FibonacciQuery)
			{
				Console.WriteLine($"{i}\t");
			}
			Console.WriteLine();

			///////////
			//Immediate queries:
			Console.WriteLine((from i in arr select i).Count());
			Console.WriteLine((from i in arr select i).Sum());
			List<int> i_list = (from i in arr select i).ToList();
		}
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();
	}
}
