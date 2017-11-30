using POP_SF39_2016.model;
using POP_SF39_2016_GUI.ui;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF39_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
     
        private ICollectionView view;

        public MainWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            view.Filter = FilterNeobrisanogNamestaja;
            dg.Namestaj.ItemsSource = view;
            dgNamestaj.IsSynchrnizedWithCurrenntItem = true;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType);
            OsveziPrikaz();
        }
        private bool FilterNeobrisanogNamestaja(object obj)
        {
            //prvi nacin
            //if (((Namestaj)obj).Obrisan == false)
            //{
            //    return true; //treba da se prikaze,zadovoljava kriterijum
            //}
            //else
            //{
            //    return false;
            //}
            //drugi nacin
            return !((Namestaj)obj).Obrisan;
            // treci
            //return ((Namestaj)obj).Obrisan == false;
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if(namestaj.Obrisan == false)
                    lbNamestaj.Items.Add(namestaj);

            }
            lbNamestaj.SelectedIndex = 0;
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }


        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };

            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            Namestaj kopijaNamestaja = (Namestaj)IzabraniNamestaj.Clone();


            var namestajProzor = new NamestajWindow(kopijaNamestaja, NamestajWindow.Operacija.IZMENA);
            namestajProzor.ShowDialog();
        }
        private void ObrisiNamestaj(object sender, RoutedEventArgs e)
        {

            var namestajProzor = new NamestajWindow(IzabraniNamestaj, NamestajWindow.TipOperacije);
            List<Namestaj> ListaNamestaja = Projekat.Instance.Namestaj;
            MessageBoxResult r = MessageBox.Show("title", "da li ste sigurni?", MessageBoxButton.YesNo);
            if (r==MessageBoxResult.Yes)
            {
                foreach(Namestaj namestaj in ListaNamestaja)
                    if(namestaj.Id==izabraniNamestaj.Id)
                        namestaj.Obrisan = true;
                Projekat.Instance.Namestaj = ListaNamestaja;
            };
            
        }
        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            var namestajZaBrisanje = (Namestaj)lbNamestaj.Namestaj.SelectedItem;

            if(MessageBox.Show(
                $"Dali ste sigurni da zelite da izbrisete namestaj: {namestajZaBrisanje.Naziv }?",
                "Brisanje namestaja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var lista = Projekat.Instance.Namestaj;

                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Id == IzabraniNamestaj.id)
                        n.Obrisan = true;
                        
                }
                
            }
            Projekat.Instance.Namestaj = lista

        }
        {
            var listaNamestaja = Projekat.Instance.Namestaj;
            
            foreach(var n in listaNamestaja)
            {
            if n
            }
        }
        
private void dgNamestaj_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColimnEventArgs e)
{
    if (e.Column.Header.ToString() == "Id" ||
        e.Column.Header.ToString() == "TipNamestajaId" ||
        e.Column.Header.ToString() == "Obrisan")
    {
        e.Cance = true;
    }

}
    }
}
