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

    public class Program
    {
        private static void Main(string[] args)
        {
            ConsoleMenu.Add("1", "Demo 1 zu SmallDTO", () => MenuPoint1());
            ConsoleMenu.Add("2", "Prüfen, ob zwei DTO Objekt gleich sind", () => MenuPoint2());
            ConsoleMenu.Add("3", "Clone eines DTO Objekt erstellen", () => MenuPoint3());
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
            dto.Set(SmallDTOKeys.IsActive, true);
            dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

            var dto2 = new SmallDTO<SmallDTOKeys>();
            dto2.Set(SmallDTOKeys.Name, "Max Mustermann");
            dto2.Set(SmallDTOKeys.Age, 65);
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
            dto.Set(SmallDTOKeys.IsActive, true);
            dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

            SmallDTO<SmallDTOKeys> dtoClone = dto.Clone();

            if (dto.Equals(dtoClone) == true)
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind gleich.");
                var dtoHash = dto.GetHashCode();
                var dtoCloneHash = dtoClone.GetHashCode();
            }
            else
            {
                ConsoleMenu.Print("Die beiden DTO Objekte sind ungleich.");
            }


            ConsoleMenu.Wait();
        }
    }

    public enum SmallDTOKeys
    {
        Name,
        Age,
        Parts,
        IsActive,
    }

    public class SmallDTO<TKey> where TKey : Enum
    {
        private readonly Dictionary<Enum,object> _DtoDict = new();

        public int Count { get { return this._DtoDict.Count; } }

        public void Set<T>(TKey key, T value)
        {
            this._DtoDict[key] = Convert.ChangeType(value, typeof(T),CultureInfo.CurrentCulture);
        }

        public bool Get<T>(TKey key, out T value)
        {
            if (this._DtoDict.TryGetValue(key, out var obj) && obj is T tValue)
            {
                value = tValue;
                return true;
            }

            value = default!;
            return false;
        }

        public T Get<T>(TKey key)
        {
            if (this._DtoDict.TryGetValue(key, out var obj) && obj is T tValue)
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
                    if (!valueComparer.Equals(kvp.Value, value))
                    {
                        return false;
                    }
                }

            }

            return true;
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
    }
}
