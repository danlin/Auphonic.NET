using System;
using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a preset for a production.
	/// </summary>
	public class Preset
	{
		#region Public Properties
		/// <summary>
		/// Gets or sets the audio algorithms settings.
		/// </summary>
		public Algorithms Algorithms { get; set; }

		/// <summary>
		/// Gets the preset creation time.
		/// </summary>
		public DateTime CreationTime { get; internal set; }

		public string Image { get; set; }

		public bool IsMultitrack { get; set; }

		public Metadata Metadata { get; set; }

		public List<MultiInputFile> MultiInputFiles { get; set; }

		public List<OutgoingService> OutgoingServices { get; set; }

		public string OutputBasename { get; set; }

		public List<OutputFile> OutputFiles { get; set; }

		/// <summary>
		/// Gets or sets the preset name.
		/// </summary>
		public string PresetName { get; set; }

		public SpeechRecognition SpeechRecognition { get; set; }

		public string Thumbnail { get; set; }

		/// <summary>
		/// Gets the preset UUID.
		/// </summary>
		public string Uuid { get; internal set; }
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
			: this()
		{
			PresetName = presetName;
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return PresetName;
		}
		#endregion
	}
}