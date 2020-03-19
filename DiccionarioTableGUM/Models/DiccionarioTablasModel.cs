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

        public void confirmarCambiosGUm(DataView pvDataView)
        {
            clsConexionDB vObjConexionDB = new clsConexionDB();
            
            //Objeto con parametros lista de parametros
            List<clsConexionDB.ParametrosSP> vParamsUserRolls;

            vObjConexionDB.AbrirConexion();

            

            foreach (DataRowView vObjRow in pvDataView)
            {
                

                vParamsUserRolls = new List<clsConexionDB.ParametrosSP>();
                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_nombre_tabla",
                    ParamValue = vObjRow["f_nombre"].ToString(),
                    Type = System.Data.SqlDbType.VarChar
                });


           
                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_descripcion_tabla",
                    ParamValue = vObjRow["f_descripcion"].ToString(),
                    Type = System.Data.SqlDbType.VarChar
                });


                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_notas_tabla",
                    ParamValue = vObjRow["f_notas"].ToString() , 
                    Type = System.Data.SqlDbType.VarChar
                });


                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_ind_proceso_gum",
                    ParamValue = vObjRow["f_ind_proceso_gum"].ToString() ,
                    Type = System.Data.SqlDbType.SmallInt
                });


                var vListSIDocument = vObjConexionDB.EjecutarCommand("sp_editar_stablas_gum", vParamsUserRolls);
            
            }

            vObjConexionDB.CerrarConexion();
        }


        public DataTable ObtenerTablasDB()
        {
            clsConexionDB vObjConexionDB = new clsConexionDB();

            vObjConexionDB.AbrirConexion();
            DataSet vDsTablasDB;

            vDsTablasDB = vObjConexionDB.EjecutarCommand("sp_dd_tablas_db");

            vObjConexionDB.CerrarConexion();

            return vDsTablasDB.Tables[0];

        }


        public void AdicionartablasGUM(DataView pvDtvTablasGUM)
        {
            //creo la conexion a la base de datos
            clsConexionDB vObjConexionDB = new clsConexionDB();

            //Objeto donde se van a almacenar los parametros para el sp
            List<clsConexionDB.ParametrosSP> vParamsUserRolls;

            //abro conexxion
            vObjConexionDB.AbrirConexion();

            foreach (DataRowView vDrvTabla in pvDtvTablasGUM)
            {


                vParamsUserRolls = new List<clsConexionDB.ParametrosSP>();

                vParamsUserRolls.Add(new clsConexionDB.ParametrosSP
                {
                    ParamName = "p_nombre_tabla",
                    ParamValue = vDrvTabla["f_nombre_tabla"].ToString(),
                    Type = System.Data.SqlDbType.VarChar
                });

                var vListSIDocument = vObjConexionDB.EjecutarCommand("sp_dd_insetar_tablas_gum", vParamsUserRolls);

            }

            vObjConexionDB.CerrarConexion();
        }


        public DataTable ObtenerRealaciones(string pvStrNombreTabla)
        {

            //creo la conexion a la base de datos
            clsConexionDB vObjConexionDB = new clsConexionDB();
            vObjConexionDB.AbrirConexion();
            DataSet vDsRelacionTablas;
           

            //Objeto donde se van a almacenar los parametros para el sp
            clsConexionDB.ParametrosSP vParamsUserRolls;

            vParamsUserRolls = new clsConexionDB.ParametrosSP
            {
                ParamName = "p_nombre_tabla",
                ParamValue = pvStrNombreTabla,
                Type = System.Data.SqlDbType.VarChar
            };

            vDsRelacionTablas = vObjConexionDB.EjecutarCommand("sp_dd_rel_tabla_gum");

            vObjConexionDB.CerrarConexion();

            return vDsRelacionTablas.Tables[0];

        }
    }
}


