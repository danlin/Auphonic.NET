namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a noise and/or hum reduction segment.
	/// </summary>
	public class NoiseHumReduction
	{
		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public object Dehum { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public object Denoise { get; internal set; }

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
		/// Initializes a new instance of the <see cref="NoiseHumReduction"/> class.
		/// </summary>
		public NoiseHumReduction()
		{
		}
		#endregion
	}
}