using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrianglesController : ControllerBase
	{

		[HttpGet]
		public string Get()
		{
			return "welcome to triangles";
		}

		// GET: api/<TrianglesController>
		// GET api/triangles/points?p1=1,1&p2=1,2&p3=2,1
		[HttpGet("points")]
		public string Points()
		{
			Point p1 = null, p2 = null, p3 = null;

			if (!string.IsNullOrEmpty(Request.Query["p1"]))
			{
				// Query string value is there so now use it
				var query = Request.Query["p1"];
				int x = int.Parse(query.ToString().Split(',')[0]);
				int y = int.Parse(query.ToString().Split(',')[1]);

				p1 = new Point(x, y);
			}
			else
			{
				RedirectToAction("error", "error");
			}

			if (!string.IsNullOrEmpty(Request.Query["p2"]))
			{
				// Query string value is there so now use it
				var query = Request.Query["p2"];
				int x = int.Parse(query.ToString().Split(',')[0]);
				int y = int.Parse(query.ToString().Split(',')[1]);

				p2 = new Point(x, y);
			}

			if (!string.IsNullOrEmpty(Request.Query["p3"]))
			{
				// Query string value is there so now use it
				var query = Request.Query["p3"];
				int x = int.Parse(query.ToString().Split(',')[0]);
				int y = int.Parse(query.ToString().Split(',')[1]);

				p3 = new Point(x, y);
			}

			string result = Point.GenerateCoordinate(p1, p2, p3);

			return result;
		}

		// GET api/<TrianglesController>/5
		// GET api/triangles/coordinate?battleship=e3

		[HttpGet("coordinate")]
		public IEnumerable<string> Coordinate()
		{
			string coordinate = string.Empty;
			if (!string.IsNullOrEmpty(Request.Query["battleship"]))
			{
				// Query string value is there so now use it
				coordinate = Request.Query["battleship"].ToString();

			}

			var letter = coordinate.Substring(0, 1).ToUpper();
			var value = int.Parse(coordinate.Substring(1));

			IList<string> result = Coordinates.GenerateAllCoordsOfTriangle(letter, value);

			return result;
		}

		////// POST api/<TrianglesController>
		////[HttpPost]
		////public void Post([FromBody] string value)
		////{
		////}

		////// PUT api/<TrianglesController>/5
		////[HttpPut("{id}")]
		////public void Put(int id, [FromBody] string value)
		////{
		////}

		////// DELETE api/<TrianglesController>/5
		////[HttpDelete("{id}")]
		////public void Delete(int id)
		////{
		////}
	}

	[ApiController]
	public class ErrorController : ControllerBase
	{
		[Route("/error")]
		public IActionResult Error() => Problem(statusCode: 400);
	}
}
