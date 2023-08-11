using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Example3
{
    
    public class Test
    {
        public List<object> series{ get; set; }
    }
    public class Echo : WebSocketBehavior
    {
        System.Threading.Timer timer;
        protected override void OnMessage (MessageEventArgs e)
        {
            if (e.Data == "start")
            {
                timer = new System.Threading.Timer(new TimerCallback(SendData), this, 0, 1000);//创建定时器
            }
        }
        private void SendData(object obj)
        {
            var t = new Test();
            Random ran = new Random();
            t.series = new List<object> { new { data = new List<int> { ran.Next(100, 1000), ran.Next(100, 1000), ran.Next(100, 1000), ran.Next(100, 1000), ran.Next(100, 1000), ran.Next(100, 1000) } } };
            var str_data = JsonSerializer.Serialize(t);
            Send(str_data);
        }
        protected override void OnOpen()
        {
            Send("connect success!!!");
        }
    }

}
