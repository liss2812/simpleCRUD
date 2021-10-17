using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace simpleCRUD
{
    class Documento
    {
        //propiedades
        public int _documentoid { get; set; }
        public string _title { get; set; }
        public string _contenido { get; set; }
        public string _fechapublicacion { get; set; }
        public string _descripcion { get; set; }

        //instancias a la clase Crud
        private Crud crud = new Crud();

        //metodo para retornar los registros de la tabla Documento
        public MySqlDataReader getAllDocumentos()
        {
            string query = "SELECT documentoid,titulo,contenido,fechapublicacion,descripcion FROM documento";

            //llamado al metodo select de la clase Crud
            return crud.select(query);
        }
    }
}
