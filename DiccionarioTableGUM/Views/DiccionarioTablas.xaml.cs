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
            AbrirVentanaAdicionarTablas();
            CargarGrid();
        }

        private void CmdConfirmarCambios_Click(object sender, RoutedEventArgs e)
        {
            ConfirmarCambios();
            CargarGrid();
        }

        private void DgTablas_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MarcarModificacion(e.Row.GetIndex());
        }

        private void CargarGrid()
        {
            DiccionarioTablasModel vObjDiccionarioTablas = new DiccionarioTablasModel();

            //Antes de cargar los nuevos datos se valida si ya hay informacion
            if (DgTablas.ItemsSource != null)
            {
                DgTablas.ItemsSource = null;
            }

            DgTablas.ItemsSource = vObjDiccionarioTablas.obtenerTablasGUM().DefaultView;
        }

        private void AbrirVentanaAdicionarTablas()
        {

            AdicionarTablas frmAdicionarTablas = new AdicionarTablas();
            frmAdicionarTablas.Owner = this;
            frmAdicionarTablas.ShowDialog();

        }

        private void ConfirmarCambios()
        {
            DataView dtvTablasGUM = new DataView();
            DataView dtvTablasGUMfilter = new DataView();
            DiccionarioTablasModel vObjDiccionarioTablas = new DiccionarioTablasModel();

            //Se obtienen los datos que fueron editados en la tabla principal
            dtvTablasGUM = (DataView)DgTablas.ItemsSource;
            dtvTablasGUM.RowFilter = "f_ind_cambio =1";

            vObjDiccionarioTablas.confirmarCambiosGUm(dtvTablasGUM);
        }

        

        private void MarcarModificacion(int pvIntIndexRow)
        {
            DataView dtvTablasGUM = new DataView();
            DiccionarioTablasModel vObjDiccionarioTablas = new DiccionarioTablasModel();

            dtvTablasGUM = (DataView)DgTablas.ItemsSource;

            dtvTablasGUM.Table.Rows[pvIntIndexRow]["f_ind_cambio"] = 1;
        }
    }
}
