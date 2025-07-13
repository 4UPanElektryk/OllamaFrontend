namespace OllamaApiClasses.Responses
{
	public struct reProgress
	{
		public string status { get; set; }
		public string digest { get; set; }
		public ulong? total { get; set; }
		public ulong? completed { get; set; }
	}
}
