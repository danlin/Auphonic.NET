using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Statistics"/> class.
	/// </summary>
	public class Statistics
	{
		#region Public Properties
		public Levels Levels { get; set; }

		public List<MusicSpeech> MusicSpeech { get; set; }

		public List<NoiseHumReduction> NoiseHumReduction { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Statistics"/> class.
		/// </summary>
		public Statistics()
		{
		}
		#endregion
	}
}