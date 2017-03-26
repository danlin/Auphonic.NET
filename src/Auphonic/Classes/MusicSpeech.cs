namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="MusicSpeech"/> class.
	/// </summary>
	public class MusicSpeech
	{
		#region Public Properties
		public string Label { get; set; }

		public string Start { get; set; }

		public decimal StartSec { get; set; }

		public string Stop { get; set; }

		public decimal StopSec { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="MusicSpeech"/> class.
		/// </summary>
		public MusicSpeech()
		{
		}
		#endregion
	}
}