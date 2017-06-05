using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents speech recognition information.
	/// </summary>
	public class SpeechRecognition
	{
		#region Public Properties
		public List<string> Keywords { get; set; }

		public string Language { get; set; }

		public string Type { get; set; }

		public string Uuid { get; set; }
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