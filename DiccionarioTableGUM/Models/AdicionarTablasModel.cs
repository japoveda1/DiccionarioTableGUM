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





    }
}
