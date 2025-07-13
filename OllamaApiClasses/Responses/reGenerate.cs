using System;

namespace OllamaApiClasses.Responses
{
	public struct reGenerate
	{
		// always returned
		public string model { get; set; }
		public DateTime created_at { get; set; }
		public string response { get; set; }
		public bool done { get; set; }

		// returned when stream finishes or when stream is false
		public string done_reason { get; set; }
		public int[] context { get; set; }
		public long? total_duration { get; set; } // in nanoseconds
		public long? load_duration { get; set; } // in nanoseconds
		public int? prompt_eval_count { get; set; }
		public long? prompt_eval_duration { get; set; } // in nanoseconds
		public int? eval_count { get; set; }
		public long? eval_duration { get; set; } // in nanoseconds
	}
}
