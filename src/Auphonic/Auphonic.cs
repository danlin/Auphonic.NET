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
		#endregion

		//#region Public Methods - Not Implemented
		//public object CreateProduction(Production production)
		//{
		//	CheckAuthentication();
		//	object obj = _service.CreateProduction(_token, production);

		//	return obj;
		//}

		//public object CreateProduction(Metadata metadata)
		//{
		//	CheckAuthentication();
		//	object obj = _service.CreateProduction(_token, metadata);

		//	return obj;
		//}

		//public object CreateProduction(List<File> outputFiles)
		//{
		//	CheckAuthentication();
		//	object obj = _service.CreateProduction(_token, outputFiles);

		//	return obj;
		//}

		//public object CreateProduction(List<OutgoingService> outgoingServices)
		//{
		//	CheckAuthentication();
		//	object obj = _service.CreateProduction(_token, outgoingServices);

		//	return obj;
		//}

		//public object CreateProduction(Algorithms algorithms)
		//{
		//	CheckAuthentication();
		//	object obj = _service.CreateProduction(_token, algorithms);

		//	return obj;
		//}

		//public object CreateProduction(List<Chapter> chapters)
		//{
		//	CheckAuthentication();
		//	object obj = _service.CreateProduction(_token, chapters);

		//	return obj;
		//}

		//public object CreateProduction(List<MultiInputFile> multiInputFiles)
		//{
		//	CheckAuthentication();
		//	object obj = _service.CreateProduction(_token, multiInputFiles);

		//	return obj;
		//}

		//public object UpdateProduction(Production production)
		//{
		//	CheckAuthentication();
		//	object obj = _service.UpdateProduction(_token, production);

		//	return obj;
		//}

		//public Preset CreatePreset(Preset preset)
		//{
		//	CheckAuthentication();
		//	Preset obj = _service.CreatePreset(_token, preset);

		//	return obj;
		//}

		//public Preset CreatePreset(string name, Metadata metadata)
		//{
		//	CheckAuthentication();
		//	Preset obj = _service.CreatePreset(_token, name, metadata);

		//	return obj;
		//}

		//public Preset CreatePreset(string name, List<File> outputFiles)
		//{
		//	CheckAuthentication();
		//	Preset obj = _service.CreatePreset(_token, name, outputFiles);

		//	return obj;
		//}

		//public Preset CreatePreset(string name, List<OutgoingService> outgoingServices)
		//{
		//	CheckAuthentication();
		//	Preset obj = _service.CreatePreset(_token, name, outgoingServices);

		//	return obj;
		//}

		//public Preset CreatePreset(string name, Algorithms algorithms)
		//{
		//	CheckAuthentication();
		//	Preset obj = _service.CreatePreset(_token, name, algorithms);

		//	return obj;
		//}

		//public Preset CreatePreset(string name, List<MultiInputFile> multiInputFiles)
		//{
		//	CheckAuthentication();
		//	Preset obj = _service.CreatePreset(_token, name, multiInputFiles);

		//	return obj;
		//}

		//public object UpdatePreset(Preset preset)
		//{
		//	CheckAuthentication();
		//	object obj = _service.UpdatePreset(_token, preset);

		//	return obj;
		//}
		//#endregion

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