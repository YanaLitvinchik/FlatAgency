using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatAgency.ViewModels;
using FlatAgency.Models;
using System.Windows;

namespace FlatAgency.Commands
{
     class AddCommand : MyCommand
    {
        public AddCommand(DataManager _dm) : base(_dm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Flat c = new Flat();
            dm.SelectedFlat = c;
            dm.Flats.Add(c);
            MessageBox.Show("New flat is saved");
        }
    }
}
