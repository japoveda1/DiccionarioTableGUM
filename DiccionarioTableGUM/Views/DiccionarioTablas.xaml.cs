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
using DiccionarioTableGUM.Models;

namespace DiccionarioTableGUM.Views
{
    /// <summary>
    /// Interaction logic for DiccionarioTablas.xaml
    /// </summary>
    public partial class DiccionarioTablas : Window
    {
        public DiccionarioTablas()
        {

            InitializeComponent();

            CargarGrid();

        }

        private void BtnAdiccionarTablas_Click(object sender, RoutedEventArgs e)
        {
            AdicionarTablas vViewAdicionarTablas = new AdicionarTablas();

            vViewAdicionarTablas.Show();
        }

        private void CargarGrid()
        {

            DiccionarioTablasModel vDiccionarioTablas = new DiccionarioTablasModel();
            DgTablas.ItemsSource = vDiccionarioTablas.obtenerTablasGUM().DefaultView;
        }
    }
}
