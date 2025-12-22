# Small DTO

![NET](https://img.shields.io/badge/NET-10.0-green.svg)
![License](https://img.shields.io/badge/License-MIT-blue.svg)
![VS2022](https://img.shields.io/badge/Visual%20Studio-2026-white.svg)
![Version](https://img.shields.io/badge/Version-1.0.2025.0-yellow.svg)]

Funktion und Einsatz von Small DTO (mit Demoprogramm)

DTO (Data Transfer Object) ist ein Entwurfsmuster, das verwendet wird, um Daten zwischen verschiedenen Schichten oder Komponenten einer Anwendung zu übertragen. Ein Small DTO ist eine vereinfachte Version eines DTO, das nur die notwendigsten Daten (in einem **Dictionary\<Enum,object>**) enthält, um die Übertragung effizienter zu gestalten.\
Allerdings kann die Verwendung von DTOs je nach Projekt eine große Anzahl von Klassen entstehen. Bei der Verwndung von *SmallDTO* entfallen zwar die DTO-Klassen, Es werden aber Enum-Klassen benötig um auf die Key's zugreifen zu können.

Klassische DTO-Klasse:
```csharp
```

DTO-Klasse mit SmallDTO
```csharp
var dto = new SmallDTO<SmallDTOKeys>();
dto.Set(SmallDTOKeys.Name, "Max Mustermann");
dto.Set(SmallDTOKeys.Age, 65);
dto.Set(SmallDTOKeys.IsActive, true);
dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

List<string> parts = dto.Get<List<string>>(SmallDTOKeys.Parts);

if (dto.Get<string>(SmallDTOKeys.Name, out var name))
{
    ConsoleMenu.Print($"Name: {name}");
}
```

Mit der Verwendung von SmallDTO sind auch ein einige Vorteile vorhanden. So kann die Klasse *schlauer* durch weiter Funktionen gemacht werden. So kann z.B. eine eigene *Equals* Methode hinzugefügt werden.
```csharp
var dto = new SmallDTO<SmallDTOKeys>();
dto.Set(SmallDTOKeys.Name, "Max Mustermann");
dto.Set(SmallDTOKeys.Age, 65);
dto.Set(SmallDTOKeys.IsActive, true);
dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

var dto2 = new SmallDTO<SmallDTOKeys>();
dto2.Set(SmallDTOKeys.Name, "Max Mustermann");
dto2.Set(SmallDTOKeys.Age, 65);
dto2.Set(SmallDTOKeys.IsActive, true);
dto2.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

if (dto.Equals(dto2))
{
    ConsoleMenu.Print("Die beiden DTO Objekte sind gleich.");
}
else
{
    ConsoleMenu.Print("Die beiden DTO Objekte sind ungleich.");
}
```

