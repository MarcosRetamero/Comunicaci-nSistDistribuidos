using System;

namespace Project
{
    [Serializable]
    public class Message
    {
        public static long serialVersionUID = 00000000;
        private string origen;
        private string destino;
        private string portOirgen;
        private string portDestino;
        private string datos;
        private string flags; // "ACK", "OK"

        public Message() { }
        public Message(byte[] datos) { }

        public byte[] ToArrayByte()
        {
            string data = origen + destino + portDestino + portDestino + flags;
            return System.Text.Encoding.ASCII.GetBytes(data);
        }

        public Message ToMessage(byte[] datos)
        {
            // construir el mensaje a partir del array de bytes
            return this;
        }

        public string GetFlags()
        {
            return flags;
        }

        public void SetFlags(string tipomensaje)
        {
            flags = tipomensaje;
        }
    }
}
