using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="OutputFile"/> class.
	/// </summary>
	public class OutputFile
	{
		#region Public Properties
		public string DisplayName { get; set; }

		public string Type { get; set; }

		public string DefaultBitrate { get; set; }

		public List<string> Bitrates { get; set; }

		public List<string> BitrateStrings { get; set; }

		public List<string> Endings { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="OutputFile"/> class.
		/// </summary>
		public OutputFile()
		{
		}
		#endregion

		#region Public Override Methods
		public override string ToString()
		{
			return DisplayName;
		}
		#endregion
	}
}