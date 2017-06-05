namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a chapter marker.
	/// </summary>
	public class Chapter
	{
		#region Public Properties
		/// <summary>
		/// Gets or sets an (optional) image with visual information, e.g. slides or photos. The
		/// image will be shown in podcast players while listening to the chapter, or exported to
		/// video output files.
		/// </summary>
		public string Image { get; set; }

		/// <summary>
		/// Gets or sets the start of the chapter as timestring (in HH:MM:SS.mmm), relative to the
		/// main input file. <strong>Important:</strong> if you have an additional intro or use
		/// <see cref="Production.CutStart"/>, its length is <strong>NOT included</strong> here.
		/// </summary>
		/// <remarks>
		/// Enter chapter start time in HH:MM:SS.mmm format (examples: 00:02:35.500, 1:30, 3:25.5).
		/// </remarks>
		public string Start { get; set; }

		/// <summary>
		/// Gets the start of the chapter as timestring (in HH:MM:SS.mmm), relative to output
		/// files. <strong>Important:</strong> if you have an additional intro or use
		/// <see cref="Production.CutStart"/>, its length <strong>is included</strong> here.
		/// </summary>
		public string StartOutput { get; internal set; }

		/// <summary>
		/// Gets the start of the chapter in seconds, relative to output files.
		/// <strong>Important:</strong> if you have an additional intro or use
		/// <see cref="Production.CutStart"/>, its length <strong>is included</strong> here.
		/// </summary>
		public decimal StartOutputSec { get; internal set; }

		/// <summary>
		/// Gets or sets the start of the current chapter in seconds, relative to the main input
		/// file. <strong>Important:</strong> if you have an additional intro or use
		/// <see cref="Production.CutStart"/>, its length is <strong>NOT included</strong> here.
		/// </summary>
		public decimal StartSec { get; internal set; }

		/// <summary>
		/// Gets or sets a (optional) title of the chapter. Audio players show chapter titles for
		/// quick navigation in audio files.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets an (optional) URL with further information about the chapter.
		/// </summary>
		public string Url { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Chapter"/> class.
		/// </summary>
		public Chapter()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Chapter"/> class.
		/// </summary>
		/// <param name="start">Start time of the chapter as timestring (in HH:MM:SS.mmm, e.g.
		/// 00:02:35.500, 1:30, 3:25.5).</param>
		/// <param name="title">Title of the chapter.</param>
		public Chapter(string start, string title)
			: this(start, title, null, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Chapter"/> class.
		/// </summary>
		/// <param name="start">Start time of the chapter as timestring (in HH:MM:SS.mmm, e.g.
		/// 00:02:35.500, 1:30, 3:25.5).</param>
		/// <param name="title">Title of the chapter.</param>
		/// <param name="url">URL with further information about the chapter.</param>
		/// <param name="image">Image with visual information about the chapter.</param>
		public Chapter(string start, string title, string url, string image)
		{
			Start = start;
			Title = title;
			Url = url;
			Image = image;
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return Title;
		}
		#endregion
	}
}