using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Level"/> class.
	/// </summary>
	public class Level
	{
		#region Public Properties
		public List<object> Lra { get; set; }

		public List<object> NoiseLevel { get; set; }

		public List<object> MaxMomentary { get; set; }

		public List<object> SignalLevel { get; set; }

		public List<object> Snr { get; set; }

		public List<object> MaxShortterm { get; set; }

		public List<object> Loudness { get; set; }

		public List<object> GainMin { get; set; }

		public List<object> Peak { get; set; }

		public List<object> GainMean { get; set; }

		public List<object> GainMax { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Level"/> class.
		/// </summary>
		public Level()
		{
		}
		#endregion
	}
}