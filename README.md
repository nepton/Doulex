# Doulex

[![Build status](https://ci.appveyor.com/api/projects/status/iam1vifuu1aqp58e?svg=true)](https://ci.appveyor.com/project/nepton/doulex-xpqy7)
![GitHub issues](https://img.shields.io/github/issues/nepton/Doulex.svg)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/nepton/Doulex/blob/master/LICENSE)

Doulex is a toolkits for daily devs.

## Nuget packages

| Name   | Version                                                                                       | Downloads                                                                                      |
|--------|-----------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------|
| Doulex | [![nuget](https://img.shields.io/nuget/v/Doulex.svg)](https://www.nuget.org/packages/Doulex/) | [![stats](https://img.shields.io/nuget/dt/Doulex.svg)](https://www.nuget.org/packages/Doulex/) |

## Usage

### Basic usage

#### ObjectExtensions.RemoveNullProperty
RemoveNullProperty can remove null property from object.

```csharp
var origin = new
{
    Name    = "John",
    Age     = 30,
    Address = (string?) null,
    Married = (bool?) null,
};
var newDynamic = origin.RemoveNullProperty();

// we got a new dynamic object without null property
// {
//     Name = "John",
//     Age = 30,
// }
```

#### DisposeTracking
DisposeTracking can let you make call when object is out of scope.

```csharp
var obj = 100; // your object
using (var tracker = new DisposeTracking(obj, () => Console.WriteLine("Object is disposed.")))
{
    Console.WriteLine(tracker);     // output is 100
    // do something else
}
// output is "Object is disposed."
```

#### DoubleExtensions.AlmostEquals
Compare double values with a tolerance

```csharp
using Doulex;

double a = 10.5;
a.AlmostEquals(10.5); // true

```

## Final

Leave a comment on GitHub if you have any questions or suggestions.

Turn on the star if you like this project.

## License

This project is licensed under the MIT License
