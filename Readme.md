# .NET 8 Redacted Logging

[Andrew Lock's blog post on the Redaction library](https://andrewlock.net/redacting-sensitive-data-with-microsoft-extensions-compliance/) inspired this sample. While his blog post assumes folks are using ASP.NET Core templates, this sample does not. I have included all the necessary packages to apply redaction to any .NET project.

```html
<PackageReference Include="Microsoft.Extensions.Compliance.Redaction" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.0"/>
<PackageReference Include="Microsoft.Extensions.Telemetry" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.Telemetry.Abstractions" Version="8.0.0" />
```

These packages include the redaction mechanism and the extension methods required to register them. The `Telemetry` packages also include the source generators required to generate log methods at compile time.

There are also multiple redactors at play here:

- Hmac Redactor
- Classified Redcator
- Emoticon Redactor

I ended up using the `AddJsonConsole()` output method so it would be easier to see that logs are indeed being redacted properly. The redacted logs look like this:

```text
{"EventId":0,"LogLevel":"Information","Category":"Redacted.Worker","Message":"Worker running at: 12/12/2023 13:14:26 -05:00 ","State":{"Message":"Microsoft.Extensions.Logging.ExtendedLogger\u002BModernTagJoiner","{OriginalFormat}":"Worker running at: {Now} ","Now":"12/12/2023 13:14:26 -05:00","secrets.FavoriteFood":":{","secrets.Password":"CLASSIFIED","secrets.Name":"1:K9PYjfOkXD67ZDssSbrOuA=="}}
```

I strongly suggest you read Andrew Lock's blog post for edge cases and "gotchas".

Cheers :)