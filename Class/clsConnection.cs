using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQUA_DATA.Class
{
    public class clsConnection
    {

        SqlConnection sqlCon = new SqlConnection();

        //Construtor
        public clsConnection()
        {
            sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["AquaDataDB"].ConnectionString;
        }

        //Método Conectar
        public SqlConnection Conectar()
        {
            if(sqlCon.State == System.Data.ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            return sqlCon;

        }

        public void Desconectar()
        {
            if (sqlCon.State == System.Data.ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

    }
}
