using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF39_2016.model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;

        [Xml ignore]
        public int Id { get; set; }
        public string Naziv { get; set; }

        public string Sifra { get; set; }

        public double Cena { get; set; }

        public int BrKomada { get; set; }

        public int? AkcijaId { get; set; }

        public int? TipNamestajaId { get; set; }

        public bool Obrisan { get; set; }
        public override string ToString()
        {
            return $"{Naziv},{Cena},{TipNamestajaId}";
        }
        public static Namestaj GetByIdNamestaj(int unetiId)
        {
            foreach (Namestaj namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Id == unetiId)
                    return namestaj;
            }
            return null;
        }
        
       
    }
}
