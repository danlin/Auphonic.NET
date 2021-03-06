﻿using AuphonicNet.Classes;
using AuphonicNet.OAuth;
using AuphonicNet.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuphonicNet.Tests
{
	[TestFixture]
	public class AuphonicServiceTest : RestClientMock
	{
		#region Public Constants
		private const string MessageInvalidToken = "Token doesn't exist";
		private const string MessageNullToken = "Request authentication failed, no authentication credentials provided.";
		#endregion

		#region Private Fields
		private AuphonicService _auphonicService;
		#endregion

		#region Constructor
		public AuphonicServiceTest()
			: base()
		{
		}
		#endregion

		#region SetUp
		[SetUp]
		public void SetUp()
		{
			_auphonicService = new AuphonicService(Client);
		}
		#endregion

		#region Tests - Constructor
		[Test]
		public void Initialize_Constructor_With_Null_Parameters_Throws_ArgumentNullException()
		{
			Assert.That(() => new AuphonicService(null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("client"));
		}

		[Test]
		public void Initialize_Constructor_With_Valid_Parameters()
		{
			Assert.That(() => new AuphonicService(ClientMock.Object), Throws.Nothing);
		}
		#endregion

		#region Tests - Authenticate
		[TestCase(null, null, null, null, "clientId")]
		[TestCase(ClientId, null, null, null, "clientSecret")]
		[TestCase(ClientId, ClientSecret, null, null, "username")]
		[TestCase(ClientId, ClientSecret, Username, null, "password")]
		public void Authenticate_With_Null_Parameters_Throws_ArgumentNullException(string clientId, string clientSecret, string username, string password, string expectedParamName)
		{
			Assert.That(() => _auphonicService.Authenticate(clientId, clientSecret, username, password), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo(expectedParamName));
		}

		[TestCase("", "", "", "", "clientId")]
		[TestCase(ClientId, "", "", "", "clientSecret")]
		[TestCase(ClientId, ClientSecret, "", "", "username")]
		[TestCase(ClientId, ClientSecret, Username, "", "password")]
		public void Authenticate_With_Empty_Parameters_Throws_ArgumentException(string clientId, string clientSecret, string username, string password, string expectedParamName)
		{
			Assert.That(() => _auphonicService.Authenticate(clientId, clientSecret, username, password), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo(expectedParamName));
		}

		[TestCase("invalid", "invalid", "invalid", "invalid", "invalid_client", "client_id invalid doesn't exist")]
		[TestCase(ClientId, "invalid", "invalid", "invalid", "invalid_client", "Client authentication failed.")]
		[TestCase(ClientId, ClientSecret, "invalid", "invalid", "invalid_request", "User authentication failed.")]
		[TestCase(ClientId, ClientSecret, Username, "invalid", "invalid_request", "User authentication failed.")]
		public void Authenticate_With_Invalid_Parameters_Throws_AuphonicException(string clientId, string clientSecret, string username, string password, string expectedErrorCode, string expectedErrorMessage)
		{
			OAuthToken token = null;

			Assert.That(() => token = _auphonicService.Authenticate(clientId, clientSecret, username, password), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo(expectedErrorCode)
				.And.Property("ErrorMessage").EqualTo(expectedErrorMessage));
		}

		[Test]
		public void Authenticate_With_Valid_Parameters_Returns_Valid_Result()
		{
			OAuthToken token = null;

			Assert.That(() => token = _auphonicService.Authenticate(ClientId, ClientSecret, Username, Password), Throws.Nothing);
			Assert.That(token, Is.Not.Null);
			Assert.That(token.AccessToken, Is.EqualTo(AccessToken));
			Assert.That(token.TokenType, Is.EqualTo("bearer"));
			Assert.That(token.ExpiresIn, Is.EqualTo(315360000));
			Assert.That(token.UserName, Is.EqualTo("my_auphonic_username"));
			Assert.That(token.Scope, Is.EqualTo(""));
		}
		#endregion

		#region Tests - AccountInfo
		[Test]
		public void GetAccountInfo_With_Null_Parameters_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetAccountInfo(null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetAccountInfo_With_Invalid_Token_Throws_AuphonicException()
		{
			Assert.That(() => _auphonicService.GetAccountInfo(InvalidToken), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo(null)
				.And.Property("ErrorMessage").EqualTo(MessageInvalidToken));
		}

		[Test]
		public void GetAccountInfo_With_Null_Token_Throws_AuphonicException()
		{
			Assert.That(() => _auphonicService.GetAccountInfo(NullToken), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo(null)
				.And.Property("ErrorMessage").EqualTo(MessageNullToken));
		}

		[Test]
		public void GetAccountInfo_With_Valid_Token_Returns_Valid_Result()
		{
			Account account = null;

			Assert.That(() => account = _auphonicService.GetAccountInfo(Token), Throws.Nothing);
			Assert.That(account, Is.Not.Null);
			Assert.That(account.Username, Is.EqualTo("testuser"));
			Assert.That(account.UserId, Is.EqualTo("6ba197a14abb5eee55713fef66feaf71"));
			Assert.That(account.DateJoined, Is.EqualTo(new DateTime(2013, 2, 28, 21, 20, 3)));
			Assert.That(account.Email, Is.EqualTo("grh@auphonic.com"));
			Assert.That(account.Credits, Is.EqualTo(2.87309201310154));
			Assert.That(account.OnetimeCredits, Is.EqualTo(1.0));
			Assert.That(account.RecurringCredits, Is.EqualTo(1.87309201310154));
			Assert.That(account.RechargeDate, Is.EqualTo(new DateTime(2014, 5, 28, 21, 20, 3)));
			Assert.That(account.RechargeRecurringCredits, Is.EqualTo(2.0));
			Assert.That(account.NotificationEmail, Is.True);
			Assert.That(account.ErrorEmail, Is.True);
			Assert.That(account.WarningEmail, Is.True);
			Assert.That(account.LowCreditsEmail, Is.False);
			Assert.That(account.LowCreditsThreshold, Is.EqualTo(10));
		}
		#endregion

		#region Tests - Algorithms
		[Test]
		public void GetAlgorithms_Returns_Valid_Result()
		{
			Dictionary<string, AlgorithmType> algorithms = null;

			Assert.That(() => algorithms = _auphonicService.GetAlgorithmType(), Throws.Nothing);
			Assert.That(algorithms.Values.Count, Is.GreaterThan(0));
			Assert.That(algorithms.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));
		}
		#endregion

		#region Tests - File Endings
		[Test]
		public void GetFileEndings_Returns_Valid_Result()
		{
			Dictionary<string, List<string>> fileEndings = null;

			Assert.That(() => fileEndings = _auphonicService.GetFileEndings(), Throws.Nothing);
			Assert.That(fileEndings.Values.Count, Is.GreaterThan(0));
			Assert.That(fileEndings.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));
		}
		#endregion

		#region Tests - OutputFiles
		[Test]
		public void GetOutputFiles_Returns_Valid_Result()
		{
			Dictionary<string, OutputFileType> outputFiles = null;

			Assert.That(() => outputFiles = _auphonicService.GetOutputFileTypes(), Throws.Nothing);
			Assert.That(outputFiles.Values.Count, Is.GreaterThan(0));
			Assert.That(outputFiles.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));
		}
		#endregion

		#region Tests - ProductionStatus
		[Test]
		public void GetProductionStatus_Returns_Valid_Result()
		{
			Dictionary<string, string> productionStatus = null;

			Assert.That(() => productionStatus = _auphonicService.GetProductionStatus(), Throws.Nothing);
			Assert.That(productionStatus.Values.Count, Is.GreaterThan(0));
			Assert.That(productionStatus.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));
		}
		#endregion

		#region Tests - ServiceTypes
		[Test]
		public void GetServiceTypes_Returns_Valid_Result()
		{
			Dictionary<string, ServiceType> serviceTypes = null;

			Assert.That(() => serviceTypes = _auphonicService.GetServiceTypes(), Throws.Nothing);
			Assert.That(serviceTypes.Values.Count, Is.GreaterThan(0));
			Assert.That(serviceTypes.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));
		}
		#endregion

		#region Tests - Info
		[Test]
		public void GetInfo_Returns_Valid_Result()
		{
			Info info = null;

			Assert.That(() => info = _auphonicService.GetInfo(), Throws.Nothing);
			Assert.That(info, Is.Not.Null);

			Assert.That(info.AlgorithmTypes, Is.Not.Null);
			Assert.That(info.AlgorithmTypes.Values.Count, Is.GreaterThan(0));
			Assert.That(info.AlgorithmTypes.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));

			Assert.That(info.FileEndings, Is.Not.Null);
			Assert.That(info.FileEndings.Values.Count, Is.GreaterThan(0));
			Assert.That(info.FileEndings.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));

			Assert.That(info.OutputFileTypes, Is.Not.Null);
			Assert.That(info.OutputFileTypes.Values.Count, Is.GreaterThan(0));
			Assert.That(info.OutputFileTypes.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));

			Assert.That(info.ProductionStatus, Is.Not.Null);
			Assert.That(info.ProductionStatus.Values.Count, Is.GreaterThan(0));
			Assert.That(info.ProductionStatus.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));

			Assert.That(info.ServiceTypes, Is.Not.Null);
			Assert.That(info.ServiceTypes.Values.Count, Is.GreaterThan(0));
			Assert.That(info.ServiceTypes.Values.ToList().FindAll(v => v == null).Count, Is.EqualTo(0));
		}
		#endregion

		#region Tests - Productions
		[Test]
		public void DeleteProduction_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.DeleteProduction(null, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void DeleteProduction_With_Null_Uuid_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.DeleteProduction(Token, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void DeleteProduction_With_Empty_Uuid_Throws_ArgumentException()
		{
			Assert.That(() => _auphonicService.DeleteProduction(Token, ""), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void DeleteProduction_With_Invalid_Uuid_Throws_AuphonicException()
		{
			Assert.That(() => _auphonicService.DeleteProduction(Token, InvalidUuid), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo(null)
				.And.Property("ErrorMessage").EqualTo("Not Found"));
		}

		[Test]
		public void DeleteProduction_With_Valid_Uuid_Throws_Nothing()
		{
			Assert.That(() => _auphonicService.DeleteProduction(Token, ValidUuid), Throws.Nothing);
		}

		[Test]
		public void GetProduction_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetProduction(null, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetProduction_With_Null_Parameter_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetProduction(Token, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void GetProduction_With_Empty_Parameter_Throws_ArgumentException()
		{
			Assert.That(() => _auphonicService.GetProduction(Token, ""), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void GetProduction_Returns_Valid_Result()
		{
			Production production = null;

			Assert.That(() => production = _auphonicService.GetProduction(Token, "uuid"), Throws.Nothing);
			Assert.That(production, Is.Not.Null);
		}

		[Test]
		public void GetProductions_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetProductions(null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));

			Assert.That(() => _auphonicService.GetProductions(null, 0), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));

			Assert.That(() => _auphonicService.GetProductions(null, 0, 0), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetProductions_With_Invalid_Parameters_Throws_ArgumentOutOfRangeException()
		{
			Assert.That(() => _auphonicService.GetProductions(Token, -1), Throws
				.InstanceOf<ArgumentOutOfRangeException>()
				.And.Property("ParamName").EqualTo("limit"));

			Assert.That(() => _auphonicService.GetProductions(Token, 0, -1), Throws
				.InstanceOf<ArgumentOutOfRangeException>()
				.And.Property("ParamName").EqualTo("offset"));
		}

		[Test]
		public void GetProductionsUuids_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetProductionsUuids(null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetProductions_With_Limit_Returns_Valid_Result()
		{
			List<Production> productions = null;

			Assert.That(() => productions = _auphonicService.GetProductions(Token, 1), Throws.Nothing);
			Assert.That(productions, Is.Not.Null);
			Assert.That(productions.Count, Is.GreaterThan(0));
		}

		[Test]
		public void GetProductions_With_Limit_And_Offset_Returns_Valid_Result()
		{
			List<Production> productions = null;

			Assert.That(() => productions = _auphonicService.GetProductions(Token, 1, 1), Throws.Nothing);
			Assert.That(productions, Is.Not.Null);
			Assert.That(productions.Count, Is.GreaterThan(0));
		}

		[Test]
		public void GetProductions_Returns_Valid_Result()
		{
			List<Production> productions = null;

			Assert.That(() => productions = _auphonicService.GetProductions(Token), Throws.Nothing);
			Assert.That(productions, Is.Not.Null);
			Assert.That(productions.Count, Is.GreaterThan(0));
		}

		[Test]
		public void GetProductionsUuids_Returns_Valid_Result()
		{
			List<string> productionsUudis = null;

			Assert.That(() => productionsUudis = _auphonicService.GetProductionsUuids(Token), Throws.Nothing);
			Assert.That(productionsUudis, Is.Not.Null);
			Assert.That(productionsUudis.Count, Is.GreaterThan(0));
		}
		#endregion

		#region Tests - Presets
		[Test]
		public void DeletePreset_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.DeletePreset(null, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void DeletePreset_With_Null_Uuid_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.DeletePreset(Token, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void DeletePreset_With_Empty_Uuid_Throws_ArgumentException()
		{
			Assert.That(() => _auphonicService.DeletePreset(Token, ""), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void DeletePreset_With_Invalid_Uuid_Throws_AuphonicException()
		{
			Assert.That(() => _auphonicService.DeletePreset(Token, InvalidUuid), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo(null)
				.And.Property("ErrorMessage").EqualTo("Not Found"));
		}

		[Test]
		public void DeletePreset_With_Valid_Uuid_Throws_Nothing()
		{
			Assert.That(() => _auphonicService.DeletePreset(Token, ValidUuid), Throws.Nothing);
		}

		[Test]
		public void GetPreset_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetPreset(null, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetPreset_With_Null_Parameter_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetPreset(Token, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void GetPreset_With_Empty_Parameter_Throws_ArgumentException()
		{
			Assert.That(() => _auphonicService.GetPreset(Token, ""), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void GetPreset_Returns_Valid_Result()
		{
			Preset preset = null;

			Assert.That(() => preset = _auphonicService.GetPreset(Token, "uuid"), Throws.Nothing);
			Assert.That(preset, Is.Not.Null);
		}

		[Test]
		public void GetPresets_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetPresets(null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));

			Assert.That(() => _auphonicService.GetPresets(null, 0), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));

			Assert.That(() => _auphonicService.GetPresets(null, 0, 0), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetPresets_With_Invalid_Parameters_Throws_ArgumentOutOfRangeException()
		{
			Assert.That(() => _auphonicService.GetPresets(Token, -1), Throws
				.InstanceOf<ArgumentOutOfRangeException>()
				.And.Property("ParamName").EqualTo("limit"));

			Assert.That(() => _auphonicService.GetPresets(Token, 0, -1), Throws
				.InstanceOf<ArgumentOutOfRangeException>()
				.And.Property("ParamName").EqualTo("offset"));
		}

		[Test]
		public void GetPresetsUuids_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetPresetsUuids(null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetPresets_Returns_Valid_Result()
		{
			List<Preset> presets = null;

			Assert.That(() => presets = _auphonicService.GetPresets(Token), Throws.Nothing);
			Assert.That(presets, Is.Not.Null);
			Assert.That(presets.Count, Is.GreaterThan(0));
		}

		[Test]
		public void GetPresets_With_Limit_Returns_Valid_Result()
		{
			List<Preset> presets = null;

			Assert.That(() => presets = _auphonicService.GetPresets(Token, 1), Throws.Nothing);
			Assert.That(presets, Is.Not.Null);
			Assert.That(presets.Count, Is.GreaterThan(0));
		}

		[Test]
		public void GetPresets_With_Limit_And_Offset_Returns_Valid_Result()
		{
			List<Preset> presets = null;

			Assert.That(() => presets = _auphonicService.GetPresets(Token, 1, 1), Throws.Nothing);
			Assert.That(presets, Is.Not.Null);
			Assert.That(presets.Count, Is.GreaterThan(0));
		}

		[Test]
		public void GetPresetsUuids_Returns_Valid_Result()
		{
			List<string> presetsUudis = null;

			Assert.That(() => presetsUudis = _auphonicService.GetPresetsUuids(Token), Throws.Nothing);
			Assert.That(presetsUudis, Is.Not.Null);
			Assert.That(presetsUudis.Count, Is.GreaterThan(0));
		}
		#endregion

		#region Tests - Services
		[Test]
		public void GetServices_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetServices(null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetServices_Returns_Valid_Result()
		{
			List<Service> services = null;

			Assert.That(() => services = _auphonicService.GetServices(Token), Throws.Nothing);
			Assert.That(services, Is.Not.Null);
		}

		[Test]
		public void GetServiceFiles_With_Null_Token_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetServiceFiles(null, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("token"));
		}

		[Test]
		public void GetServiceFiles_With_Null_Parameters_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonicService.GetServiceFiles(Token, null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void GetServiceFiles_With_Empty_Parameter_Throws_ArgumentException()
		{
			Assert.That(() => _auphonicService.GetServiceFiles(Token, null), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo("uuid"));
		}

		[Test]
		public void GetServiceFiles_Returns_Valid_Result()
		{
			List<string> files = null;

			Assert.That(() => files = _auphonicService.GetServiceFiles(Token, "uuid"), Throws.Nothing);
			Assert.That(files, Is.Not.Null);
		}
		#endregion


	}
}