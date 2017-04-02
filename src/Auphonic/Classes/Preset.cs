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
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Preset"/> class.
		/// </summary>
		/// <param name="presetName"></param>
		/// <param name="algorithms"></param>
		public Preset(string presetName, Algorithms algorithms)
		{
			Precondition.IsNotNullOrWhiteSpace(presetName, nameof(presetName));
			Precondition.IsNotNull(algorithms, nameof(algorithms));

			PresetName = presetName;
			Algorithms = algorithms;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Preset"/> class.
		/// </summary>
		/// <param name="presetName"></param>
		/// <param name="outputFiles"></param>
		public Preset(string presetName, List<File> outputFiles)
		{
			Precondition.IsNotNullOrWhiteSpace(presetName, nameof(presetName));
			Precondition.IsNotNull(outputFiles, nameof(outputFiles));

			PresetName = presetName;
			OutputFiles = outputFiles;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Preset"/> class.
		/// </summary>
		/// <param name="presetName"></param>
		/// <param name="multiInputFiles"></param>
		public Preset(string presetName, List<MultiInputFile> multiInputFiles)
		{
			Precondition.IsNotNullOrWhiteSpace(presetName, nameof(presetName));
			Precondition.IsNotNull(multiInputFiles, nameof(multiInputFiles));

			PresetName = presetName;
			MultiInputFiles = multiInputFiles;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Preset"/> class.
		/// </summary>
		/// <param name="presetName"></param>
		/// <param name="outgoingServices"></param>
		public Preset(string presetName, List<OutgoingService> outgoingServices)
		{
			Precondition.IsNotNullOrWhiteSpace(presetName, nameof(presetName));
			Precondition.IsNotNull(outgoingServices, nameof(outgoingServices));

			PresetName = presetName;
			OutgoingServices = outgoingServices;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Preset"/> class.
		/// </summary>
		/// <param name="presetName"></param>
		/// <param name="metadata"></param>
		public Preset(string presetName, Metadata metadata)
		{
			Precondition.IsNotNullOrWhiteSpace(presetName, nameof(presetName));
			Precondition.IsNotNull(metadata, nameof(metadata));

			PresetName = presetName;
			Metadata = metadata;
		}
		#endregion
	}
}