namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Credits"/> class.
	/// </summary>
	public class Credits
	{
		#region Public Properties
		public decimal Onetime { get; set; }

		public decimal Recurring { get; set; }

		public decimal Combined { get; set; }
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