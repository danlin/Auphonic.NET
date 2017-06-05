namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents credits informations used for a production.
	/// </summary>
	public class Credits
	{
		#region Public Properties
		/// <summary>
		/// Gets the combined credits (onetime and recurring).
		/// </summary>
		public decimal Combined { get; internal set; }

		/// <summary>
		/// Gets the onetime credits.
		/// </summary>
		public decimal Onetime { get; internal set; }

		/// <summary>
		/// Gets the recurring credits.
		/// </summary>
		public decimal Recurring { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Credits"/> class.
		/// </summary>
		public Credits()
		{
		}
		#endregion
	}
}