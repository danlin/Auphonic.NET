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

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		public string Image { get; set; }

		/// <summary>
		/// Gets or sets a value that indicates whether the production is multitrack.
		/// </summary>
		public bool IsMultitrack { get; set; }

		/// <summary>
		/// Gets or sets metadata.
		/// </summary>
		public Metadata Metadata { get; set; }

		/// <summary>
		/// Gets or sets multi input files.
		/// </summary>
		public List<MultiInputFile> MultiInputFiles { get; set; }

		/// <summary>
		/// Gets or sets outgoing services.
		/// </summary>
		public List<OutgoingService> OutgoingServices { get; set; }

		/// <summary>
		/// Gets or sets the output file basename.
		/// </summary>
		public string OutputBasename { get; set; }

		/// <summary>
		/// Gets or sets output files.
		/// </summary>
		public List<OutputFile> OutputFiles { get; set; }

		/// <summary>
		/// Gets or sets the preset name.
		/// </summary>
		public string PresetName { get; set; }

		/// <summary>
		/// Gets or sets the speech recognition.
		/// </summary>
		public SpeechRecognition SpeechRecognition { get; set; }

		/// <summary>
		/// Gets or sets the thumbnail.
		/// </summary>
		public string Thumbnail { get; set; }

		/// <summary>
		/// Gets the preset UUID.
		/// </summary>
		public string Uuid { get; internal set; }
		#endregion

		#region Internal Properties
		internal bool ResetData { get; set; }
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