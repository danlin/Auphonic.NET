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
		/// <summary>
		/// 
		/// </summary>
		public string ClientId { get; }

		/// <summary>
		/// 
		/// </summary>
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
		/// <param name="preset"></param>
		/// <returns></returns>
		public Preset CreatePreset(Preset preset)
		{
			CheckAuthentication();
			Preset obj = _service.CreatePreset(_token, preset);

			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="production"></param>
		/// <returns></returns>
		public Production CreateProduction(Production production)
		{
			CheckAuthentication();
			Production obj = _service.CreateProduction(_token, production);

			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uuid"></param>
		public void DeletePreset(string uuid)
		{
			CheckAuthentication();
			_service.DeletePreset(_token, uuid);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uuid"></param>
		public void DeleteProduction(string uuid)
		{
			CheckAuthentication();
			_service.DeleteProduction(_token, uuid);
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
		public Dictionary<string, AlgorithmType> GetAlgorithms()
		{
			Dictionary<string, AlgorithmType> algorithms = _service.GetAlgorithmType();
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
		public Dictionary<string, OutputFileType> GetOutputFiles()
		{
			Dictionary<string, OutputFileType> outputFiles = _service.GetOutputFileTypes();
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uuid"></param>
		/// <returns></returns>
		public Production GetProduction(string uuid)
		{
			CheckAuthentication();
			Production production = _service.GetProduction(_token, uuid);

			return production;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<Production> GetProductions()
		{
			return GetProductions(0, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="limit"></param>
		/// <returns></returns>
		public List<Production> GetProductions(int limit)
		{
			return GetProductions(limit, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="limit"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public List<Production> GetProductions(int limit, int offset)
		{
			CheckAuthentication();
			List<Production> productions = _service.GetProductions(_token, limit, offset);

			return productions;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<string> GetProductionsUuids()
		{
			CheckAuthentication();
			List<string> productions = _service.GetProductionsUuids(_token);

			return productions;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Preset GetPreset(string uuid)
		{
			CheckAuthentication();
			Preset preset = _service.GetPreset(_token, uuid);

			return preset;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<Preset> GetPresets()
		{
			return GetPresets(0, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="limit"></param>
		/// <returns></returns>
		public List<Preset> GetPresets(int limit)
		{
			return GetPresets(limit, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="limit"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public List<Preset> GetPresets(int limit, int offset)
		{
			CheckAuthentication();
			List<Preset> presets = _service.GetPresets(_token, limit, offset);

			return presets;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<string> GetPresetsUuids()
		{
			CheckAuthentication();
			List<string> presets = _service.GetPresetsUuids(_token);

			return presets;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<Service> GetServices()
		{
			CheckAuthentication();
			List<Service> services = _service.GetServices(_token);

			return services;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uuid"></param>
		/// <returns></returns>
		public List<string> GetServiceFiles(string uuid)
		{
			CheckAuthentication();
			List<string> files = _service.GetServiceFiles(_token, uuid);

			return files;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uuid"></param>
		/// <returns></returns>
		public Production StartProduction(string uuid)
		{
			CheckAuthentication();
			Production obj = _service.StartProduction(_token, uuid);

			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="preset"></param>
		/// <returns></returns>
		public Preset UpdatePreset(Preset preset)
		{
			CheckAuthentication();
			Preset obj = _service.UpdatePreset(_token, preset);

			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="production"></param>
		/// <returns></returns>
		public Production UpdateProduction(Production production)
		{
			CheckAuthentication();
			Production obj = _service.UpdateProduction(_token, production);

			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uuid"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		public Production UploadFile(string uuid, string path)
		{
			CheckAuthentication();
			Production obj = _service.UploadFile(_token, uuid, path);

			return obj;
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