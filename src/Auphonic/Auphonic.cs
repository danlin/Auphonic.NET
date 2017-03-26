using AuphonicNet.Classes;
using AuphonicNet.OAuth;
using System.Collections.Generic;

namespace AuphonicNet
{
	/// <summary>
	/// Provides a <see cref="Auphonic"/> class.
	/// </summary>
	public class Auphonic
	{
		#region Public Properties
		public string ClientId { get; }

		public string ClientSecret { get; }
		#endregion

		#region Private Fields
		private readonly AuphonicService _service;

		private OAuthToken _token;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Auphonic"/> class.
		/// </summary>
		/// <param name="clientId"></param>
		/// <param name="clientSecret"></param>
		public Auphonic(string clientId, string clientSecret)
			: this(clientId, clientSecret, new AuphonicService())
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Auphonic"/> class.
		/// </summary>
		/// <param name="clientId"></param>
		/// <param name="clientSecret"></param>
		/// <param name="service"></param>
		internal Auphonic(string clientId, string clientSecret, AuphonicService service)
		{
			Precondition.IsNotNullOrWhiteSpace(clientId, nameof(clientId));
			Precondition.IsNotNullOrWhiteSpace(clientSecret, nameof(clientSecret));
			Precondition.IsNotNull(service, nameof(service));

			ClientId = clientId;
			ClientSecret = clientSecret;

			_service = service;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public string Authenticate(string username, string password)
		{
			Precondition.IsNotNullOrWhiteSpace(username, nameof(username));
			Precondition.IsNotNullOrWhiteSpace(password, nameof(password));

			_token = _service.Authenticate(ClientId, ClientSecret, username, password);

			return _token.AccessToken;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="accessToken"></param>
		public void Authenticate(string accessToken)
		{
			Precondition.IsNotNullOrWhiteSpace(accessToken, nameof(accessToken));

			_token = new OAuthToken(accessToken);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Account GetAccountInfo()
		{
			CheckAuthentication();
			Account account = _service.GetAccountInfo(_token);

			return account;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, Algorithm> GetAlgorithms()
		{
			Dictionary<string, Algorithm> algorithms = _service.GetAlgorithms();
			return algorithms;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, List<string>> GetFileEndings()
		{
			Dictionary<string, List<string>> fileEndings = _service.GetFileEndings();
			return fileEndings;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, OutputFile> GetOutputFiles()
		{
			Dictionary<string, OutputFile> outputFiles = _service.GetOutputFiles();
			return outputFiles;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, string> GetProductionStatus()
		{
			Dictionary<string, string> productionStatus = _service.GetProductionStatus();
			return productionStatus;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, ServiceType> GetServiceTypes()
		{
			Dictionary<string, ServiceType> serviceTypes = _service.GetServiceTypes();
			return serviceTypes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Info GetInfo()
		{
			Info info = _service.GetInfo();
			return info;
		}
		#endregion

		#region Private Methods
		private void CheckAuthentication()
		{
			if (_token == null)
			{
				throw new AuphonicException("", "No authentication credentials provided.");
			}
		}
		#endregion
	}
}