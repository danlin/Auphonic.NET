using AuphonicNet.Classes;
using AuphonicNet.Tests.Mock;
using NUnit.Framework;
using System;

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
	}
}