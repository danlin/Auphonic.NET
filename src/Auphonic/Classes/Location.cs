using System;
using System.Globalization;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a geo location.
	/// </summary>
	public class Location
	{
		#region Public Properties
		/// <summary>
		/// Gets the latitude.
		/// </summary>
		public string Latitude { get; internal set; }

		/// <summary>
		/// Gets the longitude.
		/// </summary>
		public string Longitude { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Location"/> class.
		/// </summary>
		public Location()
			: this(0, 0)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Location"/> class.
		/// </summary>
		/// <param name="latitude">The latitude.</param>
		/// <param name="longitude">The longitude.</param>
		public Location(double latitude, double longitude)
		{
			IFormatProvider formatProvider = new CultureInfo("en-US");

			Latitude = latitude.ToString("0.000", formatProvider);
			Longitude = longitude.ToString("0.000", formatProvider);
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return $"Latitude:{Latitude}; Longitude={Longitude}";
		}
		#endregion
	}
}