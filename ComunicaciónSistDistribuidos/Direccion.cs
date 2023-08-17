using System;
using System.Net;

namespace Project
{
    [Serializable]
    public class Direction
    {
        public static long serialVersionUID = 00000000;

        private IPAddress dirIPv4;
        private int portSend;
        private int portReceive;

        public Direction(string dirIPv4, int portSend, int portReceive)
        {
            try
            {
                this.dirIPv4 = IPAddress.Parse(dirIPv4);
                this.portSend = portSend;
                this.portReceive = portReceive;
            }
            catch (Exception e)
            {
                // Manejo de excepciones
            }
        }

        public IPAddress GetDirIPV4()
        {
            return this.dirIPv4;
        }

        public int GetPortSend()
        {
            return this.portSend;
        }

        public int GetPortReceive()
        {
            return this.portReceive;
        }
    }
}
