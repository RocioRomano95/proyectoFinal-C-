using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_finalRocioBRomano.models
{
    public class VentaData
{
        private int id;
        private string comentarios;
        private int idUsuario;

        public  VentaData() { }
        public VentaData(int id,string comentarios,int idUsuario ) {
            this.id =id;
            this.comentarios = comentarios;
            this.idUsuario = idUsuario;
        }

        public int Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
         
    }
}
