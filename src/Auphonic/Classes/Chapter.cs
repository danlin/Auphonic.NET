namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Chapter"/> class.
	/// </summary>
	public class Chapter
	{
		#region Public Properties
		public string Title { get; set; }

		public string Url { get; set; }

		public string Image { get; set; }

		public string Start { get; set; }

		public decimal StartSec { get; set; }

		public string StartOutput { get; set; }

		public decimal StartOutputSec { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Chapter"/> class.
		/// </summary>
		public Chapter()
		{
		}
		#endregion
	}
}