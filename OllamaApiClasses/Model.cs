 using System;

namespace OllamaApiClasses
{
	// GET /api/tags response
	public struct Model
	{
		public string name { get; set; }
		public string model { get; set; }
		public DateTime modified_at { get; set; }
		public ulong size { get; set; }
		public string digest { get; set; }
		public ModelDetails details { get; set; }
	}
}
