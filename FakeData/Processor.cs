using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcHacker.FakeData
{
	class Processor
	{
		/// <summary>
		/// Displayed CPU Name.
		/// </summary>
		public string Name { get; private set; }
		public string Description { get; private set; }
		/// <summary>
		/// The CPU displayed frequency.
		/// Unit: GHz
		/// </summary>
		public int Frequency { get; private set; }
		public string Identifier { get; private set; }
		public string VendorIdentifier { get; private set; }
		
		public Processor(string _name) 
		{
			Name = _name;
		}
	}
}
