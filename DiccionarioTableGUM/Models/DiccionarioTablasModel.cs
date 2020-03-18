using DiccionarioTableGUM.Conexion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioTableGUM.Models
{
    class DiccionarioTablasModel
    {

        public DataTable obtenerTablasGUM()
        {
            clsConexionDB vObjConexionDB = new clsConexionDB();
            DataSet vDsTablas;

            vObjConexionDB.AbrirConexion();

            vDsTablas = vObjConexionDB.EjecutarCommand("sp_tablas_gum");

            return vDsTablas.Tables[0];
        }

        public void confirmarCambiosGUm(DataTable pvDataTable)
        {
            clsConexionDB vObjConexionDB = new clsConexionDB();
            
            //Objeto con parametros lista de parametros
            List<clsConexionDB.ParametrosSP> vParamsUserRolls;

            vObjConexionDB.AbrirConexion();


            for (int IndiceFila = 0; IndiceFila < pvDataTable.Rows.Count; IndiceFila++)
            {
                vParamsUserRolls = new List<clsConexionDB.ParametrosSP>();
                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_nombre_tabla",
                    ParamValue = pvDataTable.Rows[IndiceFila]["f_nombre"].ToString(),
                    Type = System.Data.SqlDbType.VarChar
                });


                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_descripcion_tabla",
                    ParamValue = pvDataTable.Rows[IndiceFila]["f_descripcion"].ToString(),
                    Type = System.Data.SqlDbType.VarChar
                });


                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_notas_tabla",
                    ParamValue = pvDataTable.Rows[IndiceFila]["f_notas"].ToString(),
                    Type = System.Data.SqlDbType.VarChar
                });


                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_ind_proceso_gum",
                    ParamValue = pvDataTable.Rows[IndiceFila]["f_ind_proceso_gum"].ToString(),
                    Type = System.Data.SqlDbType.SmallInt
                });


                var vListSIDocument = vObjConexionDB.EjecutarCommand("sp_editar_stablas_gum", vParamsUserRolls);
            
            }

            vObjConexionDB.CerrarConexion();
        }

    }
}


