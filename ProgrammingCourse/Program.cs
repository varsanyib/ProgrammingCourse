using ProgrammingCourse.SajatOsztaly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingCourse
{
    class Program
    {
        static List<Hallgato> hallgatok = new List<Hallgato>();
        
        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();

            Console.ReadKey();
        }

        private static void HatodikFeladat()
        {
            Console.WriteLine("6. feladat:\n\tÁllásajánlatot kap:");
            foreach (Hallgato e in hallgatok.Where(x => x.SikeresVizsga).Where(y => y.Finanszirozas == 2).Where(y => y.EddigBefizetett == 0).OrderByDescending(y => y.OsszPont))
            {
                Console.WriteLine($"\t{e.Nev}\t\t{e.OsszPont}");
            }
        }

        private static void OtodikFeladat()
        {
            Console.WriteLine("5. feladat:\n\tA következő tanulóknak van elmaradása: ");
            foreach (Hallgato e in hallgatok)
            {
                if (e.Finanszirozas == 0 && e.EddigBefizetett < 2600)
                {
                    Console.WriteLine($"\t{e.Nev}");
                }
                if (e.Finanszirozas == 1 && e.EddigBefizetett < (Hallgato.targyHo * 312))
                {
                    Console.WriteLine($"\t{e.Nev}");
                }
                if (e.Finanszirozas == 2 && Hallgato.targyHo >= 10 && e.EddigBefizetett < 4000)
                {
                    Console.WriteLine($"\t{e.Nev}");
                }
            }
        }

        private static void NegyedikFeladat()
        {
            double ferfiAtlag = (hallgatok.Where(x => x.Ferfi).Average(y => y.EredmenyProg) + hallgatok.Where(x => x.Ferfi).Average(y => y.EredmenyMest) + hallgatok.Where(x => x.Ferfi).Average(y => y.EredmenyGraf) + hallgatok.Where(x => x.Ferfi).Average(y => y.EredmenyArch))/ 4;
            double noAtlag = (hallgatok.Where(x => !x.Ferfi).Average(y => y.EredmenyProg) + hallgatok.Where(x => !x.Ferfi).Average(y => y.EredmenyMest) + hallgatok.Where(x => !x.Ferfi).Average(y => y.EredmenyGraf) + hallgatok.Where(x => !x.Ferfi).Average(y => y.EredmenyArch)) / 4;
            Console.WriteLine($"4. feladat:\n\tFiúk   átlagteljesítménye: {Math.Round(ferfiAtlag, 2)}%\n\tLányok átlagteljesítménye: {Math.Round(noAtlag, 2)}%");
        }

        private static void HarmadikFeladat()
        {
            Console.WriteLine($"3. feladat:\n\tA tanfolyamra {hallgatok.Count} fő iratkozott be.");
        }

        private static void MasodikFeladat()
        {
            using (StreamReader sr = new StreamReader("coursedata.csv"))
            {
                while (!sr.EndOfStream)
                {
                    hallgatok.Add(new Hallgato(sr.ReadLine()));
                }
            }
        }
    }
}
