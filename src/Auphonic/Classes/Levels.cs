namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents processing statistics of input and output files.
	/// </summary>
	public class Levels
	{
		#region Public Properties
		/// <summary>
		/// Gets the input files processing statistics.
		/// </summary>
		public Level Input { get; internal set; }

		/// <summary>
		/// Gets the output files processing statistics.
		/// </summary>
		public Level Output { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Levels"/> class.
		/// </summary>
		public Levels()
		{
		}
		#endregion
	}
}