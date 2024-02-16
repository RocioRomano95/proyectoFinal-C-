using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_finalRocioBRomano.models
{
    public class Usuario
    {
    private int id;
    private string nombre;
    private string apellido;
    private string nombreUsuario;
        private string password;
    private string mail;

    public Usuario() { }
    public Usuario(string nombre, string apellido, string nombreUsuario,string password,string mail) {
        this.nombre = nombre;
            this.apellido = apellido;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.mail = mail;
         
        }
        public Usuario(int id, string nombre, string apellido, string nombreUsuario,string password, string mail) : this(nombre, apellido,nombreUsuario, password,mail)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
    public string Nombre { get =>nombre; set => nombre= value; }
    public string Apellido { get => apellido; set => apellido= value; }
    public string NombreUsuario { get => nombreUsuario; set => nombreUsuario= value; }
    public string Password { get => password; set => password = value; }
    public string Email { get =>mail; set => mail = value; }
    }
}
