using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace Project
{
    public class ComunicationSystem
    {
        private static UdpClient DatagramSockSend;
        private static UdpClient DatagramSockReceive;
        private Timer time;

        public ComunicationSystem() { }

        public void Send(Message message, Machine machDestino)
        {
            try
            {
                IPEndPoint dir_remota = new IPEndPoint(machDestino.GetDirIPV4(), machDestino.GetPortSend());
                byte[] buffer = message.ToArrayByte();
                DatagramSockSend = new UdpClient();
                DatagramSockSend.Send(buffer, buffer.Length, dir_remota);
                DatagramSockSend.Close();
            }
            catch (Exception e)
            {
                // Manejo de excepciones
            }
        }

        public Message Receive(Machine machReceive)
        {
            Message msnRet = new Message();
            int longitdmensaje = 100;
            byte[] pkg_byte = new byte[1];
            try
            {
                byte[] buffer = new byte[longitdmensaje];
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, machReceive.GetPortReceive());
                DatagramSockReceive = new UdpClient(endPoint);
                buffer = DatagramSockReceive.Receive(ref endPoint);
                pkg_byte = new byte[buffer.Length];
                Array.Copy(buffer, pkg_byte, buffer.Length);
                msnRet = new Message(pkg_byte);
            }
            catch (Exception e)
            {
                // Manejo de excepciones
            }
            return msnRet;
        }

        public Message Peticion(Message peticion, Machine maquinacliente, Machine maquinaserver)
        {
            Message respuesta = new Message();
            try
            {
                this.Send(peticion, maquinaserver);
                Message ack = this.Receive(maquinacliente);
                if (ack.GetFlags() == "ACK")
                {
                    respuesta = this.Receive(maquinacliente);
                    Message confirmacionrespuesta = new Message();
                    confirmacionrespuesta.SetFlags("ACK");
                    this.Send(confirmacionrespuesta, maquinaserver);
                }
            }
            catch (Exception e)
            {
                // Manejo de excepciones
            }
            return respuesta;
        }

        public void Respuesta(Message respuesta, Machine maquinaserver, Machine maquinacliente)
        {
            try
            {
                Message peticion = this.Receive(maquinaserver);
                if (peticion.GetFlags() == "PETICION")
                {
                    Message ackpeticion = new Message();
                    this.Send(ackpeticion, maquinacliente);
                    this.Send(respuesta, maquinacliente);
                    Message ackrespuesta = this.Receive(maquinacliente);
                    if (ackrespuesta.GetFlags() == "ACK")
                    {
                        // Acciones después de recibir el ACK
                    }
                }
            }
            catch (Exception e)
            {
                // Manejo de excepciones
            }
        }
    }
}
