using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="SpeechRecognition"/> class.
	/// </summary>
	public class SpeechRecognition
	{
		#region Public Properties
		public List<string> Keywords { get; set; }

		public string Type { get; set; }

		public string Uuid { get; set; }

		public string Language { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="SpeechRecognition"/> class.
		/// </summary>
		public SpeechRecognition()
		{
		}
		#endregion
	}
}