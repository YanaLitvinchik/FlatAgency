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
    class DelCommand : MyCommand
    {
        public DelCommand(DataManager _dm) : base(_dm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Flat c = dm.SelectedFlat;
            dm.Flats.Remove(c);
            //dm.DelContact(c);
        }
    }
}
