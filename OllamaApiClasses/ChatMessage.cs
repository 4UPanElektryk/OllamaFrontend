using System;
using System.Collections.Generic;
using System.Text;

namespace OllamaApiClasses
{
	public struct ChatMessage
	{
		public string role { get; set; } // "user", "assistant", "system" or "tool"
		public string content { get; set; }
		public bool? thinking { get; set; } // default is false, set to true if the message is a thinking message
		public string[] images { get; set; }
		public string tool_calls { get; set; } // JSON string of tool calls, or null if no tool calls are made
		public string tool_name { get; set; }

	}
}
