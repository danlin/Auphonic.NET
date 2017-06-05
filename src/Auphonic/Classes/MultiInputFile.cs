namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a multi input file.
	/// </summary>
	public class MultiInputFile
	{
		#region Public Properties
		public string Id { get; set; }

		public int InputBitrate { get; set; }

		public int InputChannels { get; set; }

		public string InputFile { get; set; }

		public string InputFiletype { get; set; }

		public decimal InputLength { get; set; }

		public int InputSamplerate { get; set; }

		public int Offset { get; set; }

		public string Service { get; set; }

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