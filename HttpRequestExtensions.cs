using System;
using System.Web;

namespace SyntaxTree.FastSpring
{
	public static class HttpRequestExtensions
	{
		public static bool IsValidNotification(this HttpRequest request, string privateKey)
		{
			CheckRequest(request, privateKey);

			return request.Form.IsValidNotification(privateKey);
		}

		public static bool IsValidLicenseRequest(this HttpRequest request, string privateKey)
		{
			CheckRequest(request, privateKey);

			return request.Form.IsValidLicenseRequest(privateKey);
		}

		private static void CheckRequest(HttpRequest request, string privateKey)
		{
			if (request == null)
				throw new ArgumentNullException("request");
			if (privateKey == null)
				throw new ArgumentNullException("privateKey");
			if (privateKey.Length == 0)
				throw new ArgumentException("Empty private key", "privateKey");
		}
	}
}