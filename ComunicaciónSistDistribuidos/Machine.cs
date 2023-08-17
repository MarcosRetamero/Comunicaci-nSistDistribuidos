using System;
using System.Net;

namespace Project
{
    public class Machine
    {
        private Direction dirIP;

        public Machine() { }
        public Machine(Direction dir)
        {
            this.dirIP = dir;
        }

        public void SetDirection(Direction dir)
        {
            this.dirIP = dir;
        }

        public void SetDirIPv4(Direction ip)
        {
            this.dirIP = ip;
        }

        public IPAddress GetDirIPV4()
        {
            return this.dirIP.GetDirIPV4();
        }

        public int GetPortReceive()
        {
            return this.dirIP.GetPortReceive();
        }

        public int GetPortSend()
        {
            return this.dirIP.GetPortSend();
        }

        public void SetTime(DateTime hora)
        {
            Message message = new Message();
            // ComunicationSystem.Send(message, this);    
        }

        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
