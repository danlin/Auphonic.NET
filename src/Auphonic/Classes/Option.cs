namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a option.
	/// </summary>
	public class Option
	{
		#region Public Properties
		/// <summary>
		/// Gets the name of the option.
		/// </summary>
		public string DisplayName { get; internal set; }

		/// <summary>
		/// Gets the value of the option.
		/// </summary>
		public string Value { get; internal set; }
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
		/// <inheritdoc/>
		public override string ToString()
		{
			return $"{DisplayName}={Value}";
		}
		#endregion
	}
}