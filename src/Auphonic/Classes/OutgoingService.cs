﻿using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a outgoing service.
	/// </summary>
	public class OutgoingService
	{
		#region Public Properties
		/// <summary>
		/// Gets the base URL of the service.
		/// </summary>
		public string BaseUrl { get; internal set; }

		/// <summary>
		/// Gets the category of the service.
		/// </summary>
		public string Category { get; internal set; }

		/// <summary>
		/// Gets the name of the service.
		/// </summary>
		public string DisplayName { get; internal set; }

		/// <summary>
		/// Gets a value that indicates whether the output file is downloadable.
		/// </summary>
		public bool Downloadable { get; internal set; }

		/// <summary>
		/// Gets the email of the service.
		/// </summary>
		public string Email { get; internal set; }

		/// <summary>
		/// error message, if the file transfer was not successful
		/// </summary>
		public string ErrorMessage { get; internal set; }

		/// <summary>
		/// Gets the host of the service.
		/// </summary>
		public string Host { get; internal set; }

		/// <summary>
		/// Gets a value that indicates whether this is an incomming external service.
		/// </summary>
		public bool Incomming { get; internal set; }

		/// <summary>
		/// Gets a value that indicates whether this is an outgoing external service.
		/// </summary>
		public bool Outgoing { get; internal set; }

		/// <summary>
		/// Gets the path of the service.
		/// </summary>
		public string Path { get; internal set; }

		/// <summary>
		/// Gets the port of the service.
		/// </summary>
		public int Port { get; internal set; }

		/// <summary>
		/// Gets the privacy info of the service.
		/// </summary>
		public string Privacy { get; internal set; }

		/// <summary>
		/// Gets a web page generated by an external service (e.g. YouTube, SoundCloud, archive.org).
		/// </summary>
		public string ResultPage { get; internal set; }

		/// <summary>
		/// Gets URLs of the copied output files on external services.
		/// </summary>
		public List<string> ResultUrls { get; internal set; }

		/// <summary>
		/// Gets the sharing info of the service.
		/// </summary>
		public string Sharing { get; internal set; }

		/// <summary>
		/// Gets the track type.
		/// </summary>
		public string TrackType { get; internal set; }

		/// <summary>
		/// Gets a value that indicates whether the file transfer was successful.
		/// </summary>
		public bool TransferSuccess { get; internal set; }

		/// <summary>
		/// Gets the type of the service.
		/// </summary>
		public string Type { get; internal set; }

		/// <summary>
		/// Gets or sets the UUID of the service.
		/// </summary>
		public string Uuid { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="OutgoingService"/> class.
		/// </summary>
		public OutgoingService()
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