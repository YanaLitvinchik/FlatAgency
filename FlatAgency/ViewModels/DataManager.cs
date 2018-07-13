using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using FlatAgency.Models;
using System.Collections.ObjectModel;
using FlatAgency.Commands;
using System.IO;

namespace FlatAgency.ViewModels
{
    class DataManager : INotifyPropertyChanged
    {
        private string path;
        private XDocument doc;

        private Flat selectedFlat;
        public Flat SelectedFlat
        {
            get { return selectedFlat; }
            set { selectedFlat = value; OnPropertyChanged("SelectedFlat"); }
        }
        public ObservableCollection<Flat> Flats { get; set; }


        //Commands : 
        private AddCommand add;
        private DelCommand del;

        public AddCommand Add
        {
            get
            {
                if (add == null)
                    add = new AddCommand(this);
                return add;
            }
        }
        public DelCommand Del
        {
            get
            {
                if (del == null)
                    del = new DelCommand(this);
                return del;
            }
        }
       

        public DataManager()
        {
            Flats = new ObservableCollection<Flat>();
            path = @"..\..\Data\Flats.xml";
            doc = XDocument.Load(path);
            LoadData();
        }
        public void LoadData()
        {
            var res = doc.Element("root").Elements("flat").ToList();
            foreach (var x in res)
            {
                Flat c = new Flat()
                {
                    Region = x.Attribute("region").Value,
                    Price = x.Attribute("price").Value,
                    Adress = x.Attribute("adress").Value,
                    Owner = x.Attribute("owner").Value,
                    Phone = x.Attribute("phone").Value
                };
                Flats.Add(c);
            }
        }

        public void DelContact(Flat c)
        {
            //var res = doc.Element("root").Element("contact")
            //    .Where(x => x.Attribute("person").Value == c.Person)
            //    .FirstOrDafault();
            //if(res != null)
            //{
            //    res.Remove();
            //    doc.Save(path);
            //}
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
