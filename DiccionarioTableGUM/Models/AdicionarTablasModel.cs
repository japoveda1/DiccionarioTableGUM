﻿using DiccionarioTableGUM.Conexion;
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

        public DataTable ObtenerTablasDelSistema()
        {
            pubConexionDB.AbrirConexion();
            DataSet vDsTablas;

            vDsTablas = pubConexionDB.EjecutarCommand("sp_tablas_gum");

            pubConexionDB.CerrarConexion();

            return vDsTablas.Tables[0];

        }



    }
}
