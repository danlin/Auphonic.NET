using System;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Represents the Auphonic account.
	/// </summary>
	public class Account
	{
		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public decimal Credits { get; internal set; }

		/// <summary>
		/// Gets the user join date.
		/// </summary>
		public DateTime DateJoined { get; internal set; }

		/// <summary>
		/// Gets the user email.
		/// </summary>
		public string Email { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public bool ErrorEmail { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public bool LowCreditsEmail { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal LowCreditsThreshold { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public bool NotificationEmail { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal OnetimeCredits { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime RechargeDate { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal RechargeRecurringCredits { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal RecurringCredits { get; internal set; }

		/// <summary>
		/// Gets the user ID.
		/// </summary>
		public string UserId { get; internal set; }

		/// <summary>
		/// Gets the username.
		/// </summary>
		public string Username { get; internal set; }

		/// <summary>
		/// 
		/// </summary>
		public bool WarningEmail { get; internal set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="Account"/> class.
		/// </summary>
		public Account()
		{
			DateJoined = DateTime.MinValue;
			RechargeDate = DateTime.MinValue;
		}
		#endregion

		#region Public Override Methods
		/// <inheritdoc/>
		public override string ToString()
		{
			return Username;
		}
		#endregion
	}
}