using System;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace Ping_Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRight = false;
            do
            {
                Console.WriteLine("What do you want to send? Write Ping or Pong.");
                string answer = Console.ReadLine();
                if (answer == "Ping")
                {
                    isRight = true;
                    Ping ping1 = new Ping();
                    ping1.Notification += DisplayMessage;
                    ping1.PingSend();
                    Pong pong2 = new Pong();
                    pong2.Notification += DisplayMessage;
                    pong2.PingReceive();
                    bool WrongEnter = false;
                    do
                    {
                        Console.WriteLine("Do you want to send new Ping or Pong? Write Yes or No");
                        string answer2 = Console.ReadLine();
                        if (answer2 == "Yes")
                        {
                            isRight = false;
                            WrongEnter = true;
                        }
                        else if (answer2 == "No")
                        {
                            isRight = true;
                            WrongEnter = true;
                        }
                        else
                        {
                            WrongEnter = false;
                            Console.WriteLine("Try again.");
                        }
                    }
                    while (WrongEnter == false);
                }
                else if (answer == "Pong")
                {
                    isRight = true;
                    Pong pong1 = new Pong();
                    pong1.Notification += DisplayMessage;
                    pong1.PongSend();
                    Ping ping2 = new Ping();
                    ping2.Notification += DisplayMessage;
                    ping2.PongReceive();
                    bool WrongEnter = false;
                    do
                    {
                        Console.WriteLine("Do you want to send new Ping or Pong? Write Yes or No");
                        string answer2 = Console.ReadLine();
                        if (answer2 == "Yes")
                        {
                            isRight = false;
                            WrongEnter = true;
                        }
                        else if (answer2 == "No")
                        {
                            isRight = true;
                            WrongEnter = true;
                        }
                        else
                        {
                            WrongEnter = false;
                            Console.WriteLine("Try again.");
                        }
                    }
                    while (WrongEnter == false);
                }
                else
                {
                    isRight = false;
                    Console.WriteLine("Try again.");
                }
            }
            while (isRight == false);
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Pong
    {
        public delegate void PongHandler(string message);
        public event PongHandler Notification;
        public Pong()
        {        
        }
       
        public void PingReceive()
        {
            Notification?.Invoke("Pong received Ping.");
        }
        public void PongSend()
        {   
            
            Notification?.Invoke("Pong sent.");
        }
    }
    class Ping
    {
        public delegate void PingHandler(string message);
        public event PingHandler Notification;
        public Ping()
        {
        }
        public void PongReceive()
        {
           
            Notification?.Invoke("Ping received Pong");
        }
        public void PingSend()
        {
            Notification?.Invoke("Ping sent.");
        }
    }
}
