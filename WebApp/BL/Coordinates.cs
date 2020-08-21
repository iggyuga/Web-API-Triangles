using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApp.BL.Common;

namespace WebApp.BL
{
	public class Coordinates
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
}
