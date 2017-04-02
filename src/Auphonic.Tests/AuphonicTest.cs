using AuphonicNet.Classes;
using AuphonicNet.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuphonicNet.Tests
{
	[TestFixture]
	public class AuphonicTest : RestClientMock
	{
		#region Private Constants
		private const string MessageNoCredentials = "No authentication credentials provided.";
		#endregion

		#region Private Fields
		private Auphonic _auphonic;
		private AuphonicService _auphonicService;
		#endregion

		#region Constructor
		public AuphonicTest()
			: base()
		{
		}
		#endregion

		#region SetUp
		[SetUp]
		public void SetUp()
		{
			_auphonicService = new AuphonicService(Client);
			_auphonic = new Auphonic(ClientId, ClientSecret, _auphonicService);
		}
		#endregion

		#region Tests - Constructor
		[TestCase(null, null, "clientId")]
		[TestCase(ClientId, null, "clientSecret")]
		public void Initialize_Constructor_With_Null_Parameters_Throws_ArgumentNullException(string clientId, string clientSecret, string expectedParamName)
		{
			Assert.That(() => new Auphonic(clientId, clientSecret), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo(expectedParamName));
		}

		[TestCase("", "", "clientId")]
		[TestCase(ClientId, "", "clientSecret")]
		public void Initialize_Constructor_With_Empty_Parameters_Throws_ArgumentException(string clientId, string clientSecret, string expectedParamName)
		{
			Assert.That(() => new Auphonic(clientId, clientSecret), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo(expectedParamName));
		}

		[Test]
		public void Initialize_Constructor_With_Valid_Parameters()
		{
			Auphonic auphonic = null;

			Assert.That(() => auphonic = new Auphonic(ClientId, ClientSecret), Throws.Nothing);
			Assert.That(auphonic.ClientId, Is.EqualTo(ClientId));
			Assert.That(auphonic.ClientSecret, Is.EqualTo(ClientSecret));
		}
		#endregion

		#region Tests - Authenticate
		[TestCase(null, null, "username")]
		[TestCase(Username, null, "password")]
		public void Authenticate_With_Null_Parameters_Throws_ArgumentNullException(string username, string password, string expectedParamName)
		{
			Assert.That(() => _auphonic.Authenticate(username, password), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo(expectedParamName));
		}

		[TestCase("", "", "username")]
		[TestCase(Username, "", "password")]
		public void Authenticate_With_Empty_Parameters_Throws_ArgumentException(string username, string password, string expectedParamName)
		{
			Assert.That(() => _auphonic.Authenticate(username, password), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo(expectedParamName));
		}

		[Test]
		public void Authenticate_With_Valid_Parameters_Returns_Valid_Result()
		{
			string accessToken = null;

			Assert.That(() => accessToken = _auphonic.Authenticate(Username, Password), Throws.Nothing);
			Assert.That(accessToken, Is.EqualTo(AccessToken));
		}

		[Test]
		public void Authenticate_With_Null_Parameter_Throws_ArgumentNullException()
		{
			Assert.That(() => _auphonic.Authenticate(null), Throws
				.InstanceOf<ArgumentNullException>()
				.And.Property("ParamName").EqualTo("accessToken"));
		}

		[Test]
		public void Authenticate_With_Empty_Parameter_Throws_ArgumentException()
		{
			Assert.That(() => _auphonic.Authenticate(""), Throws
				.InstanceOf<ArgumentException>()
				.And.Property("ParamName").EqualTo("accessToken"));
		}

		[Test]
		public void Authenticate_With_Valid_Parameter()
		{
			Assert.That(() => _auphonic.Authenticate(AccessToken), Throws.Nothing);
		}
		#endregion

		#region Tests - AccountInfo
		[Test]
		public void GetAccountInfo_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetAccountInfo(), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetAccountInfo_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			Account account = null;

			Assert.That(() => account = _auphonic.GetAccountInfo(), Throws.Nothing);
			Assert.That(account, Is.Not.Null);
		}
		#endregion

		#region Tests - Algorithms
		[Test]
		public void GetAlgorithms_Returns_Valid_Result()
		{
			Dictionary<string, Algorithm> algorithms = null;

			Assert.That(() => algorithms = _auphonic.GetAlgorithms(), Throws.Nothing);
			Assert.That(algorithms, Is.Not.Null);
		}
		#endregion

		#region Tests - File Endings
		[Test]
		public void GetFileEndings_Returns_Valid_Result()
		{
			Dictionary<string, List<string>> fileEndings = null;

			Assert.That(() => fileEndings = _auphonic.GetFileEndings(), Throws.Nothing);
			Assert.That(fileEndings, Is.Not.Null);
		}
		#endregion

		#region Tests - OutputFiles
		[Test]
		public void GetOutputFiles_Returns_Valid_Result()
		{
			Dictionary<string, OutputFile> outputFiles = null;

			Assert.That(() => outputFiles = _auphonic.GetOutputFiles(), Throws.Nothing);
			Assert.That(outputFiles, Is.Not.Null);
		}
		#endregion

		#region Tests - ProductionStatus
		[Test]
		public void GetProductionStatus_Returns_Valid_Result()
		{
			Dictionary<string, string> outputFiles = null;

			Assert.That(() => outputFiles = _auphonic.GetProductionStatus(), Throws.Nothing);
			Assert.That(outputFiles, Is.Not.Null);
		}
		#endregion

		#region Tests - ServiceTypes
		[Test]
		public void GetServiceTypes_Returns_Valid_Result()
		{
			Dictionary<string, ServiceType> serviceTypes = null;

			Assert.That(() => serviceTypes = _auphonic.GetServiceTypes(), Throws.Nothing);
			Assert.That(serviceTypes, Is.Not.Null);
		}
		#endregion

		#region Tests - Info
		[Test]
		public void GetInfo_Returns_Valid_Result()
		{
			Info info = null;

			Assert.That(() => info = _auphonic.GetInfo(), Throws.Nothing);
			Assert.That(info, Is.Not.Null);
		}
		#endregion

		#region Tests - Productions
		[Test]
		public void DeleteProduction_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.DeleteProduction(ValidUuid), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void DeleteProduction_With_Authentication_Throws_Nothing()
		{
			_auphonic.Authenticate(AccessToken);

			Assert.That(() => _auphonic.DeleteProduction(ValidUuid), Throws.Nothing);
		}

		[Test]
		public void GetProduction_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetProduction(null), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetProduction_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			Production production = null;

			Assert.That(() => production = _auphonic.GetProduction("uuid"), Throws.Nothing);
			Assert.That(production, Is.Not.Null);
		}

		[Test]
		public void GetProductions_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetProductions(), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetProductions_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<Production> productions = null;

			Assert.That(() => productions = _auphonic.GetProductions(), Throws.Nothing);
			Assert.That(productions, Is.Not.Null);
		}

		[Test]
		public void GetProductions_With_Limit_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetProductions(1), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetProductions_With_Limit_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<Production> productions = null;

			Assert.That(() => productions = _auphonic.GetProductions(1), Throws.Nothing);
			Assert.That(productions, Is.Not.Null);
		}

		[Test]
		public void GetProductions_With_Limit_And_Offset_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetProductions(1, 1), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetProductions_With_Limit_And_Offset_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<Production> productions = null;

			Assert.That(() => productions = _auphonic.GetProductions(1, 1), Throws.Nothing);
			Assert.That(productions, Is.Not.Null);
		}

		[Test]
		public void GetProductionsUuids_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetProductionsUuids(), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetProductionsUuids_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<string> productionsUuids = null;

			Assert.That(() => productionsUuids = _auphonic.GetProductionsUuids(), Throws.Nothing);
			Assert.That(productionsUuids, Is.Not.Null);
		}
		#endregion

		#region Tests - Presets
		[Test]
		public void DeletePreset_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.DeletePreset(ValidUuid), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void DeletePreset_With_Authentication_Throws_Nothing()
		{
			_auphonic.Authenticate(AccessToken);

			Assert.That(() => _auphonic.DeletePreset(ValidUuid), Throws.Nothing);
		}

		[Test]
		public void GetPreset_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetPreset(null), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetPreset_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			Preset preset = null;

			Assert.That(() => preset = _auphonic.GetPreset("uuid"), Throws.Nothing);
			Assert.That(preset, Is.Not.Null);
		}

		[Test]
		public void GetPresets_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetPresets(), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetPresets_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<Preset> presets = null;

			Assert.That(() => presets = _auphonic.GetPresets(), Throws.Nothing);
			Assert.That(presets, Is.Not.Null);
		}

		[Test]
		public void GetPresets_Limit_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetPresets(1), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetPresets_With_Limit_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<Preset> presets = null;

			Assert.That(() => presets = _auphonic.GetPresets(1), Throws.Nothing);
			Assert.That(presets, Is.Not.Null);
		}

		[Test]
		public void GetPresets_Limit__And_Offset_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetPresets(1, 1), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetPresets_With_Limit_And_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<Preset> presets = null;

			Assert.That(() => presets = _auphonic.GetPresets(1, 1), Throws.Nothing);
			Assert.That(presets, Is.Not.Null);
		}

		[Test]
		public void GetPresetsUuids_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetPresetsUuids(), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetPresetsUuids_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<string> productionsUuids = null;

			Assert.That(() => productionsUuids = _auphonic.GetPresetsUuids(), Throws.Nothing);
			Assert.That(productionsUuids, Is.Not.Null);
		}
		#endregion

		#region Tests - Services
		[Test]
		public void GetServices_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetServices(), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetServices_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<Service> services = null;

			Assert.That(() => services = _auphonic.GetServices(), Throws.Nothing);
			Assert.That(services, Is.Not.Null);
		}

		[Test]
		public void GetServiceFiles_Without_Authentication_Throws_AuphonicException()
		{
			Assert.That(() => _auphonic.GetServiceFiles("uuid"), Throws
				.InstanceOf<AuphonicException>()
				.And.Property("ErrorCode").EqualTo("")
				.And.Property("ErrorMessage").EqualTo(MessageNoCredentials));
		}

		[Test]
		public void GetServiceFiles_With_Authentication_Returns_Valid_Result()
		{
			_auphonic.Authenticate(AccessToken);
			List<string> files = null;

			Assert.That(() => files = _auphonic.GetServiceFiles("uuid"), Throws.Nothing);
			Assert.That(files, Is.Not.Null);
		}
		#endregion
	}
}