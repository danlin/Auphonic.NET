namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a registered external services.
	/// </summary>
	public class Service
	{
		#region Public Properties
		/// <summary>
		/// Gets the base url of the service.
		/// </summary>
		public string BaseUrl { get; internal set; }

		/// <summary>
		/// Gets the bucket name of the service.
		/// </summary>
		public string Bucket { get; internal set; }

		/// <summary>
		/// Gets the acl of the service.
		/// </summary>
		public string CannedAcl { get; internal set; }

		/// <summary>
		/// Gets the name of the service.
		/// </summary>
		public string DisplayName { get; internal set; }

		/// <summary>
		/// Gets the email of the service.
		/// </summary>
		public string Email { get; internal set; }

		/// <summary>
		/// Gets the host of the service.
		/// </summary>
		public string Host { get; internal set; }

		/// <summary>
		/// Gets a value that indicates whether the service can be used as incoming file transfer.
		/// </summary>
		public bool Incoming { get; internal set; }

		/// <summary>
		/// Gets the key prefix of the service.
		/// </summary>
		public string KeyPrefix { get; internal set; }

		/// <summary>
		/// Gets the Libsyn service directory.
		/// </summary>
		public string LibsynDirectory { get; internal set; }

		/// <summary>
		/// Gets the Libsyn service slug.
		/// </summary>
		public string LibsynShowSlug { get; internal set; }

		/// <summary>
		/// Gets a value that indicates whether the service can be used as outgoing file transfer.
		/// </summary>
		public bool Outgoing { get; internal set; }

		/// <summary>
		/// Gets the path of the service.
		/// </summary>
		public string Path { get; internal set; }

		/// <summary>
		/// Gets the permissions of the service.
		/// </summary>
		public string Permissions { get; internal set; }

		/// <summary>
		/// Gets the port of the service.
		/// </summary>
		public string Port { get; internal set; }

		/// <summary>
		/// Gets the program keyword of the service.
		/// </summary>
		public string ProgramKeyword { get; internal set; }

		/// <summary>
		/// Gets the Type of the service.
		/// </summary>
		public string Type { get; internal set; }

		/// <summary>
		/// Gets the URL of the service.
		/// </summary>
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