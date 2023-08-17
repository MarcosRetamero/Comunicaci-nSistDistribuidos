using System;
using System.Reflection.PortableExecutable;

namespace Project
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            ComunicationSystem cs = new ComunicationSystem();
            Machine m1 = new Machine();
            Machine m2 = new Machine();
            Message peticion = new Message();
            // aquí debes cargar el mensaje
            peticion.SetFlags("PETICION");
            Message respuesta = cs.Peticion(peticion, m1, m2);
        }
    }
}
