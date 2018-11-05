using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretSantaProject.Models;
using System.IO;

namespace SecretSantaProject.Repositories
{
    public class FileContactRepository : IContactRepository
    {
        private string filePath;

        public FileContactRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();

            string lineData;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"{filePath} not found.");
            }
            else
            {
                try
                {
                    using (var streamReader = new StreamReader(filePath))
                    {
                        while ((lineData = streamReader.ReadLine()) != null)
                        {
                            var splitted = lineData.Split(' ');
                            //TODO(Maria): validate phone number format.
                            if(splitted.Count() != 2 || splitted[1].Length != 12)
                            {
                                throw new InvalidDataException("Invalid input");
                            }

                            contacts.Add(new Contact() { Name = splitted[0], Number = splitted[1] });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}\n");
                    throw;
                }
            }
            return contacts;
        }
    }
}
