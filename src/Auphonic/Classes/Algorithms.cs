namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Algorithms"/> class.
	/// </summary>
	public class Algorithms
	{
		#region Public Properties
		public bool Hipfilter { get; set; }

		public bool Normloudness { get; set; }

		public bool Denoise { get; set; }

		public bool Leveler { get; set; }

		public int Loudnesstarget { get; set; }

		public int Denoiseamount { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Algorithms"/> class.
		/// </summary>
		public Algorithms()
		{
		}
		#endregion
	}
}