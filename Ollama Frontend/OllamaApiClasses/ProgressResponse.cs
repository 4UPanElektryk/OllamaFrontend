using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_Frontend
{
    class ProgressResponse
    {
        public string status { get; set; }
        public string digest { get; set; }
        public ulong? total { get; set; }
		public ulong? completed { get; set; }

	}
}
