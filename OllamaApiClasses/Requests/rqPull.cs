using System;
using System.Collections.Generic;
using System.Text;

namespace OllamaApiClasses.Requests
{
	// POST /api/pull
	public struct rqPull
	{
		public string name { get; set; }
		public bool? insecure { get; set; } // default is false, set to true to allow insecure connections
		public bool? stream { get; set; } // default is true, set to false to disable streaming
	}
}
