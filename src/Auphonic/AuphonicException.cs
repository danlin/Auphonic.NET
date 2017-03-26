using System;

namespace AuphonicNet
{
	/// <summary>
	/// Represents errors that occur during application execution.
	/// </summary>
	public class AuphonicException : Exception
	{
		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public string ErrorCode { get; }

		/// <summary>
		/// 
		/// </summary>
		public string ErrorMessage { get; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="AuphonicException"/> class with a specified error message.
		/// </summary>
		/// <param name="errorCode"></param>
		/// <param name="errorMessage"></param>
		public AuphonicException(string errorCode, string errorMessage)
			: base(errorMessage)
		{
			ErrorCode = errorCode;
			ErrorMessage = errorMessage;
		}
		#endregion
	}
}