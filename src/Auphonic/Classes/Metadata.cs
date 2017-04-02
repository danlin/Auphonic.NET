using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Metadata"/> class.
	/// </summary>
	public class Metadata
	{
		#region Public Properties
		public string Album { get; set; }

		public string Subtitle { get; set; }

		public string Summary { get; set; }

		public string License { get; set; }

		public string Artist { get; set; }

		public string Track { get; set; }

		public string Title { get; set; }

		public string Publisher { get; set; }

		public string Url { get; set; }

		public string LicenseUrl { get; set; }

		public string Year { get; set; }

		public string Genre { get; set; }

		public bool AppendChapters { get; set; }

		public List<string> Tags { get; set; }

		public Location Location { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Metadata"/> class.
		/// </summary>
		public Metadata()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Metadata"/> class.
		/// </summary>
		public Metadata(string title, string artist, string album, string track)
		{
			Title = title;
			Artist = artist;
			Album = album;
			Track = track;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Metadata"/> class.
		/// </summary>
		public Metadata(
			string title,
			string artist,
			string album,
			string track,
			string genre,
			string year,
			string publisher,
			string url,
			string license,
			string licenseUrl,
			string subtitle,
			string summary,
			List<string> tags,
			bool appendChapters,
			Location location)
		{
			Title = title;
			Artist = artist;
			Album = album;
			Track = track;
			Genre = genre;
			Year = year;
			Publisher = publisher;
			Url = url;
			License = license;
			LicenseUrl = licenseUrl;
			Subtitle = subtitle;
			Summary = summary;
			Tags = tags;
			AppendChapters = appendChapters;
		}
		#endregion

		#region Public Override Methods
		public override string ToString()
		{
			return Title;
		}
		#endregion
	}
}