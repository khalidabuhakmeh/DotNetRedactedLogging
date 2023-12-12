using Microsoft.Extensions.Compliance.Classification;

namespace Redacted.Redaction;

public static class Taxonomy
{
    private static string Name => typeof(Taxonomy).FullName!;
    public static DataClassification Sensitive => new(Name, nameof(Sensitive));
    public static DataClassification Personal => new(Name, nameof(Personal));
    public static DataClassification Default => new(Name, nameof(Default));
}

public class SensitiveAttribute() : DataClassificationAttribute(Taxonomy.Sensitive);
public class PersonalAttribute() : DataClassificationAttribute(Taxonomy.Personal);

public class DefaultAttribute() : DataClassificationAttribute(Taxonomy.Default);