using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollama_Frontend
{
    class SizeConverter
    {
		static ulong kilo = 1024;
		static ulong mega = kilo * kilo;
		static ulong giga = mega * kilo;
		static ulong tera = giga * kilo;
		public static string getSize(ulong size)
		{
			string s = "";
			double kb = (double)size / kilo;
			double mb = kb / kilo;
			double gb = mb / kilo;
			double tb = gb / kilo;
			if (size < kilo)
			{
				s = size + " Bytes";
			}
			else if (size >= kilo && size < mega)
			{
				s = string.Format("{0:N2}", kb) + " KB";
			}
			else if (size >= mega && size < giga)
			{
				s = string.Format("{0:N2}", mb) + " MB";
			}
			else if (size >= giga && size < tera)
			{
				s = string.Format("{0:N2}", gb) + " GB";
			}
			else if (size >= tera)
			{
				s = string.Format("{0:N2}", tb) + " TB";
			}
			return s;
		}
	}
}
