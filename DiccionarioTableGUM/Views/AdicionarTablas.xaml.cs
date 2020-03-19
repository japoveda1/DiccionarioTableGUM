using DiccionarioTableGUM.Models;
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

namespace DiccionarioTableGUM.Views
{
    /// <summary>
    /// Interaction logic for AdicionarTablas.xaml
    /// </summary>
    public partial class AdicionarTablas : Window
    {
        private int prvIntIndConRelacion;

        public AdicionarTablas()
        {
            InitializeComponent();
            CargarGrid();
           
        }

        private void CargarGrid()
        {

            DiccionarioTablasModel vObjDiccionarioTablas = new DiccionarioTablasModel();

            //Antes de cargar los nuevos datos se valida si ya hay informacion
            if (DgTablasDB.ItemsSource != null)
            {
                DgTablasDB.ItemsSource = null;
            }

            DgTablasDB.ItemsSource = vObjDiccionarioTablas.ObtenerTablasDB().DefaultView;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            prvIntIndConRelacion = 1;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            prvIntIndConRelacion = 0;
        }

        private void CmdAdiccionarTablas_Click(object sender, RoutedEventArgs e)
        {

            AdicionarTablasGum();
            CargarGrid();
            this.Close();
        }

        private void DgTablasDB_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ObtenerRelaciones(e.Row.GetIndex());
        }

        private void ObtenerRelaciones(int pvindexRow)
        {
            DataView dtvTablasDB = new DataView();
            DiccionarioTablasModel vObjDiccionarioTablas = new DiccionarioTablasModel();

            dtvTablasDB = (DataView)DgTablasDB.ItemsSource;

            vObjDiccionarioTablas.ObtenerRealaciones(dtvTablasDB.Table.Rows[pvindexRow]["f_nombre_tabla"].ToString());
        }

        private void AdicionarTablasGum() {

            DataView dtvTablasDB = new DataView();
            DiccionarioTablasModel vObjDiccionarioTablas = new DiccionarioTablasModel();

            //Se obtienen los datos que fueron editados en la tabla principal
            dtvTablasDB = (DataView)DgTablasDB.ItemsSource;

            //revisar si es 1!!!!
            dtvTablasDB.RowFilter = "f_seleccion = 1";

            vObjDiccionarioTablas.AdicionartablasGUM(dtvTablasDB);
            dtvTablasDB.RowFilter = string.Empty;            

        }


    }
}
