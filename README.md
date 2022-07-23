# NIF
NIF is a .NET 6 library to validate the Spanish NIF. This library allows to validate the DNI, NIE and CIF. It also allows to generate random DNI, NIE and CIF.
## Example to validate DNI,NIE or CIF
```csharp
NifValidator validator = new NifValidator();
bool result = validator.Validate("32700667A");
```
## Example to generate DNI
```csharp
NifGenerator generator = new NifGenerator();
String dni = generator.GenerateDNI();
```
