using System;
using System.Collections.Generic;
using System.Text;

namespace OllamaApiClasses.Requests
{
	// POST /api/chat
	public class rqChat
	{
		// required
		public string model { get; set; }
		public ChatMessage messages { get; set; }
		public string tools { get; set; } // JSON string of tools, or null if no tools are used
		public bool stream { get; set; } = true; // default is false, set to true for streaming responses
		public bool think { get; set; } = false;
		public string format { get; set; }
		public string options { get; set; } // JSON string of options, or null if no options are used
		/// <summary>
		/// Time to keep model loaded after generation
		/// Default is 5 minutes, set to false to unload immediately.
		/// example: "5m" for 5 minutes, "1h" for 1 hour, "false" to unload immediately.
		/// </summary>
		public string keep_alive { get; set; }
	}
}
