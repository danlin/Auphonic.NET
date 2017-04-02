using System;
using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Production"/> class.
	/// </summary>
	public class Production
	{
		#region Public Properties
		public int Status { get; set; }

		public string StatusString { get; set; }

		public List<Chapter> Chapters { get; set; }

		public List<OutgoingService> OutgoingServices { get; set; }

		public string Uuid { get; set; }

		public string OutputBasename { get; set; }

		public List<File> OutputFiles { get; set; }

		public string Image { get; set; }

		public string Thumbnail { get; set; }

		public string WaveformImage { get; set; }

		public DateTime CreationTime { get; set; }

		public DateTime ChangeTime { get; set; }

		public Algorithms Algorithms { get; set; }

		public string Service { get; set; }

		public string InputFile { get; set; }

		public decimal Length { get; set; }

		public string LengthTimestring { get; set; }

		public int Channels { get; set; }

		public int Samplerate { get; set; }

		public decimal Bitrate { get; set; }

		public string Format { get; set; }

		public bool HasVideo { get; set; }

		public decimal CutStart { get; set; }

		public decimal CutEnd { get; set; }

		public Metadata Metadata { get; set; }

		public List<MultiInputFile> MultiInputFiles { get; set; }

		public bool StartAllowed { get; set; }

		public bool ChangeAllowed { get; set; }

		public string StatusPage { get; set; }

		public string EditPage { get; set; }

		public string ErrorStatus { get; set; }

		public string ErrorMessage { get; set; }

		public string WarningStatus { get; set; }

		public string WarningMessage { get; set; }

		public string Webhook { get; set; }

		public bool IsMultitrack { get; set; }

		public Credits UsedCredits { get; set; }

		public SpeechRecognition SpeechRecognition { get; set; }

		public Statistics Statistics { get; set; }
		#endregion

		#region Internal Properties
		public bool ResetData { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Production"/> class.
		/// </summary>
		public Production()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Production"/> class.
		/// </summary>
		public Production(Metadata metadata)
		{
			Metadata = metadata;
		}
		#endregion
	}
}