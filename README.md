## SyntaxTree.FastSpring

SyntaxTree.FastSpring is a C# helper library to validate the different requests [FastSpring](http://www.fastspring/) can send.

It works on .NET 3.5, .NET 4.0 and .NET 4.5.
It supports both ASP.NET MVC and the ASP.NET WebForms.

## API

***

For ASP.NET MVC.

```csharp
namespace SyntaxTree.FastSpring
{
	public sealed class HttpRequestBaseExtensions
	{
		public static bool IsValidNotification (this HttpRequestBase request, string privateKey) {}
		public static bool IsValidLicenseRequest (this HttpRequestBase request, string privateKey) {}
	}
}
```

> Test the validity of a request.

Usage from a controller:

```csharp
using SyntaxTree.FastSpring;

public class NotificationController : Controller
{
	[HttpPost]
	public ActionResult Order(
		string customerCompany,
		string customerEmail,
		string customerFirstName,
		string customerLastName,
		string customerPhone,
		string orderId)
	{
		const string privateKey = "75f0fff79f988c10b2c4f6315aec5a86";

		if (!Request.IsValidRequest(privateKey))
			// ...

		// ...
	}
}
```

The API for the ASP.NET WebForms is exactly the same except that we define the extension methods on the type System.Web.HttpRequest.
