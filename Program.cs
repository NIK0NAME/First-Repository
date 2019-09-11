using System;
using System.IO;

namespace actividadFicheros {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Loading File . . .");
            Console.WriteLine();

            String path = "more.txt";

            if(!File.Exists(path)) {
                //Creamos el fichero
                FileStream f =  File.Create(path);   
                f.Close();
            }  

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fichero: " + path + " - " + File.GetCreationTime(path).ToString());
            Console.WriteLine();

            String linea;
            //Abrir fichero con StreamReader y leerlo

            Console.ForegroundColor = ConsoleColor.White;
            using (StreamReader st = File.OpenText(path)) {
                
                //Recorrer el fichero
                while(!st.EndOfStream) {

                    //Al leer un linea el cursor del fichero se posiciona en el siguiente
                    linea = st.ReadLine();
                    Console.WriteLine(linea);
                }

                Console.WriteLine();

                //Cerrar el stream
                st.Close();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Liena en blanco con '0' para salir ! ! !");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Empieza edicion - > ");
            

            String inpt;
            //Abrir fichero con StreamWriter y escribir en el
            Console.ForegroundColor = ConsoleColor.Blue;
            using (StreamWriter sw = File.AppendText(path)) {
                do {
                    inpt = Console.ReadLine();
                    if(inpt != "0") {
                        String fLine = "[" + DateTime.Today + "] - " + inpt;
                        sw.WriteLine(fLine);
                    }
                
                }while(inpt != "0");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Edicion finalizada - < ");
                Console.WriteLine();
                sw.Close();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

//dotnet --help
//dotnet new $plantilla_name
//dotnet run
//dotnet build
