namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="InputFile"/> class.
	/// </summary>
	public class MultiInputFile
	{
		#region Public Properties
		public int InputChannels { get; set; }

		public string Service { get; set; }

		public int InputSamplerate { get; set; }

		public string InputFile { get; set; }

		public int InputBitrate { get; set; }

		public string InputFiletype { get; set; }

		public string Type { get; set; }

		public string Id { get; set; }

		public int Offset { get; set; }

		public decimal InputLength { get; set; }
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