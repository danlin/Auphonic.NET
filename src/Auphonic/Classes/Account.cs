using System;

namespace AuphonicNet.Classes
{
	/// <summary>
	/// Provides a <see cref="Account"/> class.
	/// </summary>
	public class Account
	{
		#region Public Properties
		public string UserId { get; set; }

		public string Username { get; set; }

		public DateTime DateJoined { get; set; }

		public string Email { get; set; }

		public decimal Credits { get; set; }

		public decimal OnetimeCredits { get; set; }

		public decimal RecurringCredits { get; set; }

		public DateTime RechargeDate { get; set; }

		public decimal RechargeRecurringCredits { get; set; }

		public bool NotificationEmail { get; set; }

		public bool ErrorEmail { get; set; }

		public bool WarningEmail { get; set; }

		public bool LowCreditsEmail { get; set; }

		public decimal LowCreditsThreshold { get; set; }
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
	}
}