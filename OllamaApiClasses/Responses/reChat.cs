using System;
using System.Collections.Generic;
using System.Text;

namespace OllamaApiClasses.Responses
{
	// POST /api/chat response
	public struct reChat
	{
		// always present even when stream
		public string model { get; set; }
		public DateTime created_at { get; set; }
		public bool done { get; set; }

		// when stream is false, this is present when stream is true and done this is null
		public ChatMessage? message { get; set; }

		// only present when done
		public long? total_duration { get; set; } // in nanoseconds
		public long? load_duration { get; set; } // in nanoseconds
		public int? prompt_eval_count { get; set; }
		public long? prompt_eval_duration { get; set; } // in nanoseconds
		public int? eval_count { get; set; }
		public long? eval_duration { get; set; } // in nanoseconds
	}
}
