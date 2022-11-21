using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProgrammingCourse.SajatOsztaly
{
    class Hallgato
    {
        public string Nev { get; private set; }
        public bool Ferfi { get; private set; }
        public int Finanszirozas { get; private set; }
        public int EddigBefizetett { get; private set; }
        public int EredmenyProg { get; private set; }
        public int EredmenyGraf { get; private set; }
        public int EredmenyArch { get; private set; }
        public int EredmenyMest { get; private set; }
        public double Atlag { get; private set; }
        public bool SikeresVizsga { get; private set; }
        public int OsszPont { get; private set; }

        public const int targyHo = 5;
        public Hallgato(string sor)
        {
           

            string[] tmp = sor.Split(';');
            Nev = tmp[0];
            Ferfi = (tmp[1] == "m");
            Finanszirozas = Convert.ToInt32(tmp[2]);
            EddigBefizetett = Convert.ToInt32(tmp[3].Split('$')[1]);
            EredmenyProg = Convert.ToInt32(tmp[4]);
            EredmenyGraf = Convert.ToInt32(tmp[5]);
            EredmenyArch = Convert.ToInt32(tmp[6]);
            EredmenyMest = Convert.ToInt32(tmp[7]);

            if (EredmenyArch >= 51 && EredmenyMest >= 51 && EredmenyGraf >= 51 && EredmenyProg >= 51)
            {
                SikeresVizsga = true;
            }
            else
            {
                SikeresVizsga = false;
            }

            OsszPont = EredmenyArch + EredmenyMest + EredmenyGraf + EredmenyProg;

            Atlag = OsszPont / 4;

        }

    }
}
