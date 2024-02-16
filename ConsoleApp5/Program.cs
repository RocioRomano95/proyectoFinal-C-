using Proyecto_finalRocioBRomano.database;
using Proyecto_finalRocioBRomano.models;

namespace clase10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorBaseDeDatos db = new GestorBaseDeDatos();

            try
            {
                //Usuario usuarioObtenido = db.ObtenerUsuarioPorId();
                //Console.WriteLine(usuarioObtenido.ToString());

                //Usuario crearUsuario = new Usuario("Pepe", "Perez", "pepeP", "1234", "pepe@gmail.com");
                //if (db.AgregarUsuario(crearUsuario))
                //{
                //    Console.WriteLine("nuevo usuario creado");
                //}

                //if (db.BorrarUsuarioPorId(5))
                //{
                //    Console.WriteLine("Borre un usuario");
                //} 

                //Usuario modificarUsuario = new Usuario("Rocio", "Romano", "rocioRo", "123", "rocior@mail.com");
                //if (db.ActualizarUsuarioPorId(6, modificarUsuario))
                //{
                //    Console.WriteLine("actualice un usuario");
                //}

                // Pruebas para la clase Producto
                //Producto productoObtenido = db.ObtenerProductoPorId(1);
                //Console.WriteLine(productoObtenido.ToString());

                //Producto nuevoProducto = new Producto("Producto Nuevo", 10, 15, 100, 1);
                //if (db.AgregarProducto(nuevoProducto))
                //{
                //    Console.WriteLine("Nuevo producto creado");
                //}

                //if (db.EliminarProductoPorId(5))
                //{
                //    Console.WriteLine("Producto eliminado");
                //}

                //Producto productoModificado = new Producto("Producto Modificado", 20, 25, 200, 2);
                //if (db.ActualizarProductoPorId(6, productoModificado))
                //{
                //    Console.WriteLine("Producto actualizado");
                //}

                //// Pruebas para la clase VentaData
                //VentaData ventaObtenida = db.ObtenerVentaPorId(1);
                //Console.WriteLine(ventaObtenida.ToString());

                //VentaData nuevaVenta = new VentaData("Nueva venta", 1);
                //if (db.AgregarVenta(nuevaVenta))
                //{
                //    Console.WriteLine("Nueva venta creada");
                //}

                //if (db.EliminarVentaPorId(3))
                //{
                //    Console.WriteLine("Venta eliminada");
                //}

                //VentaData ventaModificada = new VentaData("Venta Modificada", 2);
                //if (db.ModificarVentaPorId(4, ventaModificada))
                //{
                //    Console.WriteLine("Venta modificada");
                //}

                //// Pruebas para la clase ProductoVendidoData
                //ProductoVendidoData productoVendidoObtenido = db.ObtenerProductoVendidoPorId(1);
                //Console.WriteLine(productoVendidoObtenido.ToString());

                //ProductoVendidoData nuevoProductoVendido = new ProductoVendidoData(1, 10, 1);
                //if (db.AgregarProductoVendido(nuevoProductoVendido))
                //{
                //    Console.WriteLine("Nuevo producto vendido creado");
                //}

                //if (db.EliminarProductoVendidoPorId(3))
                //{
                //    Console.WriteLine("Producto vendido eliminado");
                //}

                //ProductoVendidoData productoVendidoModificado = new ProductoVendidoData(2, 20, 2);
                //if (db.ModificarProductoVendidoPorId(4, productoVendidoModificado))
                //{
                //    Console.WriteLine("Producto vendido modificado");
                //}



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            //Console.WriteLine("hola Ro!");


        }


    }

}