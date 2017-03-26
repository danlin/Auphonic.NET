using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Info"/> class.
	/// </summary>
	public class Info
	{
		#region Public Properties
		public Dictionary<string, OutputFile> OutputFiles { get; set; }

		public Dictionary<string, ServiceType> ServiceTypes { get; set; }

		public Dictionary<string, string> ProductionStatus { get; set; }

		public Dictionary<string, Algorithm> Algorithms { get; set; }

		public Dictionary<string, List<string>> FileEndings { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Info"/> class.
		/// </summary>
		public Info()
		{
		}
		#endregion
	}
}