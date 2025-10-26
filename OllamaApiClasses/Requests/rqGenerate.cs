namespace OllamaApiClasses.Requests
{
	// POST /api/generate
	public struct rqGenerate
	{
		//required
		public string model { get; set; }
		// if prompt null model will just be loaded in memory
		public string prompt { get; set; }

		//optional
		/// <summary>
		/// Overrides the system prompt for the model.
		/// </summary>
		public string system { get; set; }
		public bool? stream { get; set; } // default is true
		public string template { get; set; }
		public string format { get; set; }
		public bool? raw { get; set; } // default is false
		/// <summary>
		/// Time to keep model loaded after generation
		/// Default is 5 minutes, set to false to unload immediately.
		/// example: "5m" for 5 minutes, "1h" for 1 hour, "false" to unload immediately.
		/// </summary>
		public string keep_alive { get; set; }
		public string suffix { get; set; }
		public string images { get; set; }
		public bool? think { get; set; } // default is false, set to true for thinking messages
		public string options { get; set; } // JSON string of options, or null if no options are used

	}
}
