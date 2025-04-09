using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApp2
{
    public partial class MainWindow : Window
    {     
        public async void DisplResultsByValue(SearchValue sv, string Id)
        {
            songPanelControl.SetPanel(sv, Id);
        }
    }
}
