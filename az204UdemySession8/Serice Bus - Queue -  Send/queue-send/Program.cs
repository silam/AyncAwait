﻿using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace queue_send
{
    class Program
    {

        private static string _bus_connectionstring = "Endpoint=sb://az204servicebussection8.servicebus.windows.net/;SharedAccessKeyName=sharedpolicy;SharedAccessKey=xajqbUngRhUvAKMglSjI8Pe3Dcehh/Ni12jB1NzG/O4=";
        private static string _queue_name = "az204queue";

        static async Task Main(string[] args)
        {
            IQueueClient _client;
            _client = new QueueClient(_bus_connectionstring, _queue_name);
            Console.WriteLine("Sending Messages");
            for (int i = 1; i <=10; i++)
            {
                Order obj = new Order();
                var _message = new Message();
                _message.MessageId = obj.Id;
                _message.UserProperties.Add("Quantity", obj.quantity);
                await _client.SendAsync(_message);
                Console.WriteLine($"Sending Message : {obj.Id} ");
            }    
        }
        }
}
