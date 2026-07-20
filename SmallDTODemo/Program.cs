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

            var dto = new DTOOfT<SmallDTOKeys>();
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

            var dto = new DTOOfT<SmallDTOKeys>();
            dto.Set(SmallDTOKeys.Name, "Max Mustermann");
            dto.Set(SmallDTOKeys.Age, 65);
            dto.Set(SmallDTOKeys.Birthday, new DateTime(1960, 6, 28));
            dto.Set(SmallDTOKeys.IsActive, true);
            dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

            var dto2 = new DTOOfT<SmallDTOKeys>();
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

            var dto = new DTOOfT<SmallDTOKeys>();
            dto.Set(SmallDTOKeys.Name, "Max Mustermann");
            dto.Set(SmallDTOKeys.Age, 65);
            dto.Set(SmallDTOKeys.Birthday, new DateTime(1960, 6, 28));
            dto.Set(SmallDTOKeys.IsActive, true);
            dto.Set(SmallDTOKeys.Parts, new List<string> { "Part1", "Part2", "Part3" });

            DTOOfT<SmallDTOKeys> dtoClone = dto.Clone();

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

            var dto = new DTOOfT<SmallDTOKeys>();
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

            var dto = new DTOOfT<SmallDTOKeys>();
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

            DTO dto = new();
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

            DTO dto = new();
            dto.Set("Name", "Max Mustermann");
            dto.Set("Age", 65);
            dto.Set("Birthday", new DateTime(1960, 6, 28));
            dto.Set("IsActive", true);
            dto.Set("Parts", new List<string> { "Part1", "Part2", "Part3" });

            DTO dto2 = new();
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

            DTO dto = new();
            dto.Set("Name", "Max Mustermann");
            dto.Set("Age", 65);
            dto.Set("Birthday", new DateTime(1960, 6, 28));
            dto.Set("IsActive", true);
            dto.Set("Parts", new List<string> { "Part1", "Part2", "Part3" });

            DTO dtoClone = dto.Clone();

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

            DTO dto = new();
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
}
