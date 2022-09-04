using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Equiniti.Models;
using Newtonsoft.Json;

namespace Equiniti.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TransactionController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<TransactionController> _logger;

		public TransactionController(ILogger<TransactionController> logger)
		{
			_logger = logger;
		}

		// GET api/Transactions
		[HttpGet(Name = "GetTransactions")]
		public IEnumerable<Transaction> Get()
		{
			Process currentProcess = Process.GetCurrentProcess();
			ProcessModule? mainModule = currentProcess.MainModule;
			string? aaa = mainModule != null ? mainModule.FileName : "";
			string? folder = Path.GetDirectoryName(aaa) + @"\TransactionData\";

			List<Transaction> items = new List<Transaction>();

			using (StreamReader r = new StreamReader(folder + "/sample-data.json"))
			{
				string json = r.ReadToEnd();
				items = JsonConvert.DeserializeObject<List<Transaction>>(json);

			}

			return items.ToArray();
		}

		// GET api/Transactions/
		[HttpGet("{id}")]
		public Transaction GetTransaction(string id)
		{
			Process currentProcess = Process.GetCurrentProcess();
			ProcessModule? mainModule = currentProcess.MainModule;
			string? aaa = mainModule != null ? mainModule.FileName : "";
			string? folder = Path.GetDirectoryName(aaa) + @"\TransactionData\";

			List<Transaction> items = new List<Transaction>();

			using (StreamReader r = new StreamReader(folder + "/sample-data.json"))
			{
				string json = r.ReadToEnd();
				items = JsonConvert.DeserializeObject<List<Transaction>>(json);

			}
			return items.Find(x => x.Id == id);

		}

	}
}