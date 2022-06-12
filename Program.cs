using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera_aplicacion_vs1
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuopcion;

            Producto producto = new Producto();     /*Instancia u objeto de producto*/
            CategoriaProducto categoria = new CategoriaProducto(); /*iNSTANCIA*/
            ArrayList AProducto = new ArrayList();  //array que guarda los productos
            ArrayList ListaCategorias = new ArrayList();    //array que guarda las categorias

            ListaCategorias.Add(new CategoriaProducto("001", "Catg1", true));    //Agregando una categoria en la lista

            AProducto.Add(new Producto(1, "001", 100, "Prueba", 10, true)); //agregando productos a la lista
            AProducto.Add(new Producto(2, "001", 43, "Prueba2", 50, false));

            do
            {
                Console.Clear();
                Cuadro(1, 80, 1, 7);        //Invocacion al metodo cuadro con valores para sus parametros 
                Titulos();                  //Invocacion al metodo que muestra los titulos
                Menu();                     //Invocacion al metodo que muestra las opciones del menu
                menuopcion = Menuchoise();  //Invocacion al metodo para capturar la opcion elegida
                DoChoise(menuopcion, AProducto, producto, ListaCategorias, categoria);       //Invocacion al metodo que ejecutara la opcion correspodiente

                Console.ReadKey();

            } while (menuopcion != 0);

        }

        // metodo que escribe el cuadro 

        public static void Cuadro(int x1, int x2, int y1, int y2)
        {
            {
                //creamos las lineas horizontales
                for (int x = x1; x <= x2; x++)
                {
                    Console.SetCursorPosition(x, y1); Console.Write('═'); // Alt+205
                    Console.SetCursorPosition(x, y2); Console.Write('═');
                }

                //creamos las lineas verticales
                for (int y = y1; y <= y2; y++)
                {
                    Console.SetCursorPosition(x1, y); Console.Write('║');
                    Console.SetCursorPosition(x2, y); Console.Write('║');
                }
                Console.SetCursorPosition(x1, y1); Console.Write("╔");
                Console.SetCursorPosition(x2, y1); Console.Write("╗");
                Console.SetCursorPosition(x1, y2); Console.Write("╚");
                Console.SetCursorPosition(x2, y2); Console.Write("╝");

            }
        }

        public static void Titulos()
        {
            string t1 = "Empresas Los Vendedores, S. A.",
                t2 = "El placer del buen servicio",
                t3 = "Sistena de inventario",
                
                t5 = "M e n u   P r i n c i p a l";

            Console.SetCursorPosition((80 - t1.Length) / 2, 2); Console.Write(t1);
            Console.SetCursorPosition((80 - t2.Length) / 2, 3); Console.Write(t2);
            Console.SetCursorPosition((80 - t3.Length) / 2, 4); Console.Write(t3);
            
            Console.SetCursorPosition((80 - t5.Length) / 2, 6); Console.Write(t5);

        }

        public static void Menu()
        {
            Console.SetCursorPosition(15, 8); Console.Write("1- Registrar categoria de productos");
            Console.SetCursorPosition(15, 9); Console.Write("2- Registrar productos");
            Console.SetCursorPosition(15, 10); Console.Write("3- Aumentar inventario");
            Console.SetCursorPosition(15, 11); Console.Write("4- Reducir inventario");
            Console.SetCursorPosition(15, 12); Console.Write("5- Cambiar precios");
            Console.SetCursorPosition(15, 13); Console.Write("6- Consultar inventario");
            Console.SetCursorPosition(15, 14); Console.Write("7- Consultar por categoría");
            Console.SetCursorPosition(15, 15); Console.Write("8- Activar o desactivar inventario");
            Console.SetCursorPosition(15, 16); Console.Write("9- Consultar categorias");
            Console.SetCursorPosition(15, 17); Console.Write("0- Salir");
        }


        public static int Menuchoise()
        {
            int op = 20;
            do
            {
                try
                {
                    Console.SetCursorPosition(15, 19); Console.Write("Su opcion: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    if (op < 0 || op > 9)
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine("Ha elegido una opcion no valida");
                    }
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine(e.Message);
                }
            } while (op < 0 || op > 9);
            return op;
        }

        public static void DoChoise(int opcion, ArrayList AProducto, Producto producto, ArrayList ListaCats, CategoriaProducto categ)
        {
            switch (opcion)
            {
                case 1:
                    registrarCategorias(ListaCats, categ);
                    //Console.SetCursorPosition(20, 24); Console.Write("Opcion 1");
                    break;

                case 2:
                    RegistrarProducto(AProducto, producto, ListaCats, categ);
                    //Console.SetCursorPosition(20, 24); Console.Write("Opcion 2");
                    break;

                case 3:
                    AumentarInventario(AProducto, producto);
                    break;

                case 4:
                    DisminuirInventario(AProducto, producto);
                    //Console.SetCursorPosition(20, 24); Console.Write("Opcion 4");
                    break;

                case 5:
                    cambiaPrecio(AProducto, producto);
                    break;

                case 6:
                    ConsultarInventario(AProducto, producto);
                    //Console.SetCursorPosition(20, 24); Console.Write("Opcion 5");
                    break;

                case 7:
                    verPorCategoria(AProducto, producto, ListaCats, categ);
                    break;

                case 8:
                    activarDesactivar(AProducto, producto, ListaCats, categ);
                    break;

                case 9:
                    ConsultarCategorias(AProducto, producto, ListaCats, categ);
                    break;

            }
        }

        public static void RegistrarProducto(ArrayList AProd, Producto prod, ArrayList ListaCategorias, CategoriaProducto categoria)
        {
            int vidprod = 0, vexistencia = 0;
            string vidcategoria = "";
            double vprecio = 0.0;
            string vnombre = "Prueba";
            bool vactivo = true;

            int fila = 14;

            List<string> listaIdsCat = new List<string>();  // lista para almacenar los ids de categorias
            List<int> listaIDProductos = new List<int>();  // lista para almacenar los ids de productos 

            limpia(1, 79, 8, 20); //metodo que limpia la pantalla

            Console.SetCursorPosition(28, 10); Console.Write("REGISTRO DE PRODUCTOS");

            foreach (Producto c in AProd)
            {
                listaIDProductos.Add(c.getIDProducto());
            }

            // Tomando el valor IDP

            bool banderaIDp = true;

            while (banderaIDp || vidprod < 0 || listaIDProductos.Contains(vidprod))
            {

                try
                {
                    Console.SetCursorPosition(5, 12); Console.Write("ID Producto.....: ");
                    vidprod = Convert.ToInt32(Console.ReadLine());

                    if (vidprod < 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine("Error, el ID no puede ser un número menor que 0             ");
                    }
                    else if (listaIDProductos.Contains(vidprod))
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine("Error, el ID ya existe             ");
                    }
                    else
                        banderaIDp = false;
                }

                catch (Exception a)
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine(a.Message);

                }

            }

            //Imprimir catgorias con ids

            // -----------CATEGORIAS----------------------

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int x = 50; x < 69; x++)
            {
                Console.SetCursorPosition(x, 12); Console.Write(" ");

            }

            Console.SetCursorPosition(45, 12); Console.Write(" Categorías   ");
            Console.SetCursorPosition(60, 12); Console.Write("  ID ");
            Console.SetCursorPosition(67, 12); Console.Write("Estado  ");

            Console.ResetColor();

            foreach (CategoriaProducto c in ListaCategorias)
            {
                Console.SetCursorPosition(45, fila); Console.WriteLine(c.getNombreCategoria());
                Console.SetCursorPosition(62, fila); Console.WriteLine(c.getIDCategoriaProducto());
                Console.SetCursorPosition(67, fila); Console.WriteLine(c.getEstadoCategoria() ? "Activo" : "Inactivo");
                fila++;
            }

            //--------------------------------

            Console.SetCursorPosition(45, listaIdsCat.Count() + fila); Console.WriteLine("______________________________");


            // guardando los valores en un array para verificar si existe el id ingresado

            foreach (CategoriaProducto c in ListaCategorias)
            {
                listaIdsCat.Add(c.getIDCategoriaProducto());
            }

            // tomando id categoria

            do
            {
                Console.SetCursorPosition(5, 13); Console.Write("ID Categoría....: ");
                vidcategoria = Console.ReadLine();

                if (!listaIdsCat.Contains(vidcategoria))
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine("El ID ingresado no existe en la lista               ");

                }
            }
            while (!listaIdsCat.Contains(vidcategoria));
            
            // limpiando la linea 24
            for (int x=0;x< 70; x++)

            {
                Console.SetCursorPosition(x, 24); Console.WriteLine(" ");
            }

            // si la categoria esta activa poner el producto activo

            foreach (CategoriaProducto c in ListaCategorias)
            {
                if (c.getIDCategoriaProducto() == vidcategoria )
                {
                    vactivo = c.getEstadoCategoria();
                }
            }

            // Para que no se repita el nombre

            ArrayList nombresP = new ArrayList();

            // guardando los nombres en la lista
            foreach (Producto p in AProd)
            {
                nombresP.Add(p.getNombre());                
            }

            while (nombresP.Contains(vnombre) || vnombre == "" || vnombre == " ")
            {
                Console.SetCursorPosition(5, 14); Console.Write("Nombre..........: ");
                vnombre = Console.ReadLine();

                if (nombresP.Contains(vnombre))
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine("Error, el nombre ya existe                         ");
                }
                else if (vnombre == "" || vnombre == " ")
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine("Error, el nombre no puede estar en blanco                         ");
                }
            }

            // Entrada de la existencia 

            bool banderaExist = true;

            while (banderaExist || vexistencia < 0)
            {
                try
                {
                    Console.SetCursorPosition(5, 15); Console.Write("Existencia......: ");
                    vexistencia = Convert.ToInt32(Console.ReadLine());

                    if (vexistencia< 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine("Error, el precio no puede ser un número menor que 0             ");

                    }
                    else
                    {
                        banderaExist = false;
                    }

                }
                catch (Exception e)
                {

                    Console.SetCursorPosition(20, 24); Console.WriteLine(e.Message);
                }

            }

            // tomando precio

            bool banderaPrec = true;

            while (banderaPrec || vprecio < 0)
            {
                try
                {

                    Console.SetCursorPosition(5, 16); Console.Write("Precio..........: ");
                    vprecio = double.Parse(Console.ReadLine());

                    if (vprecio < 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine("Error, el precio no puede ser un número menor que 0             ");

                    }
                    else
                    {
                        banderaPrec = false;
                    }
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine(e.Message);
                }

            }

            // Agrego el nuevo objeto al final del arraylist

            AProd.Add(new Producto(vidprod, vidcategoria, vexistencia, vnombre, vprecio, vactivo));

            Console.SetCursorPosition(20, 24); Console.WriteLine("Producto registrado satisfactoriamente!               ");
            

        }   //fin del metodo registrar producto


        public static void ConsultarInventario(ArrayList Aprod, Producto prod)
        {
            bool colorFila = true;

            int fila = 12;
            limpia(1, 79, 8, 20);

            Console.SetCursorPosition(28, 09); Console.Write("PRODUCTOS EN EL INVENTARIO");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 11); Console.Write("IDProducto|IDCategoria| Nombre del producto    |Existencia|  Precio | Estado ");
            Console.ResetColor();

            // para altenar color de fondo de las lineas de la tabla

            foreach (Producto p in Aprod)
            {
                if (colorFila)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;

                }

                for (int X = 0; X < 77; X++)
                {
                    Console.SetCursorPosition(X+1, fila); Console.Write(" ");
                }

                Console.SetCursorPosition(2, fila); Console.Write(p.getIDProducto());
                Console.SetCursorPosition(13, fila); Console.Write(p.getIDCategoria());
                Console.SetCursorPosition(25, fila); Console.Write(p.getNombre());
                Console.SetCursorPosition(50, fila); Console.Write(p.getExistencia());
                Console.SetCursorPosition(61, fila); Console.Write(p.getPrecio());
                Console.SetCursorPosition(70, fila); Console.Write(p.getActivo() ? "Activo" : "Inactivo");
                fila++;
                Console.ResetColor();
                
                

                if (colorFila)
                {
                    colorFila = false;
                }
                else
                    colorFila = true;


            }
            Console.SetCursorPosition(2, Aprod.Count + 12);

        }

        

        //Metodo para aumentar la cantidad de un producto

        public static void AumentarInventario(ArrayList Aprod, Producto prod)
        {
            int fila = 15;
            int fila2 = 15;
            bool actInac = true;    //Para guardar si el objeto esta activo o no

            int contador = 0;

            int cantidad = 0;
            string nombre="";
            ArrayList Nombres = new ArrayList();
            bool banderaAum = true;

            limpia(1, 79, 8, 20);   //limpiando la pantalla


            //guardando los nombres de los productos en una nueva lista

            foreach (Producto p in Aprod)
            {
                Nombres.Add(p.getNombre());
            }        

            Console.SetCursorPosition(28, 10); Console.Write("AUMENTAR INVENTARIO");

            //-----------CUADRO PRODUCTOS----------------

            Console.BackgroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(4, 13); Console.Write("   Productos   ");
            Console.ResetColor();

            foreach (string p in Nombres)
            {
                Console.SetCursorPosition(4, fila); Console.Write(p);
                fila ++;
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            //--------------------

            string pie = new string('_', 23);

            Console.SetCursorPosition(4, fila);   Console.Write(pie);
            Console.ResetColor();


            // ---------------CUADRO CANTIDAD---------------

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(20, 13); Console.Write(" Cant. ");
            Console.ResetColor();

            foreach (Producto p in Aprod)
            {
                Console.SetCursorPosition(20, fila2); Console.Write(p.getExistencia());
                fila2 ++;
            }

            
            // Ciclo que va a seguir pidiendo el nombre mientras se ingrese uno que no esta en la lista
            // entrada del nombre
            do
            {   
                
                Console.SetCursorPosition(36, 16); Console.Write("Presione 0 para salir");
                Console.SetCursorPosition(36, 12); Console.Write("Nombre del producto a aumentar: ");
                nombre = Console.ReadLine();

                if (nombre == "0")
                {
                    break;
                }

                if (!Nombres.Contains(nombre))
                {
                    Console.SetCursorPosition(20, 24); Console.Write($"{nombre} no existe en la lista");
                }

                // Para comprobar si el producto esta activo

                foreach (Producto x in Aprod)
                {
                    if (nombre == x.getNombre())
                    {
                        actInac = x.getActivo();
                    }
                }

                if (!actInac)
                {
                    Console.SetCursorPosition(20, 24); Console.Write("* * * No se puede aumentar stock a una línea descontinuada * * *                  ");
                }


            } while (!Nombres.Contains(nombre) || !actInac );
            actInac = true;     //Devolviendo a activo para que no muestre el mensaje de error

            // Entrada de cantiad
            if (nombre != "0")
            {
            
                while (banderaAum || cantidad < 0 )
                {

                    try
                    {
                        Console.SetCursorPosition(36, 13); Console.Write("Cantidad a aumentar...........: ");
                        cantidad = Convert.ToInt32(Console.ReadLine());
                        banderaAum = false;

                        if (cantidad < 0)
                        {
                            Console.SetCursorPosition(20, 24); Console.Write("Error la cantidad a reducir no puede ser menor que 0                ");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine(e.Message + "          ");
                    }

                }
             // Actualizando la cantidad
                 foreach (Producto j in Aprod)
                 {


                     if (j.getNombre() == nombre)
                     {
                         j.AgregarAInventario(cantidad);
                        Console.SetCursorPosition(20, 24); Console.WriteLine("Producto actualizado correctamente!                     ");

                         break;
                     }

                     contador++;
                 }

            }

        }

        //Metodo para registrar nuevas categorias

        public static void registrarCategorias(ArrayList LCategs, CategoriaProducto categoria)
        {
            string nombreC = "";
            int estadoC = 0;
            string codigoString = "00";
            bool estadoCF;
            bool banderaEstado = true;
            List<string> listaNombresCat = new List<string>();  // lista para almacenar los nombres y comprobar que no se repitan

            // obteniendo los nombres de la categoria en una lista

            foreach (CategoriaProducto c in LCategs)
            {
                listaNombresCat.Add(c.getNombreCategoria());
            }

            limpia(1, 79, 8, 20);   //LIMPIANDO LA PANTALLA

            Console.SetCursorPosition(30, 10); Console.Write("REGISTRAR CATEGORIA");

            // Entrada del nombre de la categoria

            while (nombreC == "" || nombreC == " " || listaNombresCat.Contains(nombreC))    // no aceptar valor vacio ni repetido
            {
                Console.SetCursorPosition(15,13);    Console.Write("Nombre de la categoria....: ");
                nombreC = Console.ReadLine();

                if (nombreC == "" || nombreC == " ")
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine("Error - El nombre de la categoria no puede estar en blanco                     ");
                }

                else if (listaNombresCat.Contains(nombreC))
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine("Error - Ya existe una categoria con ese nombre                     ");
                }
            }

            // tomando el estado de la categoria

            while (banderaEstado)
            {
                try
                {
                    Console.SetCursorPosition(15,15);    Console.Write("Estado, (ingrese 1 ó 2):");
                    Console.SetCursorPosition(15,16);    Console.Write("1- Activa");
                    Console.SetCursorPosition(15,17);    Console.Write("2- Inactiva");
                    Console.SetCursorPosition(15,19);    Console.Write("Estado de la categoria....: ");

                    estadoC = int.Parse(Console.ReadLine());

                    while (estadoC != 1 && estadoC != 2)    //para que solo tome los valores 1 y 2
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Opcion inexistente, elija 1 ó 2 solamente          ");
                        Console.SetCursorPosition(43, 19); estadoC = int.Parse(Console.ReadLine());

                    }

                    banderaEstado = false;  // si no ocurre una execpcion finaliza el ciclo
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine(e.Message + "          "); // mostrando el mensaje de error en pantalla
                }
            }

            //convertir el estado de entero a bool

            if (estadoC == 1)
            {
                estadoCF = true;
            }
            else
            {
                estadoCF = false;
            }

            // creando el código string de la categoria 

            codigoString += categoria.getContadorCats().ToString();

            // guardando el objeto de la clase categoria en el array de categorias

            LCategs.Add(new CategoriaProducto(codigoString, nombreC, estadoCF));

            //LLamado de la funcion para aumentar el contador de codigo de clase

            categoria.aumentaContadorCat();

            Console.SetCursorPosition(20, 24); Console.WriteLine("Categoria registrada correctamente!                                       ");

        }


        //Metodo para aumentar la cantidad de un producto

        public static void DisminuirInventario(ArrayList Aprod, Producto prod)
        {


            //int contador = 0;

            int fila = 15;
            int fila2 = 15;

            bool actInac = true;    //Para guardar si el objeto esta activo o no

            int cantidad = 0;
            string nombre="";
            ArrayList Nombres = new ArrayList();
            bool banderaDism = true;
            int exist = 0;

            limpia(1, 79, 8, 20);   //limpiando la pantalla


            //guardando los nombres de los productos en una nueva lista

            foreach (Producto p in Aprod)
            {
                Nombres.Add(p.getNombre()); 
            }
            Console.SetCursorPosition(28, 10); Console.Write("REDUCIR INVENTARIO");

            //-----------CUADRO PRODUCTOS----------------

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(4, 13); Console.Write("   Productos   ");
            Console.ResetColor();

            foreach (string p in Nombres)
            {
                Console.SetCursorPosition(4, fila); Console.Write(p);
                fila++;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            //------------------------
            string pie = new string('_', 23);
            Console.SetCursorPosition(4, fila); Console.Write(pie);
            Console.ResetColor();

            //-----------CUADRO CANTIDAD--------

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 13); Console.Write(" Cant. ");
            Console.ResetColor();

            foreach (Producto p in Aprod)
            {
                Console.SetCursorPosition(20, fila2); Console.Write(p.getExistencia());
                fila2++;
            }

            // Ciclo que va a seguir pidiendo el nombre mientras se ingrese uno que no esta en la lista

            do
            {
                Console.SetCursorPosition(36, 16); Console.Write("Presione 0 para salir");

                Console.SetCursorPosition(36, 12); Console.Write("Nombre del producto a reducir: ");
                nombre = Console.ReadLine();
                

                if (nombre == "0")
                {
                    break;

                }

                if (!Nombres.Contains(nombre))
                {
                    Console.SetCursorPosition(20, 24); Console.Write($"{nombre} no existe en la lista");
                }

                // Para comprobar si el producto esta activo
 
                foreach (Producto x in Aprod)
                {
                    if (nombre == x.getNombre())
                    {
                        actInac = x.getActivo();
                    }
                }

                if (!actInac)
                {
                    Console.SetCursorPosition(20, 24); Console.Write("* * * No se puede reducir stock a una línea descontinuada * * *                  ");
                }


            } while (!Nombres.Contains(nombre) || !actInac);
            actInac = true; //Devolviendo a activo para que no muestre el mensaje de error

            if (nombre != "0")
            {


                //Para pedir la cantidad a pesar de errores

                while (banderaDism)
                {

                    try
                    {
                        while (true)
                        {

                            Console.SetCursorPosition(36, 13); Console.Write("Cantidad a reducir...........: ");
                            cantidad = Convert.ToInt32(Console.ReadLine());

                            //obteniendo la existencia del producto

                            foreach (Producto p in Aprod)
                            {
                                if (nombre == p.getNombre())
                                {
                                    exist = p.getExistencia();
                                }
                            }

                            if (cantidad > exist)
                            {

                                Console.SetCursorPosition(20, 24); Console.Write("Error la cantidad a reducir no puede ser mayor a la existente              ");
                            }

                            else if (cantidad < 0)
                            {
                                Console.SetCursorPosition(20, 24); Console.Write("Error la cantidad a reducir no puede ser negativa              ");
                            }

                            else
                                break;

                        }


                        banderaDism = false;
                    }
                    catch (Exception e)
                    {
                        Console.SetCursorPosition(20, 24); Console.WriteLine(e.Message + "                ");
                    }

                }
                // Actualizando la cantidad

                foreach (Producto j in Aprod)
                {

                    if (j.getNombre() == nombre)
                    {
                        j.ReducirInventario(cantidad);     //llamado de la funcion reducirInventario()

                        Console.SetCursorPosition(20, 24); Console.WriteLine("Producto actualizado correctamente!                                 ");

                        break;
                    }

                    //contador++;
                }
            }
        }

        // metodo para ver por categorias 

        public static void verPorCategoria(ArrayList Aprod, Producto prod, ArrayList ListaCategorias, CategoriaProducto categoria)
        {
            int fila = 16;
            int fila2 = 14;
            bool colorFila = true;
            string nombreC = "";
            List<string> listaNombreCat = new List<string>();  // lista para almacenar los nombres de la categoria

            // guardando los nombres de las categorias en la lista
            foreach (CategoriaProducto c in ListaCategorias)
            {
                listaNombreCat.Add(c.getNombreCategoria());
            }

            limpia(1, 79, 8, 20);

            Console.SetCursorPosition(28, 10); Console.Write("CONSULTAR POR CATEGORIA");

            // ------------Tabla con las categorias existentes------------
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 14); Console.WriteLine("   Categoría   |  ID  |  Estado  ");
            Console.ResetColor();
            //escribiendo las categorias

            foreach (CategoriaProducto c in ListaCategorias)
            {

                Console.SetCursorPosition(2, fila); Console.WriteLine(c.getNombreCategoria());
                Console.SetCursorPosition(18, fila); Console.WriteLine(c.getIDCategoriaProducto());
                Console.SetCursorPosition(25, fila); Console.WriteLine(c.getEstadoCategoria() ? "Activo": "Inactivo");
                fila ++;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(1, fila); Console.WriteLine("_________________________________");
            Console.ResetColor();

            // _____FIN DE LA TABLA________________


            // ENTRADA DEL NOMBRE DE LA CATEGORIA A BUSCAR


            while (!listaNombreCat.Contains(nombreC))
            {
                Console.SetCursorPosition(40, 14); Console.Write("Nombre de la categoría a buscar: ");
                nombreC = Console.ReadLine();

                if (!listaNombreCat.Contains(nombreC))
                {
                    Console.SetCursorPosition(20, 24); Console.WriteLine("Error - El nombre indicado no existe                     ");

                }
            }


            // mostrar la categoria indicada

            limpia(1, 85, 8, 30);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(30, 10); Console.Write($"   {nombreC.ToUpper()}   ");
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(1, 12); Console.Write(" IDProducto |IDCategoria|   Nombre del producto  |Existencia|  Precio | Estado ");
            Console.ResetColor();

            foreach (Producto p in Aprod)
            {
                if (colorFila)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;

                }


                // si el producto pertence a la categoria
                // con el nombre obtengo el id, en cada iteracion obtengo el id

                string idCat = "";

                foreach (CategoriaProducto c in ListaCategorias)
                {
                    if (c.getNombreCategoria() == nombreC)
                    {
                        idCat = c.getIDCategoriaProducto();
                    }
                }
                if (idCat == p.getIDCategoria())
                {
                    for (int i = 1; i < 80; i ++)
                    {
                        Console.SetCursorPosition(i, fila2); Console.WriteLine(" ");
                    }

                    Console.SetCursorPosition(4, fila2); Console.Write(p.getIDProducto());
                    Console.SetCursorPosition(15, fila2); Console.Write(p.getIDCategoria());
                    Console.SetCursorPosition(27, fila2); Console.Write(p.getNombre());
                    Console.SetCursorPosition(52, fila2); Console.Write(p.getExistencia());
                    Console.SetCursorPosition(63, fila2); Console.Write(p.getPrecio());
                    Console.SetCursorPosition(72, fila2); Console.Write(p.getActivo() ? "Activo" : "Inactivo");
                    fila2 ++; 
                }
                Console.ResetColor();

                if (colorFila)
                {
                    colorFila = false;
                }
                else
                    colorFila = true;
            }
        }


        // metodo para activar o desactivar categorias o productos

        public static void activarDesactivar(ArrayList Aprod, Producto prod, ArrayList ListaCategorias, CategoriaProducto categoria)
        {
            int opcion = 0;
            int opcion2 = 2;
            int opcion3 = 2;
            bool banderaOpcion = true;
            int fila = 15;
            string nombrePAcambiar = "";
            string nombreClAcambiar = "";

            List<string> listaNombresP = new List<string>();    // lista para guardar los nombres de los productos
            List<string> listaNombresC = new List<string>();    // lista para guardar los nombres de las categorias

            // guardando los nombres de los productos en la lista

            foreach (Producto p in Aprod)
            {
                listaNombresP.Add(p.getNombre());
            }
            // guardando los nombres de las clases en la lista

            foreach (CategoriaProducto p in ListaCategorias)
            {
                listaNombresC.Add(p.getNombreCategoria());
            }

            limpia(1, 85, 8, 20);   // limpiando la pantalla

            Console.SetCursorPosition(28, 10); Console.Write("ACTIVAR O DESACTIVAR INVENTARIO");

            //Console.SetCursorPosition(15, 12); Console.Write("Menú: ");
            Console.SetCursorPosition(26, 13); Console.Write("1- Activar o desactivar producto");
            Console.SetCursorPosition(26, 14); Console.Write("2- Activar o desactivar categoria");

            // entrada de la opcion

            while (banderaOpcion)
            {
                try
                {
                    Console.SetCursorPosition(26, 17); Console.Write("Su opción..: ");
                    opcion = int.Parse(Console.ReadLine());

                    if (opcion > 2 || opcion < 1)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Error - Opcion no válida                 ");
                    }
                    else
                    {
                        banderaOpcion = false;
                    }

                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(20, 24); Console.Write(e.Message+ "               ");

                }
            }

            limpia(1, 80, 11, 20);

            // activar o desactivar producto

            if (opcion == 1)
            {
                // --------TABLA DE PRODUCTOS Y ESTADO----------

                // Encabezado
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(49, fila-2); Console.Write("     Nombre     |  Estado  ");
                Console.ResetColor();

                foreach (Producto p in Aprod)
                {
                    Console.SetCursorPosition(50, fila); Console.Write(p.getNombre());
                    Console.SetCursorPosition(67, fila); Console.Write(p.getActivo() ? "Activo": "Inactivo");
                    fila++;
                }
                Console.SetCursorPosition(49,fila); Console.Write("___________________________");

                //-----------FIN DE LA TABLA-------------

                // Recibiendo el nombre del producto

                while (!listaNombresP.Contains(nombrePAcambiar))
                {
                    Console.SetCursorPosition(4, 13); Console.Write("Nombre del producto...........: ");
                    nombrePAcambiar = Console.ReadLine();

                    if (!listaNombresP.Contains(nombrePAcambiar))
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Error - El nombre del producto especificado no existe en la lista                 ");
                    }

                }
                
                Console.SetCursorPosition(4, 15); Console.Write($"0- Cancelar");
                Console.SetCursorPosition(4, 16); Console.Write($"1- Cambiar estado");

                while (opcion2 > 1 || opcion2 < 0)
                {
                    Console.SetCursorPosition(4, 18); Console.Write("Su opción.........: ");
                    opcion2 = int.Parse(Console.ReadLine());

                    if (opcion2 > 1 || opcion2 < 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Error - opcion inexistente                 ");
                    }
                }

                // cambiando el valor

                if (opcion2 == 1)
                {
                    foreach (Producto p in Aprod)
                    {
                        if (p.getNombre() == nombrePAcambiar)
                        {
                            p.setActivo(!p.getActivo());

                            Console.SetCursorPosition(20, 24); Console.Write("Estado actualizado correctamente!                              ");

                        }
                    }
                }

            }

            //------------------------------------------
            // cambiar estado de la categoria completa
            //------------------------------------------

            else
            {

                // --------TABLA DE CATEGORIAS Y ESTADO----------

                // Encabezado
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(49, fila - 2); Console.Write("     Nombre     |  Estado  ");
                Console.ResetColor();

                foreach (CategoriaProducto p in ListaCategorias)
                {
                    Console.SetCursorPosition(50, fila); Console.Write(p.getNombreCategoria());
                    Console.SetCursorPosition(67, fila); Console.Write(p.getEstadoCategoria() ? "Activo" : "Inactivo");
                    fila++;
                }
                Console.SetCursorPosition(49, fila); Console.Write("___________________________");

                //-----------FIN DE LA TABLA-------------

                // Recibiendo el nombre de la categoria

                while (!listaNombresC.Contains(nombreClAcambiar))
                {
                    Console.SetCursorPosition(4, 13); Console.Write("Nombre de la clase...........: ");
                    nombreClAcambiar = Console.ReadLine();

                    if (!listaNombresC.Contains(nombreClAcambiar))
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Error - El nombre de la clase especificada no existe en la lista                 ");
                    }

                }

                Console.SetCursorPosition(4, 15); Console.Write($"0- Cancelar");
                Console.SetCursorPosition(4, 16); Console.Write($"1- Cambiar estado");

                while (opcion3 > 1 || opcion3 < 0)
                {
                    Console.SetCursorPosition(4, 18); Console.Write("Su opción.........: ");
                    opcion3 = int.Parse(Console.ReadLine());

                    if (opcion3 > 1 || opcion3 < 0)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write("Error - opcion inexistente                 ");
                    }
                }

                // cambiar el estado de todos los productos de esa clase
                if (opcion3 == 1)
                {
                    // obteniendo el id y estado de la categoria

                    string idCat = "";
                    bool estadoCat = true;

                    foreach (CategoriaProducto c in ListaCategorias)
                    {

                        if (c.getNombreCategoria() == nombreClAcambiar)
                        {
                            idCat = c.getIDCategoriaProducto();
                            estadoCat = !c.getEstadoCategoria();
                            c.setEstadoCategoria(estadoCat);
                        }
                    }

                    // cambiando el estado de todos los productos con el id de la categoria

                    foreach (Producto p in Aprod)
                    {
                        if(p.getIDCategoria() == idCat)
                        {
                            p.setActivo(estadoCat);
                            Console.SetCursorPosition(20, 24); Console.Write("Estado actualizado correctamente!                              ");

                        }
                    }
                }
            }

        }

        // método para mostrar categorias

        public static void ConsultarCategorias(ArrayList AProd, Producto prod, ArrayList ListaCategorias, CategoriaProducto categoria)
        {
            int fila = 13;
            int fila2 = 13;
            bool colorFIla = true;

            List<int> listaCantidadP = new List<int>(); // para almacenar lascantidades de productos de las categorias

            limpia(1, 79, 8, 20);

            Console.SetCursorPosition(28, 09); Console.Write("CATEGORIAS EN EL INVENTARIO");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(5, 11); Console.Write("  Nombre de la categoría  |IDCategoria|  Estado  | Num. de productos ");
            Console.ResetColor();


            // guardando la cantidad de productos por categoria

            foreach (CategoriaProducto c in ListaCategorias)
            {
                int contadorProds = 0;

                foreach (Producto p in AProd)
                {
                    if (c.getIDCategoriaProducto() == p.getIDCategoria())
                    {
                        contadorProds++;
                    }
                }

                listaCantidadP.Add(contadorProds);
            }

            // -------------TABLA DE CATEGORIAS----------------

            //-----Nombre cat-------------
            foreach (CategoriaProducto c in ListaCategorias)
            {   
                if (colorFIla)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }

                for (int x = 5; x < 74; x++)
                {
                    Console.SetCursorPosition(x, fila); Console.Write(" ");
                }

                Console.SetCursorPosition(6, fila); Console.Write(c.getNombreCategoria());
                Console.SetCursorPosition(35, fila); Console.Write(c.getIDCategoriaProducto());
                Console.SetCursorPosition(44, fila); Console.Write(c.getEstadoCategoria() ? "Activo": "Inactivo");
                
                fila++;
                Console.ResetColor();

                if (colorFIla)
                {
                    colorFIla = false;
                }
                else
                    colorFIla = true;
            }


            colorFIla = true;

            // ------Cantidad---------
            foreach (int c in listaCantidadP)
            {
                
                if (colorFIla)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.SetCursorPosition(64, fila2); Console.Write(c);
                fila2++;

                Console.ResetColor();

                if (colorFIla)
                {
                    colorFIla = false;
                }
                else
                    colorFIla = true;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            for (int x = 5; x< 74; x++)
            {
                Console.SetCursorPosition(x, fila2); Console.WriteLine("_");
            }
            Console.ResetColor();


        }

        //Método para cambiar el precio de los productos

        public static void cambiaPrecio(ArrayList AProd, Producto prod)
        {
            limpia(1, 79, 8, 20);

            string nombreP = "";
            bool banderaPrecio = true;
            int precio = 0;
            bool actOinac = true;


            ArrayList Nombres = new ArrayList();    // para guardar los nombres de los profuctos
            int fila = 14;

            Console.SetCursorPosition(30, 10); Console.Write("CAMBIAR PRECIO");

            Console.SetCursorPosition(5, 12); Console.Write("Lista de productos");



            // --------Tabla de productos----------------------
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(5, 12); Console.Write("   Nombre    |  Precio  ");
            Console.ResetColor();

            foreach (Producto p in AProd)
            {
                Nombres.Add(p.getNombre()); // guardando el nombre en la lista

                Console.SetCursorPosition(5, fila); Console.WriteLine(p.getNombre());
                Console.SetCursorPosition(20,fila); Console.WriteLine(p.getPrecio());
                fila++;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(5, fila); Console.Write("________________________");
            Console.ResetColor();

            //------------Fin de la tabla------------------------

            // Entrada del nombre al que desea cambiar el precio

            while (!Nombres.Contains(nombreP) || !actOinac)
            {
                Console.SetCursorPosition(43, 20); Console.Write("Presione 0 para salir");
                
                Console.SetCursorPosition(43, 13); Console.Write("Nombre del producto: ");
                nombreP = Console.ReadLine();


                if (nombreP == "0")
                {
                    break;
                }

                if (!Nombres.Contains(nombreP))
                {
                    Console.SetCursorPosition(20, 24); Console.Write("Error - El producto especificado no existe                       ");
                }

                // para ver si está activo


                foreach (Producto p in AProd)
                {
                    if (nombreP == p.getNombre())
                    {
                        actOinac = p.getActivo();
                    }
                }

                if (!actOinac)
                {
                    Console.SetCursorPosition(20, 24); Console.Write("* * * No se puede reducir stock a una línea descontinuada * * *                  ");
                }
            }


            // entrada del precio

            if (nombreP != "0")
            {

                while (banderaPrecio)
                {
                    try
                    {
                        Console.SetCursorPosition(43, 14); Console.Write("Nuevo precio...: ");
                        precio = int.Parse(Console.ReadLine());

                        if (precio < 0)
                        {
                            Console.SetCursorPosition(20, 24); Console.Write("Error - El precio no puede ser menor que 0                      ");
                        }
                        else
                        {
                            banderaPrecio = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.SetCursorPosition(20, 24); Console.Write(e.Message + "                             ");

                    }
                }

                // cambiando el precio
                
                foreach (Producto p in AProd)
                {
                    if (nombreP == p.getNombre())
                    {
                        p.setPrecio(precio);
                        Console.SetCursorPosition(20, 24); Console.Write("Precio actualizado correctamente                      ");
                
                    }
                }         
            }
        }

        //metodo limpia pantalla

        public static void limpia(int x1, int x2, int y1, int y2)
        {
            for (int x = x1; x <= x2; x++)
            {
                for (int y = y1; y <= y2; y++)
                {
                    Console.SetCursorPosition(x, y); Console.Write(" ");
                }
            }
        }   // fin del método limpia

    }   // fin de la clase program
}
