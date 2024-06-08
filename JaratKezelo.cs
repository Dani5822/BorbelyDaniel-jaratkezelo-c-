using System.Globalization;

namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        public class NegativKesesException : Exception { }
        private class Jarat
        {
            private string jaratszam;
            private string repterHonnan;
            private string repterHova;
            private DateTime indulas;
            private int keses;

            public Jarat(string jaratszam, string repterHonnan, string repterHova, DateTime indulas)
            {
                this.jaratszam = jaratszam;
                this.repterHonnan = repterHonnan;
                this.repterHova = repterHova;
                this.indulas = indulas;
                this.keses = 0;
            }

            public string Jaratszam { get => jaratszam; set => jaratszam = value; }
            public string RepterHonnan { get => repterHonnan; set => repterHonnan = value; }
            public string RepterHova { get => repterHova; set => repterHova = value; }
            public DateTime Indulas { get => indulas; set => indulas = value; }
            public int Keses { get => keses; set => keses = value; }
        }

        List<Jarat> Jaratok= new List<Jarat>();

        public void ujJarat(string JaratSzam,string repterHonnan,string repterHova,DateTime indulas)
        {
            foreach (var item in Jaratok)
            {
                if (item.Jaratszam == JaratSzam)
                {
                    throw new ArgumentException();
                }
            }
            Jaratok.Add(new Jarat(JaratSzam,repterHonnan,repterHova,indulas));
        }

        public void Keses(string Jaratszam,int keses)
        {
            Jarat x=null;
            foreach (var item in Jaratok)
            {
                if (item.Jaratszam == Jaratszam)
                {
                    x= item;
                    break;
                }
            }
            if(x!=null)
            {
                if (x.Keses + keses >= 0)
                {
                    x.Keses += keses;
                }
                else
                {
                    throw new NegativKesesException();
                }
            }else
            {
                throw new ArgumentException();
            }
        }
        
        public DateTime mikorIndul(string Jaratszam)
        {
            foreach (var item in Jaratok)
            {
                if (item.Jaratszam == Jaratszam)
                {
                    return item.Indulas.AddMinutes(item.Keses);
                }
            }
            throw new ArgumentException();
        }

        public List<string> jaratokRepuloterrol(string repter)
        {
            List<string> list = new List<string>();
            foreach (var item in Jaratok)
            {
                if (item.RepterHonnan == repter)
                {
                    list.Add(item.Jaratszam);
                }
            }
            return list;
        }
        
    }
}
