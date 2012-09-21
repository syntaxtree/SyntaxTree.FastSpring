using System;
using System.Web;

namespace SyntaxTree.FastSpring
{
	public static class HttpRequestBaseExtensions
	{
		public static bool IsValidNotification(this HttpRequestBase request, string privateKey)
		{
			CheckRequest(request, privateKey);

			return request.Form.IsValidNotification(privateKey);
		}

		public static bool IsValidLicenseRequest(this HttpRequestBase request, string privateKey)
		{
			CheckRequest(request, privateKey);

			return request.Form.IsValidLicenseRequest(privateKey);
		}

		private static void CheckRequest(HttpRequestBase request, string privateKey)
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
