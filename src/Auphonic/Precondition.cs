using System;

namespace AuphonicNet
{
	/// <summary>
	/// Provides static methods that help a constructor or method to verify correct arguments and
	/// state.
	/// </summary>
	internal static class Precondition
	{
		#region Public Static Methods - Object
		/// <summary>
		/// Checks whether the specified object is not <strong>null</strong>.
		/// </summary>
		/// <param name="obj">The object to test.</param>
		/// <exception cref="ArgumentNullException"><em>obj</em> is
		/// <strong>null</strong>.</exception>
		public static void IsNotNull(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException();
			}
		}

		/// <summary>
		/// Checks whether the specified object is not <strong>null</strong>.
		/// </summary>
		/// <param name="obj">The object to test.</param>
		/// <param name="paramName">The name of the parameter that caused the exception.</param>
		/// <exception cref="ArgumentNullException"><em>obj</em> is
		/// <strong>null</strong>.</exception>
		public static void IsNotNull(object obj, string paramName)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(paramName);
			}
		}

		/// <summary>
		/// Checks whether the specified object is not <strong>null</strong>.
		/// </summary>
		/// <param name="obj">The object to test.</param>
		/// <param name="paramName">The name of the parameter that caused the exception.</param>
		/// <param name="message">A message that describes the error.</param>
		/// <exception cref="ArgumentNullException"><em>obj</em> is
		/// <strong>null</strong>.</exception>
		public static void IsNotNull(object obj, string paramName, string message)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(paramName, message);
			}
		}
		#endregion

		#region Public Static Methods - String
		/// <summary>
		/// Checks whether a specified string is not <strong>null</strong>, empty, or consists only
		/// of white-space characters.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <exception cref="ArgumentNullException"><em>str</em> is
		/// <strong>null</strong>.</exception>
		/// <exception cref="ArgumentException"><em>str</em> is
		/// <strong>whitespace</strong>.</exception>
		public static void IsNotNullOrWhiteSpace(string str)
		{
			if (str == null)
			{
				throw new ArgumentNullException();
			}
			else if (string.IsNullOrWhiteSpace(str))
			{
				string message = "Value cannot consists only of white-space characters.";
				throw new ArgumentException(message);
			}
		}

		/// <summary>
		/// Checks whether a specified string is not <strong>null</strong>, empty, or consists only
		/// of white-space characters.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <param name="paramName">The name of the parameter that caused the exception.</param>
		/// <exception cref="ArgumentNullException"><em>str</em> is
		/// <strong>null</strong>.</exception>
		/// <exception cref="ArgumentException"><em>str</em> is
		/// <strong>whitespace</strong>.</exception>
		public static void IsNotNullOrWhiteSpace(string str, string paramName)
		{
			if (str == null)
			{
				throw new ArgumentNullException(paramName);
			}
			else if (string.IsNullOrWhiteSpace(str))
			{
				string message = "Value cannot consists only of white-space characters.";
				throw new ArgumentException(message, paramName);
			}
		}

		/// <summary>
		/// Checks whether a specified string is not <strong>null</strong>, empty, or consists only
		/// of white-space characters.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <param name="paramName">The name of the parameter that caused the exception.</param>
		/// <param name="messageArgNull">A message that describes the null error.</param>
		/// <param name="messageArgWhiteSpace">A message that describes the whitespace
		/// error.</param>
		/// <exception cref="ArgumentNullException"><em>str</em> is
		/// <strong>null</strong>.</exception>
		/// <exception cref="ArgumentException"><em>str</em> is
		/// <strong>whitespace</strong>.</exception>
		public static void IsNotNullOrWhiteSpace(string str, string paramName, string messageArgNull, string messageArgWhiteSpace)
		{
			if (str == null)
			{
				throw new ArgumentNullException(paramName, messageArgNull);
			}
			else if (string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException(messageArgWhiteSpace, paramName);
			}
		}
		#endregion
	}
}