namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a registered external services.
	/// </summary>
	public class Service
	{
		#region Public Properties
		public string BaseUrl { get; internal set; }

		public string Bucket { get; internal set; }

		public string CannedAcl { get; internal set; }

		/// <summary>
		/// Gets the name of the service.
		/// </summary>
		public string DisplayName { get; internal set; }

		public string Email { get; internal set; }

		public string Host { get; internal set; }

		/// <summary>
		/// Gets a value that indicates whether the service can be used as incoming file transfer.
		/// </summary>
		public bool Incoming { get; internal set; }

		public string KeyPrefix { get; internal set; }

		public string LibsynDirectory { get; internal set; }

		public string LibsynShowSlug { get; internal set; }

		/// <summary>
		/// Gets a value that indicates whether the service can be used as outgoing file transfer.
		/// </summary>
		public bool Outgoing { get; internal set; }

		public string Path { get; internal set; }

		public string Permissions { get; internal set; }

		public string Port { get; internal set; }

		public string ProgramKeyword { get; internal set; }

		public string Type { get; internal set; }

		public string Url { get; internal set; }

		/// <summary>
		/// Gets the UUID of the service.
		/// </summary>
		public string Uuid { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Service"/> class.
		/// </summary>
		public Service()
		{
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return DisplayName;
		}
		#endregion
	}
}