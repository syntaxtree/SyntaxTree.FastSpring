using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SyntaxTree.FastSpring
{
	internal static class FastSpringFormValidator
	{
		public static bool IsValidNotification(this NameValueCollection form, string privateKey)
		{
			const string dataParameter = "security_data";
			const string hashParameter = "security_hash";

			if (!form.HasParameter(dataParameter) || !form.HasParameter(hashParameter))
				return false;

			var value = form[dataParameter] + privateKey;

			return form.HashMatches(hashParameter, value);
		}

		public static bool IsValidLicenseRequest(this NameValueCollection form, string privateKey)
		{
			const string hashParameter = "security_request_hash";

			if (!form.HasParameter(hashParameter))
				return false;

			var value = form.AllKeys
				.Where(k => k != hashParameter)
				.OrderBy(k => k)
				.Select(k => form[k])
				.Aggregate(new StringBuilder(), (sb, v) => sb.Append(v))
				.Append(privateKey)
				.ToString();

			return form.HashMatches(hashParameter, value);
		}

		private static bool HashMatches(this NameValueCollection form, string hashParameter, string value)
		{
			return form[hashParameter].ToLowerInvariant() == Md5HashOf(value);
		}

		private static bool HasParameter(this NameValueCollection form, string parameter)
		{
			return form[parameter] != null;
		}

		private static string Md5HashOf(string value)
		{
			return MD5.Create()
				.ComputeHash(Encoding.UTF8.GetBytes(value))
				.Aggregate(new StringBuilder(), (sb, b) => sb.Append(b.ToString("x2")))
				.ToString();
		}
	}
}
