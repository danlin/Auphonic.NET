using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a output file.
	/// </summary>
	public class OutputFile
	{
		#region Public Properties
		/// <summary>
		/// Gets or sets combined bitrate of all channels of the output file.
		/// </summary>
		public int Bitrate { get; set; }

		/// <summary>
		/// Gets a 128 bit MD5 checksum of the output file.
		/// </summary>
		public string Checksum { get; internal set; }

		/// <summary>
		/// Gets an HTTP URL on Auphonic servers to download the output file.
		/// </summary>
		public string DownloadUrl { get; internal set; }

		/// <summary>
		/// Gets or sets the filename extension of the output file.
		/// </summary>
		public string Ending { get; set; }

		/// <summary>
		/// Gets or sets the filename of the output file.
		/// </summary>
		public string Filename { get; set; }

		/// <summary>
		/// Gets or sets the format of the output file (e.g. mp3, m4a).
		/// </summary>
		public string Format { get; set; }

		/// <summary>
		/// Gets or sets a value that indicates whether to force a mono mixdown of the output file.
		/// </summary>
		public bool MonoMixdown { get; set; }

		/// <summary>
		/// Gets or sets referenced outgoing file transfer services.
		/// </summary>
		public List<OutgoingService> OutgoingServices { get; set; }

		/// <summary>
		/// Gets the size of the output file in bytes.
		/// </summary>
		public int Size { get; internal set; }

		/// <summary>
		/// Gets the size of the output file as human readable string.
		/// </summary>
		public string SizeString { get; internal set; }

		/// <summary>
		/// Gets or sets a value that indicates whether to split the audio in one file per chapter,
		/// if chapters are provided.
		/// </summary>
		/// <remarks>All filenames will be appended with the chapter number and packed into one ZIP
		/// output file.</remarks>
		public bool SplitOnChapters { get; set; }

		/// <summary>
		/// Gets or sets the suffix for filename generation of the output file.
		/// </summary>
		/// <value>Default <strong>null</strong> for automatic suffix.</value>
		public string Suffix { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="OutputFile"/> class.
		/// </summary>
		public OutputFile()
		{
		}
		#endregion
	}
}