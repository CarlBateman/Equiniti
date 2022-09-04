using System.ComponentModel.DataAnnotations;

namespace Equiniti.Models
{
	public class Transaction
	{
		//public long Id { get; set; }
		[Key]
		public string? Id { get; set; }
		public int ApplicationID { get; set; }
		public string? Type { get; set; }
		public string? Summary { get; set; }
		public decimal Amount { get; set; }
		public DateTime PostingDate { get; set; }
		public bool IsCleared { get; set; }
		public DateTime? ClearedDate { get; set; }
	}
}
