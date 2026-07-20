//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Lifeprojects.de">
//     Class: Program
//     Copyright © Lifeprojects.de 2025
// </copyright>
// <Template>
// 	Version 2.0.2025.0, 28.4.2025
// </Template>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>developer@lifeprojects.de</email>
// <date>04.05.2025 19:34:00</date>
//
// <summary>
// Konsolen Applikation mit Menü
// </summary>
//-----------------------------------------------------------------------

namespace SmallDTODemo
{
    /* Imports from NET Framework */
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class Program
    {
        private static void Main(string[] args)
        {
            ConsoleMenu.Add("1", "Demo 1 zu SmallDTO mit Enum-Key", () => MenuPoint1());
            ConsoleMenu.Add("2", "Prüfen, ob zwei DTO Objekt gleich sind", () => MenuPoint2());
            ConsoleMenu.Add("3", "Clone eines DTO Objekt erstellen", () => MenuPoint3());
            ConsoleMenu.Add("4", "Behandlung von Null", () => MenuPoint4());
            ConsoleMenu.Add("5", "Schreiben und Lesen JSON", () => MenuPoint5());
            ConsoleMenu.Add("6", "Demo 2 zu SmallDTO mit String-Key", () => MenuPoint6());
            ConsoleMenu.Add("7", "Prüfen, ob zwei DTO Objekt gleich sind", () => MenuPoint7());
            ConsoleMenu.Add("8", "Clone eines DTO Objekt erstellen", () => MenuPoint8());
            ConsoleMenu.Add("9", "Schreiben und Lesen JSON", () => MenuPoint9());
            ConsoleMenu.Add("X", "Beenden", () => ApplicationExit());

            do
            {
                _ = ConsoleMenu.SelectKey(2, 2);
            }
            while (true);
        }

        private static void ApplicationExit()
        {
            Environment.Exit(0);
        }

        private static void MenuPoint1()
        {
            Console.Clear();

            var dto = new SmallDTO<SmallDTOKeys>();
            dto.Set(SmallDTOKeys.Name, "Max Mustermann");
            dto.Set(SmallDTOKeys.Age, 65);
            dto.Set(SmallDTOKeys.Birthday, new DateTime(1960, 6, 28));
            dto.Set(SmallDTOKeys.IsActive, true);
            dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

            List<string> parts = dto.Get<List<string>>(SmallDTOKeys.Parts);

            if (dto.Get<string>(SmallDTOKeys.Name, out var name))
            {
                ConsoleMenu.Print($"Name: {name}");
            }

            ConsoleMenu.Wait();
        }

        private static void MenuPoint2()
        {
            Console.Clear();

            var dto = new SmallDTO<SmallDTOKeys>();
            dto.Set(SmallDTOKeys.Name, "Max Mustermann");
            dto.Set(SmallDTOKeys.Age, 65);
            dto.Set(SmallDTOKeys.Birthday, new DateTime(1960, 6, 28));
            dto.Set(SmallDTOKeys.IsActive, true);
            dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

            var dto2 = new SmallDTO<SmallDTOKeys>();
            dto2.Set(SmallDTOKeys.Name, "Max Mustermann");
            dto2.Set(SmallDTOKeys.Age, 65);
            dto2.Set(SmallDTOKeys.Birthday, new DateTime(1960, 6, 28));
            dto2.Set(SmallDTOKeys.IsActive, true);
            dto2.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

            if (dto.Equals(dto2) == true)
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind gleich.");
            }
            else
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind ungleich.");
            }

            ConsoleMenu.Wait();
        }

        private static void MenuPoint3()
        {
            Console.Clear();

            var dto = new SmallDTO<SmallDTOKeys>();
            dto.Set(SmallDTOKeys.Name, "Max Mustermann");
            dto.Set(SmallDTOKeys.Age, 65);
            dto.Set(SmallDTOKeys.Birthday, new DateTime(1960, 6, 28));
            dto.Set(SmallDTOKeys.IsActive, true);
            dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

            SmallDTO<SmallDTOKeys> dtoClone = dto.Clone();

            if (dto.Equals(dtoClone) == true)
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind gleich.");
                var dtoHash = dto.GetHashCode();
                var dtoCloneHash = dtoClone.GetHashCode();
                if (dtoHash.Equals(dtoCloneHash) == true)
                {
                    ConsoleMenu.Print("Der HashCode beiden DTO Objekte ist gleich.");
                }
                else
                {
                    ConsoleMenu.Print("Der HashCode beiden DTO Objekte ist ungleich.");
                }
            }
            else
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind ungleich.");
            }

            ConsoleMenu.Wait();
        }

        private static void MenuPoint4()
        {
            Console.Clear();

            var dto = new SmallDTO<SmallDTOKeys>();
            dto.Set<string>(SmallDTOKeys.Name, null);
            dto.Set<int?>(SmallDTOKeys.Age, null);
            dto.Set<bool?>(SmallDTOKeys.IsActive, null);
            dto.Set(SmallDTOKeys.Parts, new List<string> { });

            List<string> parts = dto.Get<List<string>>(SmallDTOKeys.Parts);

            if (dto.Get<string>(SmallDTOKeys.Name, out var name))
            {
                ConsoleMenu.Print($"Name: {name}");
            }

            ConsoleMenu.Wait();
        }

        private static void MenuPoint5()
        {
            Console.Clear();

            var dto = new SmallDTO<SmallDTOKeys>();
            dto.Set(SmallDTOKeys.Name, "Max Mustermann");
            dto.Set(SmallDTOKeys.Age, 65);
            dto.Set(SmallDTOKeys.Birthday, new DateTime(1960, 6, 28));
            dto.Set(SmallDTOKeys.IsActive, true);
            dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });
            dto.ToJson("dto.json");

            ConsoleMenu.Wait();
        }

        private static void MenuPoint6()
        {
            Console.Clear();

            SmallDTO dto = new();
            dto.Set("Name", "Max Mustermann");
            dto.Set("Age", 65);
            dto.Set("Birthday", new DateTime(1960, 6, 28));
            dto.Set("IsActive", true);
            dto.Set("Parts", new List<string> { "Part1", "Part2", "Part3" });

            List<string> parts = dto.Get<List<string>>("Parts");

            if (dto.Get<string>("Name", out var name))
            {
                ConsoleMenu.Print($"Name: {name}");
            }

            ConsoleMenu.Wait();
        }

        private static void MenuPoint7()
        {
            Console.Clear();

            SmallDTO dto = new();
            dto.Set("Name", "Max Mustermann");
            dto.Set("Age", 65);
            dto.Set("Birthday", new DateTime(1960, 6, 28));
            dto.Set("IsActive", true);
            dto.Set("Parts", new List<string> { "Part1", "Part2", "Part3" });

            SmallDTO dto2 = new();
            dto2.Set("Name", "Max Mustermann");
            dto2.Set("Age", 65);
            dto2.Set("Birthday", new DateTime(1960, 6, 28));
            dto2.Set("IsActive", true);
            dto2.Set("Parts", new List<string> { "Part1", "Part2", "Part3" });

            if (dto.Equals(dto2) == true)
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind gleich.");
            }
            else
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind ungleich.");
            }

            ConsoleMenu.Wait();
        }

        private static void MenuPoint8()
        {
            Console.Clear();

            SmallDTO dto = new();
            dto.Set("Name", "Max Mustermann");
            dto.Set("Age", 65);
            dto.Set("Birthday", new DateTime(1960, 6, 28));
            dto.Set("IsActive", true);
            dto.Set("Parts", new List<string> { "Part1", "Part2", "Part3" });

            SmallDTO dtoClone = dto.Clone();

            if (dto.Equals(dtoClone) == true)
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind gleich.");
                var dtoHash = dto.GetHashCode();
                var dtoCloneHash = dtoClone.GetHashCode();
                if (dtoHash.Equals(dtoCloneHash) == true)
                {
                    ConsoleMenu.Print("Der HashCode beiden DTO Objekte ist gleich.");
                }
                else
                {
                    ConsoleMenu.Print("Der HashCode beiden DTO Objekte ist ungleich.");
                }
            }
            else
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind ungleich.");
            }

            ConsoleMenu.Wait();
        }

        private static void MenuPoint9()
        {
            Console.Clear();

            SmallDTO dto = new();
            dto.Set("Name", "Max Mustermann");
            dto.Set("Age", 65);
            dto.Set("Birthday", new DateTime(1960, 6, 28));
            dto.Set("IsActive", true);
            dto.Set("Parts", new List<string> { "Part1", "Part2", "Part3" });
            dto.ToJson("dto.json");
            int count = dto.Count;

            dto.Clear();

            dto.FromJson("dto.json");
            int count1 = dto.Count;

            ConsoleMenu.Wait();
        }

    }

    public class ClassicDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Parts { get; set; }
        public Dictionary<int, string> Attributes { get; set; }
        public bool IsActive { get; set; }
    }

    public enum SmallDTOKeys
    {
        Name,
        Age,
        Birthday,
        Parts,
        IsActive,
    }

    public sealed partial class SmallDTO
    {
        private Dictionary<string, object> _DtoDict = new();
        public int Count { get { return this._DtoDict.Count; } }

        public void Set<T>(string key, T value)
        {
            key = key.ToUpper(CultureInfo.CurrentCulture);
            if (value == null)
            {
                this._DtoDict[key] = null;
            }
            else
            {
                this._DtoDict[key] = Convert.ChangeType(value, typeof(T), CultureInfo.CurrentCulture);
            }
        }

        public bool Get<T>(string key, out T value)
        {
            key = key.ToUpper(CultureInfo.CurrentCulture);
            if (this._DtoDict.TryGetValue(key, out var obj) == true && obj is T tValue)
            {
                value = tValue;
                return true;
            }

            if (obj == null)
            {
                value = (T)obj;
                return true;
            }

            value = default!;
            return false;
        }

        public T Get<T>(string key)
        {
            key = key.ToUpper(CultureInfo.CurrentCulture);
            if (this._DtoDict.TryGetValue(key, out var obj) == true && obj is T tValue)
            {
                return tValue;
            }

            return default!;
        }

        public bool Equals(SmallDTO anotherDTO)
        {
            if (ReferenceEquals(this._DtoDict, anotherDTO))
            {
                return true;
            }

            if (this._DtoDict == null || anotherDTO == null)
            {
                return false;
            }

            if (this._DtoDict.Count != anotherDTO.Count)
            {
                return false;
            }

            EqualityComparer<object> valueComparer = EqualityComparer<object>.Default;
            foreach (var kvp in this._DtoDict)
            {
                string key = kvp.Key.ToUpper(CultureInfo.CurrentCulture);
                if (!anotherDTO.Get<object>(key, out var value))
                {
                    return false;
                }

                if (value.GetType().Name == typeof(List<>).Name)
                {
                    var v0 = kvp.Value as System.Collections.IList;
                    var v1 = value as System.Collections.IList;
                    if (v0.Count != v1.Count)
                    {
                        return false;
                    }

                    var diff = v0.Cast<object>().Except(v1.Cast<object>());
                    if (diff.Any() == true)
                    {
                        return false;
                    }
                }
                else
                {
                    if (valueComparer.Equals(kvp.Value, value) == false)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        public SmallDTO Clone()
        {
            SmallDTO newDto = new();
            foreach (var kvp in this._DtoDict)
            {
                newDto._DtoDict[kvp.Key] = kvp.Value;
            }

            return newDto;
        }

        public void Clear()
        {
            if (_DtoDict != null && _DtoDict.Any() == true)
            {
                _DtoDict.Clear();
            }
        }

        public void ToJson(string filePath)
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true,
            };

            JsonSerializerOptions options = jsonSerializerOptions;

            options.Converters.Add(new ObjectDictionaryConverter());
            string json = JsonSerializer.Serialize(this._DtoDict, options);
            if (string.IsNullOrEmpty(json) == false)
            {
                File.WriteAllText(filePath, json);
            }
        }

        public void FromJson(string filePath)
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true,
            };

            JsonSerializerOptions options = jsonSerializerOptions;
            options.Converters.Add(new ObjectDictionaryConverter());

            if (string.IsNullOrEmpty(filePath) == false && File.Exists(filePath) == true)
            {
                string jsonText = File.ReadAllText(filePath);
                this._DtoDict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonText, options);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var kvp in this._DtoDict)
            {
                sb.AppendLine(CultureInfo.CurrentCulture, $"{kvp.Key}: {kvp.Value}");
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int result = 0;
            HashCode hash = new();

            foreach (var kvp in this._DtoDict)
            {
                hash.Add(kvp.Key);
                hash.Add(kvp.Value);
            }

            result = hash.ToHashCode();

            return result;
        }

        private sealed class ObjectDictionaryConverter : JsonConverter<Dictionary<string, object>>
        {
            public override Dictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var result = new Dictionary<string, object>();

                using var doc = JsonDocument.ParseValue(ref reader);

                foreach (var prop in doc.RootElement.EnumerateObject())
                {
                    string key = prop.Name;
                    result[key] = prop.Value;
                }

                return result;
            }

            public override void Write(Utf8JsonWriter writer, Dictionary<string, object> value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();

                foreach (var kvp in value)
                {
                    writer.WritePropertyName(kvp.Key.ToString());
                    JsonSerializer.Serialize(writer, kvp.Value, options);
                }

                writer.WriteEndObject();
            }
        }
    }

    public sealed partial class SmallDTO<TKey> where TKey : Enum
    {
        private Dictionary<Enum,object> _DtoDict = new();

        public int Count { get { return this._DtoDict.Count; } }

        public void Set<T>(TKey key, T value)
        {
            if (value == null)
            {
                this._DtoDict[key] = null;
            }
            else
            {
                this._DtoDict[key] = Convert.ChangeType(value, typeof(T), CultureInfo.CurrentCulture);
            }
        }

        public bool Get<T>(TKey key, out T value)
        {
            if (this._DtoDict.TryGetValue(key, out var obj) == true && obj is T tValue)
            {
                value = tValue;
                return true;
            }

            if(obj == null)
            {
                value = (T)obj;
                return true;
            }

            value = default!;
            return false;
        }

        public T Get<T>(TKey key)
        {
            if (this._DtoDict.TryGetValue(key, out var obj) == true && obj is T tValue)
            {
                return tValue;
            }

            return default!;
        }

        public bool Equals(SmallDTO<TKey> anotherDTO)
        {
            if (ReferenceEquals(this._DtoDict, anotherDTO))
            {
                return true;
            }

            if (this._DtoDict == null || anotherDTO == null)
            {
                return false;
            }

            if (this._DtoDict.Count != anotherDTO.Count)
            {
                return false;
            }

            EqualityComparer<object> valueComparer = EqualityComparer<object>.Default;
            foreach (var kvp in this._DtoDict)
            {
                TKey key = (TKey)kvp.Key;
                if (!anotherDTO.Get<object>(key, out var value))
                {
                    return false;
                }

                if (value.GetType().Name == typeof(List<>).Name)
                {
                    var v0 = kvp.Value as System.Collections.IList;
                    var v1 = value as System.Collections.IList;
                    if (v0.Count != v1.Count)
                    {
                        return false;
                    }

                    var diff = v0.Cast<object>().Except(v1.Cast<object>());
                    if (diff.Any() == true)
                    {
                        return false;
                    }
                }
                else
                {
                    if (valueComparer.Equals(kvp.Value, value) == false)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        public void Clear()
        {
            if (_DtoDict != null && _DtoDict.Any() == true)
            {
                _DtoDict.Clear();
            }
        }

        public SmallDTO<TKey> Clone()
        {
            SmallDTO<TKey> newDto = new();
            foreach (var kvp in this._DtoDict)
            {
                newDto._DtoDict[kvp.Key] = kvp.Value;
            }

            return newDto;
        }

        public void ToJson(string filePath)
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true,
            };
            var options = jsonSerializerOptions;

            options.Converters.Add(new EnumObjectDictionaryConverter());
            string json = JsonSerializer.Serialize(this._DtoDict, options);
            if (string.IsNullOrEmpty(json) == false)
            {
                File.WriteAllText(filePath, json);
            }
        }

        public void FromJson(string filePath)
        {
            JsonSerializerOptions jsonSerializerOptions = new()
            {
                WriteIndented = true,
            };

            JsonSerializerOptions options = jsonSerializerOptions;
            options.Converters.Add(new EnumObjectDictionaryConverter());

            if (string.IsNullOrEmpty(filePath) == false && File.Exists(filePath) == true)
            {
                string jsonText = File.ReadAllText(filePath);
                this._DtoDict = JsonSerializer.Deserialize<Dictionary<Enum, object>>(jsonText, options);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var kvp in this._DtoDict)
            {
                sb.AppendLine(CultureInfo.CurrentCulture,$"{kvp.Key}: {kvp.Value}");
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int result = 0;
            HashCode hash = new();

            foreach (var kvp in this._DtoDict)
            {
                hash.Add(kvp.Key);
                hash.Add(kvp.Value);
            }

            result = hash.ToHashCode();

            return result;
        }

        private sealed class EnumObjectDictionaryConverter : JsonConverter<Dictionary<Enum, object>>
        {
            public override Dictionary<Enum, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var result = new Dictionary<Enum, object>();

                using var doc = JsonDocument.ParseValue(ref reader);

                foreach (var prop in doc.RootElement.EnumerateObject())
                {
                    Enum key = (Enum)Enum.Parse(typeof(TKey), prop.Name);
                    result[key] = prop.Value;
                }

                return result;
            }

            public override void Write(Utf8JsonWriter writer, Dictionary<Enum, object> value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();

                foreach (var kvp in value)
                {
                    writer.WritePropertyName(kvp.Key.ToString());
                    JsonSerializer.Serialize(writer, kvp.Value, options);
                }

                writer.WriteEndObject();
            }
        }
    }
}
