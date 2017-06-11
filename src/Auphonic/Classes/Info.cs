using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents combined informations for supported values.
	/// </summary>
	public class Info
	{
		#region Public Properties
		/// <summary>
		/// Gets all supported audio algorithms.
		/// </summary>
		public Dictionary<string, AlgorithmType> AlgorithmTypes { get; internal set; }

		/// <summary>
		/// Gets all supported file endings.
		/// </summary>
		public Dictionary<string, List<string>> FileEndings { get; internal set; }

		/// <summary>
		/// Gets all supported output file formats.
		/// </summary>
		public Dictionary<string, OutputFileType> OutputFileTypes { get; internal set; }

		/// <summary>
		/// Gets all status codes of an audio production.
		/// </summary>
		public Dictionary<string, string> ProductionStatus { get; internal set; }

		/// <summary>
		/// Gets all supported external services.
		/// </summary>
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