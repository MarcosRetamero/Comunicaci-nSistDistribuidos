using System;

namespace Project
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int puerto = 12345;
            ComunicationSystem cs = new ComunicationSystem();

            // Crear una instancia de Direction con la dirección IP y los puertos
            Direction dir1 = new Direction("172.30.4.55", puerto, puerto);
            Direction dir2 = new Direction("172.30.4.55", puerto, puerto);

            // Crear instancias de las máquinas utilizando la dirección configurada
            Machine m1 = new Machine(dir1);
            Machine m2 = new Machine(dir2);

            // Crear una instancia de Message para la petición
            Message peticion = new Message();
            peticion.SetFlags("PETICION");
            peticion.Datos = "Contenido de la petición";
            
            // Enviar la petición desde m1 a m2
            cs.Send(peticion, m2);

        }
    }
}
