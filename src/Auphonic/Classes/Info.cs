using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents combined informations for supported values.
	/// </summary>
	public class Info
	{
		#region Public Properties
		public Dictionary<string, AlgorithmType> AlgorithmTypes { get; internal set; }

		public Dictionary<string, List<string>> FileEndings { get; internal set; }

		public Dictionary<string, OutputFileType> OutputFileTypes { get; internal set; }

		public Dictionary<string, string> ProductionStatus { get; internal set; }

		public Dictionary<string, ServiceType> ServiceTypes { get; internal set; }
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