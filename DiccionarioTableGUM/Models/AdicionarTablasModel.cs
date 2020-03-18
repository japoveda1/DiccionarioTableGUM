using DiccionarioTableGUM.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioTableGUM.Models
{
    class AdicionarTablasModel
    {
        public clsConexionDB pubConexionDB = new clsConexionDB();

        public DataTable ObtenerTablasDB()
        {
            pubConexionDB.AbrirConexion();
            DataSet vDsTablasDB;

            vDsTablasDB = pubConexionDB.EjecutarCommand("sp_dd_tablas_db");

            pubConexionDB.CerrarConexion();

            return vDsTablasDB.Tables[0];

        }






    }
}
