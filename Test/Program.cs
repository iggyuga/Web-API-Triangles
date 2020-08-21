using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Test
{
	public class Common
	{
		public static bool isEven(int input)
		{
			return input % 2 == 0;
		}
	}
	public class Point
	{
		public int X { get; set; }

		public int Y { get; set; }

		public int Sum { get; set; }
		public Point() { }

		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
			this.Sum = this.X + this.Y;
		}


		public void Print()
		{
			Console.WriteLine($"{this.X}, {this.Y}");
		}

		public static bool CheckNearby(Point p1, Point p2)
		{
			if (Math.Abs(p1.X - p2.X) != Math.Abs(p1.Y - p2.Y) || p1.X - p2.X == 0 || p1.Y - p2.Y == 0)
			{
				return false;
			}
			return true;
		}

		private static string FindLetter(int yCoord)
		{
			string letter = "Z";
			switch (yCoord)
			{
				case 0:
					letter = "F";
					break;
				case 1:
					letter = "E";
					break;
				case 2:
					letter = "D";
					break;
				case 3:
					letter = "C";
					break;
				case 4:
					letter = "B";
					break;
				case 5:
					letter = "A";
					break;
			}

			return letter;
		}

		public static string GenerateCoordinate(Point p1, Point p2, Point p3)
		{

			// Check the sum of the coordinates (1,1) = 2, (1,2) = 3, (2,1) = 3 Odd
			// Check the sum of the coordinates (1,2) = 3, (1,1) = 2, (0,2) = 2 Even

			int value = -1;
			string letter = "Z";
			if (p1.Sum == p2.Sum)
			{
				// do something p3
				// if less than Sum then ODD
				if (p3.Sum < p1.Sum)
				{
					value = (p3.X * 2) + 1;
					letter = FindLetter(p3.Y);
				}
				// EVEN
				else
				{
					value = p3.X * 2;
					letter = FindLetter(p3.Y - 1);
				}
			}
			else if (p1.Sum == p3.Sum)
			{
				// do something p3
				// if less than Sum then ODD
				if (p2.Sum < p1.Sum)
				{
					value = (p2.X * 2) + 1;
					letter = FindLetter(p2.Y);
				}
				// EVEN
				else
				{
					value = p2.X * 2;
					letter = FindLetter(p2.Y - 1);
				}
			}
			else if (p2.Sum == p3.Sum)
			{
				// do something p1
				// if less than Sum then ODD
				if (p1.Sum < p2.Sum)
				{
					value = (p1.X * 2) + 1;
					letter = FindLetter(p1.Y);
				}
				// EVEN
				else
				{
					value = p1.X * 2;
					letter = FindLetter(p1.Y - 1);
				}
			}

			return $"{letter}{value}";
		}
	}

	public class Coords
	{
		public static IList<string> GenerateAllCoordsOfTriangle(string letter, int value)
		{
			IList<string> allCords = new List<string>();

			string rightAngleCoord = CalcRightAngleCoord(letter, value);
			allCords.Add(rightAngleCoord);
			IList<string> acuteAngleCoords = CalcAcuteAngleCoords(rightAngleCoord, value);
			foreach (var coord in acuteAngleCoords)
			{
				allCords.Add(coord);
			}

			return allCords;
		}

		private static IList<string> CalcAcuteAngleCoords(string coord, int value)
		{
			int x = int.Parse(coord.Split(',')[0]);
			int y = int.Parse(coord.Split(',')[1]);
			IList<string> coords = new List<string>();
			if (Common.isEven(value))
			{
				coords.Add($"{x - 1}, {y}");
				coords.Add($"{x}, {y - 1}");
			}
			else
			{
				coords.Add($"{x + 1}, {y}");
				coords.Add($"{x}, {y + 1}");
			}

			return coords;
		}

		private static string CalcRightAngleCoord(string letter, int value)
		{
			int yCoord = -1;
			int xCoord = -1;
			switch (letter)
			{
				case "A":
					yCoord = Common.isEven(value) ? 6 : 5;
					break;
				case "B":
					yCoord = Common.isEven(value) ? 5 : 4;
					break;
				case "C":
					yCoord = Common.isEven(value) ? 4 : 3;
					break;
				case "D":
					yCoord = Common.isEven(value) ? 3 : 2;
					break;
				case "E":
					yCoord = Common.isEven(value) ? 2 : 1;
					break;
				case "F":
					yCoord = Common.isEven(value) ? 1 : 0;
					break;
			}

			if (yCoord != -1)
			{
				xCoord = Common.isEven(value) ? value / 2 : (value - 1) / 2;
			}

			return $"{xCoord}, {yCoord}";
		}
	}
	public class Start
	{
		static void Main(string[] args)
		{
			IList<string> letters = new List<string> { "A", "B", "C", "D", "E", "F" };
			var input = Console.ReadLine();
			var letter = input.Substring(0,1).ToUpper();
			var value = int.Parse(input.Substring(1));
			//Console.WriteLine(letter);
			//Console.WriteLine(value);
			//Console.WriteLine(CalcRightAngleCoord(letter, value));

			var allCords = Coords.GenerateAllCoordsOfTriangle(letter, value);

			foreach (var c in allCords)
			{
				Console.WriteLine(c);
			}


			//Console.WriteLine("Enter in 3 points in order to return the coordinate (A12), (F3), etc...");

			//bool isValid = false;
			//Point p1, p2, p3;
			//while (!isValid)
			//{
			//	Console.WriteLine("Enter in X for Point 1");
			//	var x = Console.ReadLine();
			//	Console.WriteLine("Enter in Y for Point 1");
			//	var y = Console.ReadLine();
			//	p1 = new Point(int.Parse(x), int.Parse(y));

			//	Console.WriteLine("Enter in X for Point 2");
			//	x = Console.ReadLine();
			//	Console.WriteLine("Enter in Y for Point 2");
			//	y = Console.ReadLine();
			//	p2 = new Point(int.Parse(x), int.Parse(y));

			//	Console.WriteLine("Enter in X for Point 3");
			//	x = Console.ReadLine();
			//	Console.WriteLine("Enter in Y for Point 3");
			//	y = Console.ReadLine();
			//	p3 = new Point(int.Parse(x), int.Parse(y));

			//	isValid = Point.CheckNearby(p1, p2) && Point.CheckNearby(p2, p3) && Point.CheckNearby(p1, p3);

			//	if (!isValid)
			//	{
			//		Console.WriteLine("The coordinates you entered do not form a right triangle");
			//	}
			//}
			Point p1 = new Point(1, 1);
			Point p2 = new Point(1, 2);
			Point p3 = new Point(2, 1);


			string coord = Point.GenerateCoordinate(p1, p2, p3);

			Console.WriteLine(coord);

		}
	}
}
