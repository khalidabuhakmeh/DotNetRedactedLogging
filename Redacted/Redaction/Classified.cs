using System.Security.Cryptography;
using Microsoft.Extensions.Compliance.Redaction;

namespace Redacted.Redaction;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class Classified : Redactor
{
    private const string ErasedValue = "CLASSIFIED"; // Use this value for sensitive data

    public override int GetRedactedLength(ReadOnlySpan<char> input)
        => ErasedValue.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        // The base class ensures destination has sufficient capacity
        ErasedValue.CopyTo(destination);
        return ErasedValue.Length;
    }
}

public sealed class Emoticon : Redactor
{
    private static readonly string[] Emoticons = [ ":)", ":(", ":{", "(:", "):"];

    public override int GetRedactedLength(ReadOnlySpan<char> input)
        => 2;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        // The base class ensures destination has sufficient capacity
        var emoticon = Emoticons[RandomNumberGenerator.GetInt32(Emoticons.Length)];
        emoticon.CopyTo(destination);
        return emoticon.Length;
    }
}