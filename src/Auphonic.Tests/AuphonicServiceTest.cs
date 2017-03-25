﻿using AuphonicNet.Classes;
using AuphonicNet.OAuth;
using AuphonicNet.Tests.Mock;
using NUnit.Framework;
using System;

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


	}
}