namespace AuphonicNet.OAuth
{
	/// <summary>
	/// Provides a <see cref="OAuthToken"/> class.
	/// </summary>
	internal class OAuthToken
	{
		#region Public Properties
		public string AccessToken { get; set; }

		public string TokenType { get; set; }

		public int ExpiresIn { get; set; }

		public string UserName { get; set; }

		public string Scope { get; set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="OAuthToken"/> class.
		/// </summary>
		public OAuthToken()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OAuthToken"/> class.
		/// </summary>
		public OAuthToken(string accessToken)
			: this(accessToken, "bearer", 315360000, null, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OAuthToken"/> class.
		/// </summary>
		public OAuthToken(string accessToken, string tokenType, int expiresIn, string userName, string scope)
		{
			AccessToken = accessToken;
			TokenType = tokenType;
			ExpiresIn = expiresIn;
			UserName = userName;
			Scope = scope;
		}
		#endregion
	}
}