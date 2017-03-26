namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Option"/> class.
	/// </summary>
	public class Option
	{
		#region Public Properties
		public string DisplayName { get; set; }

		public string Value { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Option"/> class.
		/// </summary>
		public Option()
		{
		}
		#endregion

		#region Public Override Methods
		public override string ToString()
		{
			return $"{DisplayName}={Value}";
		}
		#endregion
	}
}