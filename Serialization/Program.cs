using Newtonsoft.Json;
using Serialization.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<Group>();
            var students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                groups.Add(new Group(i, $"Group{i}"));
            }
            for (int i = 0; i < 300; i++)
            {
                var student = new Student(Guid.NewGuid()
                    .ToString()
                    .Substring(0, 5), i % 100)
                {
                    Group = groups[i % 9]
                };
                students.Add(student);
            }
            Console.WriteLine("bin");
            var binaryFormatter = new BinaryFormatter();
            using (var file = new FileStream("groups.bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(file, groups);
            }

            using (var file = new FileStream("groups.bin", FileMode.OpenOrCreate))
            {
                var newGroups = binaryFormatter.Deserialize(file) as List<Group>;
                if (newGroups is not null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine($"{group}");
                    }
                }
            }
            Console.WriteLine("xml");
            var xmlSerializer = new XmlSerializer(typeof(List<Group>));

            using (var file = new FileStream("groups.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, groups);
            }

            using (var file = new FileStream("groups.xml", FileMode.OpenOrCreate))
            {
                var newGroups = xmlSerializer.Deserialize(file) as List<Group>;
                if (newGroups is not null)
                {
                    foreach (var group in newGroups)
                    {
                        Console.WriteLine($"{group}");
                    }
                }
            }

            Console.WriteLine("json");
            using (var file = new FileStream("students.json", FileMode.OpenOrCreate))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                };
                var jsonConverter = JsonConvert.SerializeObject(students, settings);
                file.Write(Encoding.UTF8.GetBytes(jsonConverter), 0, jsonConverter.Length);
            }
            using (var file = new FileStream("students.json", FileMode.OpenOrCreate))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                };
                byte[] array = new byte[file.Length];
                file.Read(array, 0, array.Length);
                var newStudents = JsonConvert.DeserializeObject<List<Student>>(Encoding.UTF8.GetString(array), settings);

                foreach (var student in newStudents)
                {
                    Console.WriteLine($"{student.Name}({student.Age})");
                }
            }
            Console.ReadKey();
        }
    }
}
