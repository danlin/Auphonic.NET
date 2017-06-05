using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a audio algorithm.
	/// </summary>
	public class AlgorithmType
	{
		#region Public 
		/// <summary>
		/// The name of the algorithm to which this algorithm belongs to.
		/// </summary>
		public string BelongsTo { get; internal set; }

		/// <summary>
		/// Gets the controls default value.
		/// </summary>
		public string DefaultValue { get; internal set; }

		/// <summary>
		/// Gets the description of the algorithm.
		/// </summary>
		public string Description { get; internal set; }

		/// <summary>
		/// Gets the name of the algorithm.
		/// </summary>
		public string DisplayName { get; internal set; }

		/// <summary>
		/// Gets a list of options for the algorithm; otherweise <strong>null</strong>.
		/// </summary>
		public List<Option> Options { get; internal set; }

		/// <summary>
		/// Gets the controls type for the algorithm (eg. checkbox, select).
		/// </summary>
		public string Type { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="AlgorithmType"/> class.
		/// </summary>
		public AlgorithmType()
		{
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return $"{DisplayName}={DefaultValue}";
		}
		#endregion
	}
}