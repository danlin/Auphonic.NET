using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represent the metadata of a preset/production.
	/// </summary>
	public class Metadata
	{
		#region Public Properties
		/// <summary>
		/// Gets or sets the album name.
		/// </summary>
		public string Album { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the chapter marks are appended to the summary.
		/// </summary>
		/// <value><strong>true</strong> if the chapter marks are appended to the summary;
		/// otherwise, <strong>false</strong>. The default is <strong>false</strong>.</value>
		public bool AppendChapters { get; set; }

		/// <summary>
		/// Gets or sets the artist.
		/// </summary>
		public string Artist { get; set; }

		/// <summary>
		/// Gets or sets the genre.
		/// </summary>
		public string Genre { get; set; }

		/// <summary>
		/// Gets or sets the license.
		/// </summary>
		public string License { get; set; }

		/// <summary>
		/// Gets or sets the license URL.
		/// </summary>
		public string LicenseUrl { get; set; }

		/// <summary>
		/// Gets or sets the location.
		/// </summary>
		public Location Location { get; set; }

		/// <summary>
		/// Gets or sets the publisher.
		/// </summary>
		public string Publisher { get; set; }

		/// <summary>
		/// Gets or sets the subtitle.
		/// </summary>
		public string Subtitle { get; set; }

		/// <summary>
		/// Gets or sets the summary.
		/// </summary>
		public string Summary { get; set; }

		/// <summary>
		/// Gets or sets a list of tags.
		/// </summary>
		public List<string> Tags { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the track number.
		/// </summary>
		public string Track { get; set; }

		/// <summary>
		/// Gets or sets a URL for further information.
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		public string Year { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Metadata"/> class.
		/// </summary>
		public Metadata()
		{
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return Title;
		}
		#endregion
	}
}