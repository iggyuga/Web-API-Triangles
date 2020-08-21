using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.BL
{
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
}
