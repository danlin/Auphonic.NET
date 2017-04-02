using AuphonicNet.Api;
using AuphonicNet.Classes;
using AuphonicNet.Extensions;
using AuphonicNet.OAuth;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Net;

namespace AuphonicNet
{
	/// <summary>
	/// Provides a <see cref="AuphonicService"/> class.
	/// </summary>
	internal class AuphonicService
	{
		#region Private Constants
		private const string BaseUrl = "https://auphonic.com";
		#endregion

		#region Private Fields
		private readonly IRestClient _client;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="AuphonicService"/> class.
		/// </summary>
		public AuphonicService()
			: this(new RestClient(BaseUrl))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AuphonicService"/> class.
		/// </summary>
		/// <param name="client"></param>
		public AuphonicService(IRestClient client)
		{
			Precondition.IsNotNull(client, nameof(client));

			_client = client;

			SimpleJson.CurrentJsonSerializerStrategy = new SnakeJsonSerializerStrategy();
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="clientId"></param>
		/// <param name="clientSecret"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public OAuthToken Authenticate(string clientId, string clientSecret, string username, string password)
		{
			Precondition.IsNotNullOrWhiteSpace(clientId, nameof(clientId));
			Precondition.IsNotNullOrWhiteSpace(clientSecret, nameof(clientSecret));
			Precondition.IsNotNullOrWhiteSpace(username, nameof(username));
			Precondition.IsNotNullOrWhiteSpace(password, nameof(password));

			IRestRequest request = new RestRequest("oauth2/token/", Method.POST);
			request.AddParameter("client_id", clientId);
			request.AddParameter("username", username);
			request.AddParameter("password", password);
			request.AddParameter("grant_type", "password");

			OAuthToken token = ExecuteRequest(request, clientId, clientSecret);

			return token;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="uuid"></param>
		public void DeletePreset(OAuthToken token, string uuid)
		{
			Precondition.IsNotNull(token, nameof(token));
			Precondition.IsNotNullOrWhiteSpace(uuid, nameof(uuid));

			IRestRequest request = new RestRequest("api/preset/{uuid}.json", Method.DELETE);
			request.AddUrlSegment("uuid", uuid);

			ExecuteRequest<object>(request, token);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="uuid"></param>
		public void DeleteProduction(OAuthToken token, string uuid)
		{
			Precondition.IsNotNull(token, nameof(token));
			Precondition.IsNotNullOrWhiteSpace(uuid, nameof(uuid));

			IRestRequest request = new RestRequest("api/production/{uuid}.json", Method.DELETE);
			request.AddUrlSegment("uuid", uuid);

			ExecuteRequest<object>(request, token);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public Account GetAccountInfo(OAuthToken token)
		{
			Precondition.IsNotNull(token, nameof(token));

			IRestRequest request = new RestRequest("api/user.json");
			Response<Account> response = ExecuteRequest<Account>(request, token);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, Algorithm> GetAlgorithms()
		{
			IRestRequest request = new RestRequest("api/info/algorithms.json");
			Response<Dictionary<string, Algorithm>> response = ExecuteRequest<Dictionary<string, Algorithm>>(request);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, List<string>> GetFileEndings()
		{
			IRestRequest request = new RestRequest("api/info/file_endings.json");
			Response<Dictionary<string, List<string>>> response = ExecuteRequest<Dictionary<string, List<string>>>(request);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, OutputFile> GetOutputFiles()
		{
			IRestRequest request = new RestRequest("api/info/output_files.json");
			Response<Dictionary<string, OutputFile>> response = ExecuteRequest<Dictionary<string, OutputFile>>(request);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, string> GetProductionStatus()
		{
			IRestRequest request = new RestRequest("api/info/production_status.json");
			Response<Dictionary<string, string>> response = ExecuteRequest<Dictionary<string, string>>(request);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, ServiceType> GetServiceTypes()
		{
			IRestRequest request = new RestRequest("api/info/service_types.json");
			Response<Dictionary<string, ServiceType>> response = ExecuteRequest<Dictionary<string, ServiceType>>(request);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Info GetInfo()
		{
			IRestRequest request = new RestRequest("api/info.json");
			Response<Info> response = ExecuteRequest<Info>(request);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="uuid"></param>
		/// <returns></returns>
		public Production GetProduction(OAuthToken token, string uuid)
		{
			Precondition.IsNotNull(token, nameof(token));
			Precondition.IsNotNullOrWhiteSpace(uuid, nameof(uuid));

			IRestRequest request = new RestRequest("api/production/{uuid}.json");
			request.AddUrlSegment("uuid", uuid);

			Response<Production> response = ExecuteRequest<Production>(request, token);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public List<Production> GetProductions(OAuthToken token)
		{
			return GetProductions(token, 0, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public List<Production> GetProductions(OAuthToken token, int limit)
		{
			return GetProductions(token, limit, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="limit"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public List<Production> GetProductions(OAuthToken token, int limit, int offset)
		{
			Precondition.IsNotNull(token, nameof(token));
			Precondition.IsGreaterOrEqual(limit, 0, nameof(limit));
			Precondition.IsGreaterOrEqual(offset, 0, nameof(offset));

			IRestRequest request = new RestRequest("api/productions.json");

			if (limit > 0)
			{
				request.AddParameter("limit", limit);
			}

			if (offset > 0)
			{
				request.AddParameter("offset", offset);
			}

			Response<List<Production>> response = ExecuteRequest<List<Production>>(request, token);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="uuid"></param>
		/// <returns></returns>
		public Preset GetPreset(OAuthToken token, string uuid)
		{
			Precondition.IsNotNull(token, nameof(token));
			Precondition.IsNotNullOrWhiteSpace(uuid, nameof(uuid));

			IRestRequest request = new RestRequest("api/preset/{uuid}.json");
			request.AddUrlSegment("uuid", uuid);

			Response<Preset> response = ExecuteRequest<Preset>(request, token);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public List<Preset> GetPresets(OAuthToken token)
		{
			return GetPresets(token, 0, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public List<Preset> GetPresets(OAuthToken token, int limit)
		{
			return GetPresets(token, limit, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="limit"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public List<Preset> GetPresets(OAuthToken token, int limit, int offset)
		{
			Precondition.IsNotNull(token, nameof(token));
			Precondition.IsGreaterOrEqual(limit, 0, nameof(limit));
			Precondition.IsGreaterOrEqual(offset, 0, nameof(offset));

			IRestRequest request = new RestRequest("api/presets.json");

			if (limit > 0)
			{
				request.AddParameter("limit", limit);
			}

			if (offset > 0)
			{
				request.AddParameter("offset", offset);
			}

			Response<List<Preset>> response = ExecuteRequest<List<Preset>>(request, token);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public List<string> GetProductionsUuids(OAuthToken token)
		{
			Precondition.IsNotNull(token, nameof(token));

			IRestRequest request = new RestRequest("api/productions.json");
			request.AddParameter("uuids_only", 1);

			Response<List<string>> response = ExecuteRequest<List<string>>(request, token);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public List<string> GetPresetsUuids(OAuthToken token)
		{
			Precondition.IsNotNull(token, nameof(token));

			IRestRequest request = new RestRequest("api/presets.json");
			request.AddParameter("uuids_only", 1);

			Response<List<string>> response = ExecuteRequest<List<string>>(request, token);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public List<Service> GetServices(OAuthToken token)
		{
			Precondition.IsNotNull(token, nameof(token));

			IRestRequest request = new RestRequest("api/services.json");

			Response<List<Service>> response = ExecuteRequest<List<Service>>(request, token);

			return response.Data;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="token"></param>
		/// <param name="uuid"></param>
		/// <returns></returns>
		public List<string> GetServiceFiles(OAuthToken token, string uuid)
		{
			Precondition.IsNotNull(token, nameof(token));
			Precondition.IsNotNullOrWhiteSpace(uuid, nameof(uuid));

			IRestRequest request = new RestRequest("api/service/{uuid}/ls.json");
			request.AddUrlSegment("uuid", uuid);

			Response<List<string>> response = ExecuteRequest<List<string>>(request, token);

			return response.Data;
		}
		#endregion

		//#region Public Methods - Not Implemented
		//public object CreateProduction(OAuthToken token, Production production)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(production, nameof(production));

		//	throw new System.NotImplementedException();
		//}

		//public object CreateProduction(OAuthToken token, Metadata metadata)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(metadata, nameof(metadata));

		//	IRestRequest request = new RestRequest("api/productions.json", Method.POST);
		//	request.AddJsonBody(metadata);

		//	object obj = ExecuteRequest<object>(request, token);

		//	return obj;
		//}

		//public object CreateProduction(OAuthToken token, List<File> outputFiles)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(outputFiles, nameof(outputFiles));

		//	throw new System.NotImplementedException();
		//}

		//public object CreateProduction(OAuthToken token, List<OutgoingService> outgoingServices)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(outgoingServices, nameof(outgoingServices));

		//	throw new System.NotImplementedException();
		//}

		//public object CreateProduction(OAuthToken token, Algorithms algorithms)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(algorithms, nameof(algorithms));

		//	throw new System.NotImplementedException();
		//}

		//public object CreateProduction(OAuthToken token, List<Chapter> chapters)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(chapters, nameof(chapters));

		//	throw new System.NotImplementedException();
		//}

		//public object CreateProduction(OAuthToken token, List<MultiInputFile> multiInputFiles)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(multiInputFiles, nameof(multiInputFiles));

		//	throw new System.NotImplementedException();
		//}

		//public object UpdateProduction(OAuthToken token, Production production)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(production, nameof(production));

		//	production.ResetData = true;

		//	throw new System.NotImplementedException();
		//}

		//public object UpdatePreset(OAuthToken token, Preset preset)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(preset, nameof(preset));

		//	preset.ResetData = true;

		//	throw new System.NotImplementedException();
		//}
		//#endregion

		//#region At Work
		//public Preset CreatePreset(OAuthToken token, Preset preset)
		//{
		//	Precondition.IsNotNull(token, nameof(token));
		//	Precondition.IsNotNull(preset, nameof(preset));

		//	IRestRequest request = new RestRequest("api/presets.json", Method.POST);
		//	request.RequestFormat = DataFormat.Json;
		//	request.AddBody(preset);

		//	Response<Preset> response = ExecuteRequest<Preset>(request, token);

		//	return response.Data;
		//}

		//public Preset CreatePreset(OAuthToken token, string name, Metadata metadata)
		//{
		//	Preset preset = new Preset(name, metadata);
		//	Preset result = CreatePreset(token, preset);

		//	return result;
		//}

		//public Preset CreatePreset(OAuthToken token, string name, List<File> outputFiles)
		//{
		//	Preset preset = new Preset(name, outputFiles);
		//	Preset result = CreatePreset(token, preset);

		//	return result;
		//}

		//public Preset CreatePreset(OAuthToken token, string name, List<OutgoingService> outgoingServices)
		//{
		//	Preset preset = new Preset(name, outgoingServices);
		//	Preset result = CreatePreset(token, preset);

		//	return result;
		//}

		//public Preset CreatePreset(OAuthToken token, string name, Algorithms algorithms)
		//{
		//	Preset preset = new Preset(name, algorithms);
		//	Preset result = CreatePreset(token, preset);

		//	return result;
		//}

		//public Preset CreatePreset(OAuthToken token, string name, List<MultiInputFile> multiInputFiles)
		//{
		//	Preset preset = new Preset(name, multiInputFiles);
		//	Preset result = CreatePreset(token, preset);

		//	return result;
		//}
		//#endregion

		#region Private Methods
		private Response<T> ExecuteRequest<T>(IRestRequest request) where T : new()
		{
			IRestResponse<Response<T>> response = ExecuteRequest<Response<T>>(request, (IAuthenticator)null);

			return response.Data;
		}

		private OAuthToken ExecuteRequest(IRestRequest request, string clientId, string clientSecret)
		{
			IAuthenticator authenticator = new HttpBasicAuthenticator(clientId, clientSecret);
			IRestResponse<OAuthToken> response = ExecuteRequest<OAuthToken>(request, authenticator);

			ProcessResponse(response);

			return response.Data;
		}

		private Response<T> ExecuteRequest<T>(IRestRequest request, OAuthToken token) where T : new()
		{
			IAuthenticator authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token?.AccessToken, token?.TokenType);
			IRestResponse<Response<T>> response = ExecuteRequest<Response<T>>(request, authenticator);

			ProcessResponse<T>(response);

			return response.Data;
		}

		private IRestResponse<T> ExecuteRequest<T>(IRestRequest request, IAuthenticator authenticator) where T : new()
		{
			_client.Authenticator = authenticator;
			IRestResponse<T> response = _client.Execute<T>(request);

			return response;
		}

		private void ProcessResponse(IRestResponse<OAuthToken> response)
		{
			if (response.StatusCode == HttpStatusCode.Unauthorized ||
				response.StatusCode == HttpStatusCode.BadRequest)
			{
				JsonObject obj = (JsonObject)SimpleJson.DeserializeObject(response.Content);
				string error = obj.ContainsKey("error") ? obj["error"].ToString() : null;
				string errorDescription = obj.ContainsKey("error_description") ? obj["error_description"].ToString() : null;

				throw new AuphonicException(error, errorDescription);
			}
		}

		private void ProcessResponse<T>(IRestResponse<Response<T>> response) where T : new()
		{
			if (!response.Data.ErrorCode.IsNullOrWhiteSpace() ||
				!response.Data.ErrorMessage.IsNullOrWhiteSpace())
			{
				throw new AuphonicException(response.Data.ErrorCode, response.Data.ErrorMessage);
			}
		}
		#endregion
	}
}