namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="NoiseHumReduction"/> class.
	/// </summary>
	public class NoiseHumReduction
	{
		#region Public Properties
		public int Denoise { get; set; }

		public bool Dehum { get; set; }

		public string Start { get; set; }

		public decimal StartSec { get; set; }

		public string Stop { get; set; }

		public decimal StopSec { get; set; }
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