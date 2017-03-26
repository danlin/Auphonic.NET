using AuphonicNet.Api;
using AuphonicNet.Classes;
using AuphonicNet.OAuth;
using Moq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;

namespace AuphonicNet.Tests.Mock
{
	/// <summary>
	/// Provides a <see cref="RestClientMock"/> class.
	/// </summary>
	public abstract class RestClientMock
	{
		#region Public Constants
		public const string ClientId = "clientId";
		public const string ClientSecret = "clientSecret";
		public const string Username = "username";
		public const string Password = "password";

		public const string AccessToken = "436bfd6bed";
		public const string InvalidAccessToken = "abcdefghi";
		#endregion

		#region Protected Constants
		protected const string AuthHeader = "Basic Y2xpZW50SWQ6Y2xpZW50U2VjcmV0";
		protected const string AuthHeaderInvalidClientId = "Basic aW52YWxpZDppbnZhbGlk";
		protected const string AuthHeaderInvalidClientSecret = "Basic Y2xpZW50SWQ6aW52YWxpZA==";
		#endregion

		#region Internal Fields
		internal OAuthToken Token;
		internal OAuthToken InvalidToken;
		internal OAuthToken NullToken;
		#endregion

		#region Protected Fields
		protected IRestClient Client;
		protected Mock<IRestClient> ClientMock;
		#endregion

		#region Constructor
		protected RestClientMock()
		{
			InitializeClientMock();

			Token = new OAuthToken(AccessToken);
			InvalidToken = new OAuthToken(InvalidAccessToken);
			NullToken = new OAuthToken(null);
		}
		#endregion

		#region Private Methods
		private void InitializeClientMock()
		{
			ClientMock = new Mock<IRestClient>();
			ClientMock.SetupProperty(c => c.Authenticator);

			// Authenticate
			ClientMock.Setup(c => c.Execute<OAuthToken>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.Authenticate)))).Returns(() => GetAuthenticateResponse());
			ClientMock.Setup(c => c.Execute<OAuthToken>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.AuthenticateInvalidClientId)))).Returns(() => GetAuthenticateInvalidResponse(RequestType.AuthenticateInvalidClientId));
			ClientMock.Setup(c => c.Execute<OAuthToken>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.AuthenticateInvalidClientSecret)))).Returns(() => GetAuthenticateInvalidResponse(RequestType.AuthenticateInvalidClientSecret));
			ClientMock.Setup(c => c.Execute<OAuthToken>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.AuthenticateInvalidUsername)))).Returns(() => GetAuthenticateInvalidResponse(RequestType.AuthenticateInvalidUsername));
			ClientMock.Setup(c => c.Execute<OAuthToken>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.AuthenticateInvalidPassword)))).Returns(() => GetAuthenticateInvalidResponse(RequestType.AuthenticateInvalidPassword));

			// AccountInfo
			ClientMock.Setup(c => c.Execute<Response<Account>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.AccountInfo)))).Returns(() => GetAccountInfoResponse());
			ClientMock.Setup(c => c.Execute<Response<Account>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.AccountInfoInvalidToken)))).Returns(() => GetInvalidTokenResponse<Account>());
			ClientMock.Setup(c => c.Execute<Response<Account>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.AccountInfoNullToken)))).Returns(() => GetNullTokenResponse<Account>());

			// Algorithms
			ClientMock.Setup(c => c.Execute<Response<Dictionary<string, Algorithm>>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.Algorithms)))).Returns(() => GetAlgorithmsResponse());

			// FileEndings
			ClientMock.Setup(c => c.Execute<Response<Dictionary<string, List<string>>>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.FileEndings)))).Returns(() => GetFileEndingsResponse());

			// OutputFiles
			ClientMock.Setup(c => c.Execute<Response<Dictionary<string, OutputFile>>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.OutputFiles)))).Returns(() => GetOutputFilesResponse());

			// ProductionStatus
			ClientMock.Setup(c => c.Execute<Response<Dictionary<string, string>>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.ProductionStatus)))).Returns(() => GetProductionStatusResponse());

			// ServiceTypes
			ClientMock.Setup(c => c.Execute<Response<Dictionary<string, ServiceType>>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.ServiceTypes)))).Returns(() => GetServiceTypeResponse());

			// Info
			ClientMock.Setup(c => c.Execute<Response<Info>>(It.Is<IRestRequest>(r => IsRequest(r, RequestType.Info)))).Returns(() => GetInfoResponse());

			Client = ClientMock.Object;
		}

		private bool IsNullAccessToken()
		{
			var authenticator = (OAuth2AuthorizationRequestHeaderAuthenticator)Client.Authenticator;

			return authenticator?.AccessToken == null;
		}

		private string GetAuthHeader()
		{
			var authenticator = (HttpBasicAuthenticator)Client.Authenticator;

			Type type = Client.Authenticator.GetType();
			FieldInfo filedInfo = type.GetField("authHeader", BindingFlags.Instance | BindingFlags.NonPublic);
			string authHeader = (string)filedInfo.GetValue(authenticator);

			return authHeader;
		}

		private IRestResponse<T> GetDefaultResponse<T>(string jsonFile) where T : new()
		{
			JsonDeserializer deserializer = new JsonDeserializer();
			string json = File.ReadAllText(jsonFile);

			IRestResponse<T> response = new RestResponse<T>();
			response.Content = json;
			response.Data = deserializer.Deserialize<T>(response);

			return response;
		}

		private IRestResponse<Response<T>> GetResponse<T>(string jsonFile) where T : new()
		{
			return GetDefaultResponse<Response<T>>(jsonFile);
		}
		#endregion

		#region Private Methods - Requests
		private bool IsRequest(IRestRequest request, RequestType requestType)
		{
			bool result = false;

			switch (requestType)
			{
				//Authenticate
				case RequestType.Authenticate:
					result = IsValidAuthenticateRequest(request);
					break;
				case RequestType.AuthenticateInvalidClientId:
				case RequestType.AuthenticateInvalidClientSecret:
				case RequestType.AuthenticateInvalidUsername:
				case RequestType.AuthenticateInvalidPassword:
					result = IsInvalidAuthenticateRequest(request, requestType);
					break;

				// AccountInfo
				case RequestType.AccountInfo:
					result = IsValidAccountInfoRequest(request);
					break;
				case RequestType.AccountInfoInvalidToken:
					result = !IsValidAccountInfoRequest(request);
					break;
				case RequestType.AccountInfoNullToken:
					result = !IsValidAccountInfoRequest(request) && IsNullAccessToken();
					break;

				// Algorithms
				case RequestType.Algorithms:
					result = request.Resource == "api/info/algorithms.json";
					break;

				// FileEndings
				case RequestType.FileEndings:
					result = request.Resource == "api/info/file_endings.json";
					break;

				// OutputFile
				case RequestType.OutputFiles:
					result = request.Resource == "api/info/output_files.json";
					break;

				// ProductionStatus
				case RequestType.ProductionStatus:
					result = request.Resource == "api/info/production_status.json";
					break;

				// ServiceTypes
				case RequestType.ServiceTypes:
					result = request.Resource == "api/info/service_types.json";
					break;

				// Info
				case RequestType.Info:
					result = request.Resource == "api/info.json";
					break;
			}

			return result;
		}

		private bool IsValidAuthenticateRequest(IRestRequest request)
		{
			var clientId = request.Parameters.Find(p => p.Name == "client_id");
			var username = request.Parameters.Find(p => p.Name == "username");
			var password = request.Parameters.Find(p => p.Name == "password");
			var grantType = request.Parameters.Find(p => p.Name == "grant_type");
			var authHeader = GetAuthHeader();

			bool isValid = request.Resource == "oauth2/token/" &&
				clientId?.Value.ToString() == "clientId" &&
				username?.Value.ToString() == "username" &&
				password?.Value.ToString() == "password" &&
				grantType?.Value.ToString() == "password" &&
				authHeader == AuthHeader;

			return isValid;
		}

		private bool IsInvalidAuthenticateRequest(IRestRequest request, RequestType requestType)
		{
			var clientId = request.Parameters.Find(p => p.Name == "client_id");
			var username = request.Parameters.Find(p => p.Name == "username");
			var password = request.Parameters.Find(p => p.Name == "password");
			var authHeader = GetAuthHeader();

			bool isValid = request.Resource == "oauth2/token/";

			if (requestType == RequestType.AuthenticateInvalidClientId)
			{
				isValid &= authHeader == AuthHeaderInvalidClientId;
			}

			if (requestType == RequestType.AuthenticateInvalidClientSecret)
			{
				isValid &= authHeader == AuthHeaderInvalidClientSecret;
			}

			if (requestType == RequestType.AuthenticateInvalidUsername)
			{
				isValid &= username.Value.ToString() != "username" &&
					authHeader == AuthHeader;
			}

			if (requestType == RequestType.AuthenticateInvalidPassword)
			{
				isValid &= password.Value.ToString() != "password" &&
					authHeader == AuthHeader;
			}

			return isValid;
		}

		private bool IsValidAccountInfoRequest(IRestRequest request)
		{
			var authenticator = (OAuth2AuthorizationRequestHeaderAuthenticator)Client.Authenticator;

			bool isValid = request.Resource == "api/user.json" &&
				authenticator?.AccessToken == AccessToken;

			return isValid;
		}
		#endregion

		#region Private Methods - Responses
		private IRestResponse<Response<T>> GetInvalidTokenResponse<T>() where T : new()
		{
			IRestResponse<Response<T>> response = GetResponse<T>("json/auth_invalid_token.json");
			response.StatusCode = HttpStatusCode.InternalServerError;

			return response;
		}

		private IRestResponse<Response<T>> GetNullTokenResponse<T>() where T : new()
		{
			IRestResponse<Response<T>> response = GetResponse<T>("json/auth_null_token.json");
			response.StatusCode = HttpStatusCode.InternalServerError;

			return response;
		}

		private IRestResponse<OAuthToken> GetAuthenticateResponse()
		{
			return GetDefaultResponse<OAuthToken>("json/token.json");
		}

		private IRestResponse<OAuthToken> GetAuthenticateInvalidResponse(RequestType requestType)
		{
			string jsonFile = null;
			HttpStatusCode statusCode = HttpStatusCode.OK;

			switch (requestType)
			{
				case RequestType.AuthenticateInvalidClientId:
					jsonFile = "json/token_invalid_client_id.json";
					statusCode = HttpStatusCode.Unauthorized;
					break;
				case RequestType.AuthenticateInvalidClientSecret:
					jsonFile = "json/token_invalid_client_secret.json";
					statusCode = HttpStatusCode.Unauthorized;
					break;
				case RequestType.AuthenticateInvalidUsername:
				case RequestType.AuthenticateInvalidPassword:
					jsonFile = "json/token_invalid_username_password.json";
					statusCode = HttpStatusCode.BadRequest;
					break;
			}

			IRestResponse<OAuthToken> response = GetDefaultResponse<OAuthToken>(jsonFile);
			response.StatusCode = statusCode;

			return response;
		}

		private IRestResponse<Response<Account>> GetAccountInfoResponse()
		{
			return GetResponse<Account>("json/user.json");
		}

		private IRestResponse<Response<Dictionary<string, Algorithm>>> GetAlgorithmsResponse()
		{
			return GetResponse<Dictionary<string, Algorithm>>("json/algorithms.json");
		}

		private IRestResponse<Response<Dictionary<string, List<string>>>> GetFileEndingsResponse()
		{
			return GetResponse<Dictionary<string, List<string>>>("json/file_endings.json");
		}

		private IRestResponse<Response<Dictionary<string, OutputFile>>> GetOutputFilesResponse()
		{
			return GetResponse<Dictionary<string, OutputFile>>("json/output_files.json");
		}

		private IRestResponse<Response<Dictionary<string, string>>> GetProductionStatusResponse()
		{
			return GetResponse<Dictionary<string, string>>("json/production_status.json");
		}

		private IRestResponse<Response<Dictionary<string, ServiceType>>> GetServiceTypeResponse()
		{
			return GetResponse<Dictionary<string, ServiceType>>("json/service_types.json");
		}

		private IRestResponse<Response<Info>> GetInfoResponse()
		{
			return GetResponse<Info>("json/info.json");
		}
		#endregion
	}
}