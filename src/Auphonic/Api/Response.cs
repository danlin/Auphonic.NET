namespace AuphonicNet.Api
{
	/// <summary>
	/// Provides a <see cref="RequestResponse"/> class.
	/// </summary>
	internal class Response<T> where T : new()
	{
		#region Public Properties
		public T Data { get; set; }

		public string ErrorCode { get; set; }

		public string ErrorMessage { get; set; }

		public object FormErrors { get; set; }

		public int StatusCode { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="RequestResponse"/> class.
		/// </summary>
		public Response()
		{
		}
		#endregion
	}
}