﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Doulex.Text.Json;

public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    private readonly string _formatter;

    public TimeOnlyConverter(string formatter = "HH:mm:ss")
    {
        _formatter = formatter;
    }

    public override TimeOnly Read(
        ref Utf8JsonReader    reader,
        Type                  typeToConvert,
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return TimeOnly.Parse(value!);
    }

    public override void Write(
        Utf8JsonWriter        writer,
        TimeOnly              value,
        JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(_formatter));
}