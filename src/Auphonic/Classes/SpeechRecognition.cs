using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents speech recognition information.
	/// </summary>
	public class SpeechRecognition
	{
		#region Public Properties
		/// <summary>
		/// Gets or sets keywords for the speech recognition.
		/// </summary>
		public List<string> Keywords { get; set; }

		/// <summary>
		/// Gets or sets language for the speech recognition (e.g. en-US).
		/// </summary>
		public string Language { get; set; }

		/// <summary>
		/// Gets or sets the type of the speech recognition service.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the UUID of the speech recognition service.
		/// </summary>
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