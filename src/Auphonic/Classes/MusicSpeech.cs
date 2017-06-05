namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a music or speech segment.
	/// </summary>
	public class MusicSpeech
	{
		#region Public Properties
		/// <summary>
		/// Gets the segment label (music, speech).
		/// </summary>
		public string Label { get; internal set; }

		/// <summary>
		/// Gets the start of the segment as timestring (in HH:MM:SS.mmm).
		/// </summary>
		public string Start { get; internal set; }

		/// <summary>
		/// Gets the start of the segment in seconds.
		/// </summary>
		public decimal StartSec { get; internal set; }

		/// <summary>
		/// Gets the end of the segment as timestring (in HH:MM:SS.mmm).
		/// </summary>
		public string Stop { get; internal set; }

		/// <summary>
		/// Gets the end of the segment in seconds.
		/// </summary>
		public decimal StopSec { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="MusicSpeech"/> class.
		/// </summary>
		public MusicSpeech()
		{
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return $"{Label} (Start={Start}; Stop={Stop})";
		}
		#endregion
	}
}