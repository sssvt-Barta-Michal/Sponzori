using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sponzori
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\bajat\Desktop\input.txt");
            int Index = 0;
            string phrases = lines[Index];
            string[] phrase = phrases.Split(' ');
            Index++;

            Dictionary<int, string> animalDictionary = new Dictionary<int, string>();
            Dictionary<string, List<int>> sponsorDictionary = new Dictionary<string, List<int>>();
            Dictionary<string, string> sortedDictionary = new Dictionary<string, string>();


            for (int i = 0; i < Int32.Parse(phrase[0]); i++)
            {
                string name1 = lines[Index];
                string[] name2 = name1.Split(' ');
                
                animalDictionary.Add(Int32.Parse(name2[0]),name2[1]);
                Index++;
            }

           



            for (int i = 0; i < Int32.Parse(phrase[1]); i++)
            {
                string name1 = lines[Index];
                string[] name2 = name1.Split(' ');
                string sponsorname = name2[0];
                List<int> wanttosponsorlist = new List<int>();
                int ind = 2;
                for (int y = 0; y < Int32.Parse(name2[1]); y++)
                {
                    wanttosponsorlist.Add(Int32.Parse(name2[ind]));
                   ind++;
                }
                sponsorDictionary.Add(sponsorname, wanttosponsorlist);
                Index++;

            }

            

            int tries =0;
            for (int i = 0; i < sponsorDictionary.Count; i++)
            {
                foreach (var sponsor in sponsorDictionary.ToList())
                {
                    if (sponsor.Value.Count == 1)
                    {
                        int valuesearching = sponsor.Value[0];

                        foreach (var animal in animalDictionary.ToList())
                        {
                            if (valuesearching == animal.Key)
                            {
                                sortedDictionary.Add(sponsor.Key, animal.Value);
                                animalDictionary.Remove(animal.Key);
                                sponsorDictionary.Remove(sponsor.Key);
                            }

                            tries++;
                            if (tries == animalDictionary.Count)
                            {
                                sponsorDictionary.Remove(sponsor.Key);
                            }
                        }

                        tries = 0;
                    }
                }
            }

            int sucess = 0;
             Dictionary<string, string> bestsort = sortedDictionary;
               for (int i = 0; i < 2000; i++)
               {
                   Dictionary<int, string> animalDictionary2 = animalDictionary;
                   Dictionary<string, List<int>> sponsorDictionary2 = sponsorDictionary; 
                   Dictionary<string, string> sortedDictionary2 = sortedDictionary;

                   for (int y = 0; y < 2000; y++)
                   {
                       foreach (var sponsor in sponsorDictionary2.ToList())
                       {
                           Random random = new Random();
                           int n = random.Next(sponsor.Value.Count);
                           int valuesearching = sponsor.Value[n];

                           foreach (var animal in animalDictionary2.ToList())
                           {
                               if (valuesearching == animal.Key)
                               {
                                   sortedDictionary2.Add(sponsor.Key, animal.Value);
                                   animalDictionary2.Remove(animal.Key);
                                   sponsorDictionary2.Remove(sponsor.Key);
                               }
                           }
                       }

                       if (animalDictionary2.Count == 0)
                       {
                           sucess = 1;
                           break;
                       }
                   }

                   if (sucess == 1)
                   {
                       sortedDictionary = sortedDictionary2;
                       break;
                       
                   }

                   if (sortedDictionary2.Count > bestsort.Count)
                   {
                       bestsort = sortedDictionary2;
                   }
               }

               if (sucess == 0)
               {
                   sortedDictionary = bestsort;
                   Console.WriteLine("Ne");
                foreach ( var Sorted in sortedDictionary)
                {
                   
                    Console.WriteLine("{0} {1}", Sorted.Value,Sorted.Key);
                }
            }

               if (sucess == 1)
               {
                   Console.WriteLine("Ano");
                foreach (var Sorted in sortedDictionary)
                   {

                       Console.WriteLine("{0} {1}", Sorted.Value, Sorted.Key);
                   }
            }

               
               Console.ReadKey(true); 


            





        }
    }
}
