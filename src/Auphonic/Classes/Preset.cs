using System;
using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Preset"/> class.
	/// </summary>
	public class Preset
	{
		#region Public Properties
		public List<File> OutputFiles { get; set; }

		public string OutputBasename { get; set; }

		public List<OutgoingService> OutgoingServices { get; set; }

		public string Uuid { get; set; }

		public Algorithms Algorithms { get; set; }

		public string Image { get; set; }

		public DateTime CreationTime { get; set; }

		public string Thumbnail { get; set; }

		public string PresetName { get; set; }

		public Metadata Metadata { get; set; }

		public List<MultiInputFile> MultiInputFiles { get; set; }

		public SpeechRecognition SpeechRecognition { get; set; }

		public bool IsMultitrack { get; set; }
		#endregion

		#region Internal Properties
		public bool ResetData { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Preset"/> class.
		/// </summary>
		public Preset()
		{
			CreationTime = DateTime.MinValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Preset"/> class.
		/// </summary>
		public Preset(string presetName)
			: base()
		{
			PresetName = presetName;
		}
		#endregion
	}
}