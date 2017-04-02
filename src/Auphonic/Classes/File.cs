using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="File"/> class.
	/// </summary>
	public class File
	{
		#region Public Properties
		public string Format { get; set; }

		public string Ending { get; set; }

		public string Suffix { get; set; }

		public string Filename { get; set; }

		public bool SplitOnChapters { get; set; }

		public string Bitrate { get; set; }

		public bool MonoMixdown { get; set; }

		//public int Size { get; set; }

		public string SizeString { get; set; }

		public string DownloadUrl { get; set; }

		public List<OutgoingService> OutgoingServices { get; set; }

		public string Checksum { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="File"/> class.
		/// </summary>
		public File()
		{
		}
		#endregion
	}
}