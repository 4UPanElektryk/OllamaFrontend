using System;
using System.Collections.Generic;
using System.Text;

namespace OllamaApiClasses.Requests
{
	// POST /api/create
	public struct rqCreate
	{
		//required
		public string model { get; set; } // name of the model to create

		//optional
		public string from { get; set; } // name of the model to copy from
		public Dictionary<string, string> files { get; set; }
		public Dictionary<string, string> adapters { get; set; }
		public string template { get; set; }
		public string license { get; set; }
		public string system { get; set; }
		public Dictionary<string, string> paramethers { get; set; }
		public ChatMessage[] messages { get; set; }
		public bool? stream { get; set; } // default is true, set to false to disable streaming
		public string quantize { get; set; }
	}
}
