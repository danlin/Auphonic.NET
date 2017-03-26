using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="OutgoingService"/> class.
	/// </summary>
	public class OutgoingService
	{
		#region Public Properties
		public string DisplayName { get; set; }

		public string Uuid { get; set; }

		public string Email { get; set; }

		public bool TransferSuccess { get; set; }

		public string ErrorMessage { get; set; }

		public bool Incomming { get; set; }

		public bool Outgoing { get; set; }

		public string ResultPage { get; set; }

		public List<string> ResultUrls { get; set; }

		public string Path { get; set; }

		public string Host { get; set; }

		public string Type { get; set; }

		public int Port { get; set; }

		public string BaseUrl { get; set; }

		public string Sharing { get; set; }

		public string TrackType { get; set; }

		public bool Downloadable { get; set; }

		public string Category { get; set; }

		public string Privacy { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="OutgoingService"/> class.
		/// </summary>
		public OutgoingService()
		{
		}
		#endregion
	}
}