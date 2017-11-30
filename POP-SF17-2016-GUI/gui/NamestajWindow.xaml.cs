using POP_SF39_2016.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF39_2016_GUI.ui
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Namestaj namestaj;
        private Operacija operacija;

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(namestaj, operacija);
        }

        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            this.tbNaziv.Text = namestaj.Naziv;
            foreach (var tipNamestaja in Projekat.Instance.TipNamestaja)
            {
                cbTipNamestaja.Items.Add(tipNamestaja.Naziv);
                
            }
            foreach (TipNamestaja tipNamestaja in cbTipNamestaja.Items)
            {
                if (tipNamestaja.Id == namestaj.Id)
                {
                    cbTipNamestaja.SelectedItem = tipNamestaja;
                    break;
                }
            }
           
        }
        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            var ListaNamestaja = Projekat.Instance.Namestaj;
            //TipNamestaja izabraniTipNamestaja = ((TipNamestaja)cbTipNamestaja.SelectedItem);

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    //namestaj.Id = listaNamestaja.Count + 1;
                    //listaNamestaja.Add(Namestaj);
                    //break;
                    //case TipOperacije.Izmena:
                    //foreach (var n in listaNamestaja)
                    //{
                    //if(n.Id ==namestaj.Id)
                    //{
                    //n.TipNamestajaId = namestaj.TipNamestajaId;
                    //n.Naziv = namestaj.Naziv;
                    //break;
                    //}
                    var noviNamestaj = new Namestaj()
                    {
                        Id = ListaNamestaja.Count + 1,
                        Naziv = this.tbNaziv.Text,
                        TipNamestajaId = izabraniTipNamestaja.Id
                    };
                    ListaNamestaja.Add(noviNamestaj);
                    break;
                case Operacija.IZMENA:
                    foreach(var n in ListaNamestaja)
                    {
                        if(n.Id == namestaj.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            n.TipNamestajaId = izabraniTipNamestaja.Id;
                           
                            break;
                        }
                    }
                    
                //default:
                   // break;
            }
            Projekat.Instance.Namestaj = ListaNamestaja;
            this.Close();
        }

        private void ZatvoriWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public object Clone()
        {
            return new Namestaj()
            {
                id = Id,
                Naziv = Naziv,
                Cena = Cena,
                Obrisan = Obrisan,
                tipNamestaja = TipNamestaja,
                tipNamestajaId = TipNamestajaId
            }
        }
    }
}
