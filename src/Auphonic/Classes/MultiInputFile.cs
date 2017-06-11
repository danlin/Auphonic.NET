namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a multi input file.
	/// </summary>
	public class MultiInputFile
	{
		#region Public Properties
		/// <summary>
		/// Gets or sets the audio algorithms settings.
		/// </summary>
		public Algorithms Algorithms { get; set; }

		/// <summary>
		/// Gets or sets the id of the input file.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Gets the input audio bitrate.
		/// </summary>
		public int InputBitrate { get; internal set; }

		/// <summary>
		/// Gets the channels of the input audio.
		/// </summary>
		public int InputChannels { get; internal set; }

		/// <summary>
		/// Gets or sets the filename of the input audio.
		/// </summary>
		public string InputFile { get; set; }

		/// <summary>
		/// Gets the file type of input audio.
		/// </summary>
		public string InputFiletype { get; internal set; }

		/// <summary>
		/// Gets the input audio length in seconds.
		/// </summary>
		public decimal InputLength { get; internal set; }

		/// <summary>
		/// Gets the input audio samplerate.
		/// </summary>
		public int InputSamplerate { get; internal set; }

		/// <summary>
		/// Gets or sets the offset of the input audio.
		/// </summary>
		public double Offset { get; set; }

		/// <summary>
		/// Gets or sets the service UUID.
		/// </summary>
		public string Service { get; set; }

		/// <summary>
		/// Gets or sets the type of the input audio.
		/// </summary>
		public string Type { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="InputFile"/> class.
		/// </summary>
		public MultiInputFile()
		{
		}
		#endregion
	}
}