using System;
using System.Collections.Generic;
using System.IO;

// Jeff Davidson CSC 499
// Program to take names from a file and sort the names in ascending order by the length of the name, then alphabetically.

namespace Suran_Homework_1
{
    class Program
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static string[] ReadFromFile(string filePath)
        {
            List<string> list = new List<string>(); // Create list to add easily to.
            
            using (StreamReader sr = File.OpenText(filePath))
            {
                string name;
                while ((name = sr.ReadLine()) != null) // while line is not null.
                {
                    if (string.IsNullOrWhiteSpace(name) == false) //ignore lines of whitespace.
                    {
                        list.Add(CleanNames(name)); // Clean the name then add name to list.
                    }
                }
            }

            String[] nameArray = list.ToArray(); // Convert list to array to sort easily.

            return nameArray; // Return new array full of names from file.
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static string CleanNames(string name)
        {
            name = name.Trim(); // Remove WhiteSpaces from before and after name;

            if (name.Length > 0)
            {
                // Make first letter uppercase incase file input has a lowercase first letter. 
                name = char.ToUpper(name[0]) + name.Substring(1);

            }
            
            return name; // Return the cleaned name.
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static string[] SortArrayOfNames(string[] nameArray)
        {
            string temp;

            // Bubble sort. 
            for (int i = 0; i < nameArray.Length; i++)
            {
                for (int j = 0; j < nameArray.Length - 1; j++)
                {
                    if (nameArray[j].Length > nameArray[j + 1].Length) // Sort by length
                    {
                        temp = nameArray[j];
                        nameArray[j] = nameArray[j + 1];
                        nameArray[j + 1] = temp;
                    }

                    // Check if the next name in array is the same length as current name to only sort alphabetically by the same length name.
                    if (nameArray[j].Length == nameArray[j + 1].Length) 
                    {

                        if (nameArray[j].CompareTo(nameArray[j + 1]) > 0) // Sort alphabetically.
                        {
                            temp = nameArray[j];
                            nameArray[j] = nameArray[j + 1];
                            nameArray[j + 1] = temp;
                        }
                    }
                    
                }
            }

            return nameArray;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void PrintArray(string[] nameArray)
        {
            // Print array to console
            foreach (string name in nameArray)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("");
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public static void CheckOutput(string[] nameArray, string[] expectedOutput)
        {
            bool notSame = false;

            for (int i = 0; i < nameArray.Length; i++)
            {
                if (nameArray[i] != expectedOutput[i])
                {
                    // If this name in name array dosent equal the same name in expected output, then they are not the same.
                    notSame = true; 
                }
            }
            if (notSame)
            {
                Console.WriteLine("Output is not what is expected."); // Tell user output is not what is expeted from homework.
            }
            else
            {
                Console.WriteLine("Output is what is expected from homework.");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            // Expected output from homework page.
            string[] expectedOutput = {"Kha","Asby","Bain","Dean","Fife","Wile","Baker",
                                       "Ellis","Evans","Foley","Glock","Graff","Heigl",
                                       "Lundy","McVey","Nylon","Peery","Reyes","White",
                                       "Adkins","Broome","Hickey","Laymon","Rogers",
                                       "Tanton","Taylor","Byfield","Dulaney","Hagberg",
                                       "Hillman","McCrave","Michael","Padgett","Routson",
                                       "Starkey","Stegman","Bostwick","Cachedon","Giddings",
                                       "Guenther","Hatfield","Kalivoda","Kirkland","Phillips",
                                       "Reynolds","Sullivan","Williams","Clevenger","Fitzjerrell",
                                       "Hendrickson"};

            string filePath = @"Sort Me.txt"; // File path.

            if (File.Exists(filePath)){ // Check if file path is correct.

                string[] nameArray = ReadFromFile(filePath); // Get names from file.

                Console.WriteLine("-------------- Unsorted names from file --------------");
                PrintArray(nameArray); // Print unsorted names from file.

                nameArray = SortArrayOfNames(nameArray); // Sort names from file in ascending order by the length of the name, then alphabetically.
                Console.WriteLine("-------------- Sorted names --------------");
                PrintArray(nameArray); // Print sorted array.

                CheckOutput(nameArray, expectedOutput); // Check if sorted array equals the expected output from homework page.
            }
            else
            {
                Console.WriteLine("Can't find file at: " + filePath); // Tell user path is incorrect
            }
            
        }
    }
}
