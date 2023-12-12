using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Compliance.Redaction;
using Redacted;
using Redacted.Redaction;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Logging.AddJsonConsole();
builder.Logging.EnableRedaction();
builder.Services.AddRedaction(r =>
{
    r.SetFallbackRedactor<Emoticon>();
    r.SetRedactor<Classified>(new DataClassificationSet(Taxonomy.Sensitive));
#pragma warning disable EXTEXP0002
    r.SetHmacRedactor(o =>
    {
        // ⚠️ get these settings from configuration, this is a demo 
        // note that keys have to be at least 44 characters long
        o.Key = Convert.ToBase64String("5Ghbv2XsCG6bS8zn9JaK4mQl7T0YdxFRPAZ3o1eUVwkjtr6yp"u8);
        o.KeyId = 1;
    }, new DataClassificationSet(Taxonomy.Personal));
});

var host = builder.Build();
host.Run();