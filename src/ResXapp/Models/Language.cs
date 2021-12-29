using System;
using System.Collections.Generic;

namespace ResXapp.Models;

public record Language
{
    public string Name { get; init; }
    public Dictionary<string, Translation> Translations { get; } = new();
}

public record Translation
{
    public string Key { get; init; }
    public string Value { get; set; }
}
