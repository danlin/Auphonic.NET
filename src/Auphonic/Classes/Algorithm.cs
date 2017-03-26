using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Algorithm"/> class.
	/// </summary>
	public class Algorithm
	{
		#region Public Properties
		public object DefaultValue { get; set; }

		public string DisplayName { get; set; }

		public string Description { get; set; }

		public string BelongsTo { get; set; }

		public string Type { get; set; }

		public List<Option> Options { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Algorithm"/> class.
		/// </summary>
		public Algorithm()
		{
		}
		#endregion

		#region Public Override Methods
		public override string ToString()
		{
			return DisplayName;
		}
		#endregion
	}
}