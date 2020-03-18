using DiccionarioTableGUM.Models;
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

namespace DiccionarioTableGUM.Views
{
    /// <summary>
    /// Interaction logic for AdicionarTablas.xaml
    /// </summary>
    public partial class AdicionarTablas : Window
    {
        public AdicionarTablas()
        {
            InitializeComponent();

            CargarGrid();
           
        }

        private void CargarGrid()
        {

            AdicionarTablasModel vObjAdicionarTablasModels = new AdicionarTablasModel();
            DgTablasDB.ItemsSource = vObjAdicionarTablasModels.ObtenerTablasDB().DefaultView;

        }

        

    }
}
