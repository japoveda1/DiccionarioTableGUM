using System;
using System.Collections.Generic;
using System.Data;
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

        private void cmdAdiccionarTablas_Click(object sender, RoutedEventArgs e)
        {
            AdicionarTablas frmAdicionarTablas = new AdicionarTablas();
            frmAdicionarTablas.Show();
        }

        private void CargarGrid()
        {             
           DiccionarioTablasModel vObjDiccionarioTablas = new DiccionarioTablasModel();
           DgTablas.ItemsSource = vObjDiccionarioTablas.obtenerTablasGUM().DefaultView;
        }

           
        private void CmdAdicionar_Click(object sender, RoutedEventArgs e)
        {
            DataView dtvTablasGUM = new DataView();
            DiccionarioTablasModel vObjDiccionarioTablas = new DiccionarioTablasModel();

            //Se obtienen los datos que fueron editados en la tabla principal
            dtvTablasGUM = (DataView)DgTablas.ItemsSource;

            vObjDiccionarioTablas.confirmarCambiosGUm(dtvTablasGUM.Table);

            DgTablas.ItemsSource = null;
            CargarGrid();

        }
    }
}
