# NIF
NIF is a .NET 6 library to validate the Spanish NIF. This library allows to validate the DNI, NIE and CIF. It also allows to generate random DNI, NIE and CIF.

[![NuGet](https://img.shields.io/nuget/v/NIF)](https://www.nuget.org/packages/NIF)
## Example to validate DNI,NIE or CIF
```csharp
bool result = NifValidator.Validate("32700667A");
```
## Example to generate DNI
```csharp
String dni = NifGenerator.GenerateDNI();
```
