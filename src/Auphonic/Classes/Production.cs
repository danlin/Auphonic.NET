using System;
using System.Collections.Generic;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents a production.
	/// </summary>
	public class Production
	{
		#region Public Properties
		/// <summary>
		/// Gets or sets the audio algorithms settings.
		/// </summary>
		public Algorithms Algorithms { get; set; }

		/// <summary>
		/// Gets the input audio bitrate.
		/// </summary>
		public decimal Bitrate { get; internal set; }

		/// <summary>
		/// Gets or sets a value that indicates whether it's allowed to change the production
		/// (e.g. not during audio processing).
		/// </summary>
		public bool ChangeAllowed { get; set; }

		/// <summary>
		/// Gets the time of the last change made by the Auphonic system (UTC).
		/// </summary>
		public DateTime ChangeTime { get; internal set; }

		/// <summary>
		/// Gets the channels of input audio.
		/// </summary>
		public int Channels { get; internal set; }

		/// <summary>
		/// Gets or sets a list of chapters.
		/// </summary>
		public List<Chapter> Chapters { get; set; }

		/// <summary>
		/// Gets the production creation time (UTC).
		/// </summary>
		public DateTime CreationTime { get; internal set; }

		/// <summary>
		/// Gets or sets the time in seconds to cut from the end of an audio file.
		/// </summary>
		public decimal CutEnd { get; set; }

		/// <summary>
		/// Gets or sets the time in seconds to cut from the start of an audio file.
		/// </summary>
		public decimal CutStart { get; set; }

		/// <summary>
		/// Gets the URL to the Auphonic edit web page.
		/// </summary>
		public string EditPage { get; internal set; }

		/// <summary>
		/// Gets an error message, if an error occurred while processing,
		/// </summary>
		public string ErrorMessage { get; internal set; }

		/// <summary>
		/// Gets the processing status, where an error occurred. (See <see cref="Status"/>.)
		/// </summary>
		public string ErrorStatus { get; internal set; }

		/// <summary>
		/// Gets the input audio file format.
		/// </summary>
		public string Format { get; internal set; }

		public bool HasVideo { get; set; }

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		public string Image { get; set; }

		public string InputFile { get; set; }

		/// <summary>
		/// Gets or sets a value that indicates whether the production is multitrack.
		/// </summary>
		public bool IsMultitrack { get; set; }

		/// <summary>
		/// Gets the output audio length in seconds. <strong>Important:</strong> if you have intro
		/// or outro files, they are included in this length.
		/// </summary>
		public decimal Length { get; internal set; }

		/// <summary>
		/// Gets the output audio length in HH:MM:SS.mmm. <strong>Important:</strong> if you have
		/// intro or outro files, they are included in this length.
		/// </summary>
		public string LengthTimestring { get; internal set; }

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
		/// Gets the input audio samplerate.
		/// </summary>
		public int Samplerate { get; internal set; }

		/// <summary>
		/// Gets or sets the service UUID for incoming file transfer (<strong>null</strong> for
		/// file upload or HTTP incoming).
		/// </summary>
		public string Service { get; set; }

		/// <summary>
		/// Gets or sets the speech recognition.
		/// </summary>
		public SpeechRecognition SpeechRecognition { get; set; }

		public bool StartAllowed { get; set; }

		/// <summary>
		/// Gets the audio processing statistics.
		/// </summary>
		public Statistics Statistics { get; internal set; }

		/// <summary>
		/// Gets the production status.
		/// </summary>
		public int Status { get; internal set; }

		/// <summary>
		/// Gets the URL to the Auphonic status web page.
		/// </summary>
		public string StatusPage { get; internal set; }

		/// <summary>
		/// Gets the production status string.
		/// </summary>
		public string StatusString { get; internal set; }

		/// <summary>
		/// Gets or sets the thumbnail.
		/// </summary>
		public string Thumbnail { get; set; }

		public Credits UsedCredits { get; internal set; }

		/// <summary>
		/// Gets the production UUID.
		/// </summary>
		public string Uuid { get; internal set; }

		/// <summary>
		/// Gets a warning message, if a warning occurred while processing.
		/// </summary>
		public string WarningMessage { get; internal set; }

		/// <summary>
		/// Gets the processing status, where a warning occurred. (See <see cref="Status"/>.)
		/// </summary>
		public string WarningStatus { get; internal set; }

		/// <summary>
		/// Gets the URL to the image of the final waveform (as used by the audio player on the
		/// Auphonic status page).
		/// </summary>
		public string WaveformImage { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Production"/> class.
		/// </summary>
		public Production()
		{
			ChangeTime = DateTime.MinValue;
			CreationTime = DateTime.MinValue;
		}
		#endregion
	}
}