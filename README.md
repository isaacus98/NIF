# NIF
NIF is a .NET library to validate the Spanish NIF. This library allows to validate the DNI, NIE and CIF. It also allows to generate random DNI, NIE and CIF.

**.Net 8 version**

[![NuGet version](https://badge.fury.io/nu/NIF.svg)](https://badge.fury.io/nu/NIF)

**.Net standard 2.0 version**

[![NuGet version](https://badge.fury.io/nu/Spanish.NIF.svg)](https://badge.fury.io/nu/Spanish.NIF)

## Example to validate DNI,NIE or CIF
```csharp
bool result = NIFValidator.Validate("32700667A");
```
## Example to generate DNI
```csharp
String dni = NIFGenerator.GenerateDNI();
```
