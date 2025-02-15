# NIF
NIF is a .NET standard 2.0 library to validate the Spanish NIF. This library allows to validate the DNI, NIE and CIF. It also allows to generate random DNI, NIE and CIF.


## Example to validate DNI,NIE or CIF
```csharp
bool result = NIFValidator.Validate("32700667A");
```
## Example to generate DNI
```csharp
String dni = NIFGenerator.GenerateDNI();
```
