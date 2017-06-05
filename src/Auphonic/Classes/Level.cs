namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents processing statistics about audio levels, loudness, gain changes, peaks etc.
	/// </summary>
	public class Level
	{
		#region Public Properties
		/// <summary>
		/// Gets the leveler gain max.
		/// </summary>
		public object[] GainMax { get; internal set; }

		/// <summary>
		/// Gets the leveler gain mean.
		/// </summary>
		public object[] GainMean { get; internal set; }

		/// <summary>
		/// Gets the leveler gain min.
		/// </summary>
		public object[] GainMin { get; internal set; }

		/// <summary>
		/// Gets the programme loudness.
		/// </summary>
		public object[] Loudness { get; internal set; }

		/// <summary>
		/// Gets the loudness range (LRA).
		/// </summary>
		public object[] Lra { get; internal set; }

		/// <summary>
		/// Gets the max momentary loudness.
		/// </summary>
		public object[] MaxMomentary { get; internal set; }

		/// <summary>
		/// Gets the max shortterm loudness.
		/// </summary>
		public object[] MaxShortterm { get; internal set; }

		/// <summary>
		/// Gets the background level mean.
		/// </summary>
		public object[] NoiseLevel { get; internal set; }

		/// <summary>
		/// Gets the max peak level.
		/// </summary>
		public object[] Peak { get; internal set; }

		/// <summary>
		/// Gets the  signal level mean.
		/// </summary>
		public object[] SignalLevel { get; internal set; }

		/// <summary>
		/// Gets the SNR mean.
		/// </summary>
		public object[] Snr { get; internal set; }
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