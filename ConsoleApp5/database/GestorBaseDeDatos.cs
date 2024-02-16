using Proyecto_finalRocioBRomano.models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_finalRocioBRomano.database
{
    public class GestorBaseDeDatos 
{

        private string stringConnection;
        public GestorBaseDeDatos()
        {
            this.stringConnection = "Server=.;Database=coderhouseDB;Trusted_Connection=True;";
        }
        public Usuario ObtenerUsuarioPorId(int id)
        {
            using (SqlConnection connection = new(this.stringConnection))
            {
                string query = "select * from Usuario where id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idObjeto = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string email = reader.GetString(5);

                    Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, password, email);


                    return usuario;
                }
                throw new Exception("id no encontrado");
            }

        }

        //metodo nuevo
        public bool AgregarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new(this.stringConnection))
            {
                string query = "insert into Usuario (Nombre, Apellido,NombreUsuario,Contraseña, Mail) values (@nombre,@apellido,@nombreUsuario,@password,@email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("password", usuario.Password);
                command.Parameters.AddWithValue("email", usuario.Email);

                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }
        public bool BorrarUsuarioPorId(int id)
        {
            using (SqlConnection connection = new(this.stringConnection))
            {
                string query = "delete from Usuario where id=@id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }

        public bool ActualizarUsuarioPorId(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "update Usuario set Nombre=@nombre,Apellido=@apellido,Mail=@email, Contraseña=@password,NombreUsuario=@nombreUsuario where id=@id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("password", usuario.Password);
                command.Parameters.AddWithValue("email", usuario.Email);

                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Usuario";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string email = reader.GetString(5);

                    Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, password, email);
                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        //--para Producto

        public Producto ObtenerProductoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "Select * from Producto where id=@id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idProducto = Convert.ToInt32(reader["id"]);
                    string descripcion = reader.GetString(1);
                    double costo = Convert.ToInt32(reader["costo"]);
                    double precioVenta = Convert.ToInt32(reader["precioVenta"]);
                    int stock = Convert.ToInt32(reader["stock"]);
                    int idUsuario = Convert.ToInt32(reader["idUsuario"]);

                    Producto producto = new Producto(idProducto, descripcion, costo, precioVenta, stock, idUsuario);

                    return producto; // Aquí se devuelve el objeto Producto encontrado
                }
                throw new Exception("id de producto no encontrado");
            }
        }
        public bool AgregarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Producto (Descripcion, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@descripcion, @costo, @precioVenta, @stock, @idUsuario)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idUsuario", producto.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarProductoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM Producto WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool ModificarProductoPorId(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Producto SET Descripcion = @descripcion, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock, IdUsuario = @idUsuario WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idUsuario", producto.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Producto";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string descripcion = reader.GetString(1);
                    double costo = Convert.ToDouble(reader["Costo"]);
                    double precioVenta = Convert.ToDouble(reader["PrecioVenta"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);

                    Producto producto = new Producto(id, descripcion, costo, precioVenta, stock, idUsuario);
                    productos.Add(producto);
                }
            }

            return productos;
        }




        //--productoVendidoData
        public bool AgregarProductoVendido(ProductoVendidoData productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO ProductoVendido (IdProducto, Stock, IdVenta) VALUES (@idProducto, @stock, @idVenta)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("stock", productoVendido.Stock);
                command.Parameters.AddWithValue("idVenta", productoVendido.IdVenta);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarProductoVendidoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool ModificarProductoVendidoPorId(int id, ProductoVendidoData productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE ProductoVendido SET IdProducto = @idProducto, Stock = @stock, IdVenta = @idVenta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("stock", productoVendido.Stock);
                command.Parameters.AddWithValue("idVenta", productoVendido.IdVenta);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<ProductoVendidoData> ListarProductosVendidos()
        {
            List<ProductoVendidoData> productosVendidos = new List<ProductoVendidoData>();

            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    int idProducto = Convert.ToInt32(reader["IdProducto"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idVenta = Convert.ToInt32(reader["IdVenta"]);

                    ProductoVendidoData productoVendido = new ProductoVendidoData(id, idProducto, stock, idVenta);
                    productosVendidos.Add(productoVendido);
                }
            }

            return productosVendidos;
        }

        public ProductoVendidoData ObtenerProductoVendidoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["Id"]);
                    int idProducto = Convert.ToInt32(reader["IdProducto"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idVenta = Convert.ToInt32(reader["IdVenta"]);

                    ProductoVendidoData productoVendido = new ProductoVendidoData(productId, idProducto, stock, idVenta);
                    return productoVendido;
                }
                else
                {
                    throw new Exception("Producto vendido no encontrado");
                }
            }
        }

        //--VentaData
        public bool AgregarVenta(VentaData venta)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@comentarios, @idUsuario)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarVentaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool ModificarVentaPorId(int id, VentaData venta)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Venta SET Comentarios = @comentarios, IdUsuario = @idUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<VentaData> ListarVentas()
        {
            List<VentaData> ventas = new List<VentaData>();

            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Venta";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string comentarios = reader.GetString(1);
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);

                    VentaData venta = new VentaData(id, comentarios, idUsuario);
                    ventas.Add(venta);
                }
            }

            return ventas;
        }

        public VentaData ObtenerVentaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Venta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int ventaId = Convert.ToInt32(reader["Id"]);
                    string comentarios = reader.GetString(1);
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);

                    VentaData venta = new VentaData(ventaId, comentarios, idUsuario);
                    return venta;
                }
                else
                {
                    throw new Exception("Venta no encontrada");
                }
            }
        }




    }
}
