using OllamaApiClasses;
using OllamaApiClasses.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ollama_Frontend
{
	public class ModelfileParser
	{
		public static rqCreate Parse(string[] lines, string ModelName)
		{
			string baseModel = null;
			string systemPrompt = null;
			string template = null;
			Dictionary<string, object> parameters = new Dictionary<string, object>();

			bool inMultiline = false;
			string currentDirective = null;
			StringBuilder multilineBuffer = new StringBuilder();
			List<ChatMessage> chatMessages = new List<ChatMessage>();

			foreach (string rawLine in lines)
			{
				string line = rawLine.Trim();

				if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
					continue;

				if (inMultiline)
				{
					if (line.EndsWith("\"\"\""))
					{
						multilineBuffer.AppendLine(line.Substring(0, line.Length - 3));
						string result = multilineBuffer.ToString().TrimEnd();

						if (currentDirective == "SYSTEM") systemPrompt = result;
						else if (currentDirective == "TEMPLATE") template = result;

						inMultiline = false;
						currentDirective = null;
						multilineBuffer.Clear();
					}
					else
					{
						multilineBuffer.AppendLine(line);
					}
					continue;
				}

				if (line.StartsWith("FROM ", StringComparison.OrdinalIgnoreCase))
				{
					baseModel = line.Substring(5).Trim();
				}
				else if (line.StartsWith("PARAMETER ", StringComparison.OrdinalIgnoreCase))
				{
					string[] parts = line.Substring(10).Trim().Split(new[] { ' ' }, 2);
					if (parts.Length == 2)
					{
						string key = parts[0];
						string value = parts[1];
						object parsed;

						if (double.TryParse(value, out double num))
							parsed = num;
						else if (bool.TryParse(value, out bool boolean))
							parsed = boolean;
						else
							parsed = value;

						parameters[key] = parsed;
					}
				}
				else if (line.StartsWith("SYSTEM ", StringComparison.OrdinalIgnoreCase))
				{
					string rest = line.Substring(7).Trim();
					if (rest.StartsWith("\""))
					{
						inMultiline = true;
						currentDirective = "SYSTEM";
						multilineBuffer.AppendLine(rest.Substring(3));
					}
					else
					{
						systemPrompt = Unquote(rest);
					}
				}
				else if (line.StartsWith("TEMPLATE ", StringComparison.OrdinalIgnoreCase))
				{
					string rest = line.Substring(9).Trim();
					if (rest.StartsWith("\""))
					{
						inMultiline = true;
						currentDirective = "TEMPLATE";
						multilineBuffer.AppendLine(rest.Substring(1));
					}
					else
					{
						template = Unquote(rest);
					}
				}
				else if (line.StartsWith("MESSAGE ", StringComparison.OrdinalIgnoreCase))
				{
					string rest = line.Substring(8).Trim();
					string[] parts = line.Substring(10).Trim().Split(new[] { ' ' }, 2);
					if (parts.Length == 2)
					{
						string role = parts[0];
						string message = rest.Substring(role.Length);
						chatMessages.Add(new ChatMessage
						{
							role = role.ToLower(),
							content = Unquote(message)
						});
					}
				}
			}

			if (baseModel == null)
			{
				Console.WriteLine("Missing required 'FROM' directive.");
				throw new ModelfileParseException("Missing required 'FROM' directive.");
			}

			rqCreate createRequest = new rqCreate
			{
				model = ModelName,
				from = baseModel
			};

			if (!string.IsNullOrEmpty(systemPrompt))
				createRequest.system = systemPrompt;
			if (!string.IsNullOrEmpty(template))
				createRequest.template = template;
			if (parameters.Count > 0)
				createRequest.paramethers = parameters.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());

			return createRequest;
		}
		static string Unquote(string input)
		{
			if (input.StartsWith("\"\"\"") && input.EndsWith("\"\"\"") && input.Length >= 6)
			{
				return input.Substring(3, input.Length - 6);
			}
			if (input.StartsWith("\"") && input.EndsWith("\"") && input.Length >= 2)
			{
				return input.Substring(1, input.Length - 2);
			}
			return input;
		}
	}
	[Serializable]
	public class ModelfileParseException : Exception
	{
		public ModelfileParseException(string message) : base(message) { }
		public ModelfileParseException(string message, Exception innerException) : base(message, innerException) { }
		public ModelfileParseException() { }
		public ModelfileParseException(string message, string filePath) : base($"{message} in file: {filePath}") { }
	}
}
