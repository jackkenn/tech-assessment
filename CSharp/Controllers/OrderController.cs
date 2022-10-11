using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private static Repos.OrderRepo orderRepo = new Repos.OrderRepo();
		
		[HttpGet]
		[Route("/Order/Get")]
		public string Get()
		{
			return JsonSerializer.Serialize(orderRepo.GetCustomersOrders());
		}

		[HttpPut]
		[Route("/Order/Create")]
		public void Create([FromBody] JsonElement s)
        {
			orderRepo.add(JsonSerializer.Deserialize<Models.OrderModel>(s.ToString()));
        }

		[HttpPut]
		[Route("/Order/Update")]
		public void Update([FromBody] JsonElement s)
        {
			orderRepo.update(JsonSerializer.Deserialize<Models.OrderModel>(s.ToString()));
        }

		[HttpDelete]
		[Route("/Order/Remove")]
		public void Remove([FromBody] JsonElement s)
        {
			orderRepo.remove(JsonSerializer.Deserialize<Models.OrderModel>(s.ToString()).id);
        }
	}
}
