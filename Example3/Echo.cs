using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Example3
{
  public class Echo : WebSocketBehavior
  {
    protected override void OnMessage (MessageEventArgs e)
    {
      Send (e.Data + "-server");
    }

        protected override void OnOpen()
        {
            Send("connect success!!!");
        }
    }
}
