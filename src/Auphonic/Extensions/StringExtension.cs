namespace AuphonicNet.Extensions
{
	internal static class StringExtension
	{
		#region Public Static Methods
		public static bool IsNullOrWhiteSpace(this string str)
		{
			return string.IsNullOrWhiteSpace(str);
		}
		#endregion
	}
}