using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a output file type.
	/// </summary>
	public class OutputFileType
	{
		#region Public Properties
		/// <summary>
		/// Gets a list of bitrates supported by the output file; otherweise <strong>null</strong>.
		/// </summary>
		public List<string> Bitrates { get; internal set; }

		/// <summary>
		/// Gets a list of string representations of bitrates supported by the output file;
		/// otherwise <strong>null</strong>.
		/// </summary>
		public List<string> BitrateStrings { get; internal set; }

		/// <summary>
		/// Gets the default bitrate of the output file; otherwise <strong>null</strong>.
		/// </summary>
		public string DefaultBitrate { get; internal set; }

		/// <summary>
		/// Gets the name of the output file.
		/// </summary>
		public string DisplayName { get; internal set; }

		/// <summary>
		/// Gets a list of file endings supported by the output file; otherwise
		/// <strong>null</strong>.
		/// </summary>
		public List<string> Endings { get; internal set; }

		/// <summary>
		/// Gets the type of the output file.
		/// </summary>
		public string Type { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="OutputFileType"/> class.
		/// </summary>
		public OutputFileType()
		{
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return DisplayName;
		}
		#endregion
	}
}