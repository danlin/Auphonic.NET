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
		/// Audio Bitrate (all channels):
		/// Set combined bitrate of all channels of your audio output file.
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
		/// Filename Ending, Extension:
		/// Filename extension of the current output file.
		/// </summary>
		public string Ending { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Filename { get; set; }

		/// <summary>
		/// Output File Format:
		/// </summary>
		public string Format { get; set; }

		/// <summary>
		/// Mono Mixdown:
		/// Click here to force a mono mixdown of the current output file.
		/// </summary>
		public bool MonoMixdown { get; set; }

		/// <summary>
		///  referenced outgoing file transfers
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
		/// Split on Chapters:
		/// If you have Chapter Marks, this option will split your audio in one file per chapter.
		/// All filenames will be appended with the chapter number and packed into one ZIP output file.
		/// </summary>
		public bool SplitOnChapters { get; set; }

		/// <summary>
		/// Filename Suffix (optional):
		/// Suffix for filename generation of the current output file, leave empty for automatic suffix! 
		/// </summary>
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