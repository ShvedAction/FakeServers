using System;
using System.Net;
using System.Threading;

namespace FakeHttpServFakeServers.Httper
{
    public class HttpAsyncServer
    {
        private string[] listenedAddresses;       
        private HttpListener listener;
        public delegate void OnHttpServerReceived(HttpListenerContext context);
        private event OnHttpServerReceived OnReceived;

        public HttpAsyncServer(string[] listenedAddresses, OnHttpServerReceived onReceivedHandle)
        {
            this.listenedAddresses = listenedAddresses;            
            OnReceived = onReceivedHandle;
        }

        public void stop()
        {          
            if (IsStarted())
            {         
                listener.Stop();
                listener.Close();        
            }
        }


        public void RunServer()
        {
            if (IsStarted())
                throw new Exception("server alredy started");

            listener = new HttpListener();
            foreach (var prefix in listenedAddresses)
                listener.Prefixes.Add(prefix);

            listener.Start();            
            listener.BeginGetContext(GetContextCallback, listener);
        }

        private void GetContextCallback(IAsyncResult ar)
        {            
            if (IsStarted())
            {
                HttpListenerContext context = listener.EndGetContext(ar);
                OnReceived(context);
                listener.BeginGetContext(GetContextCallback, listener);
            }

        }

        private bool IsStarted()
        {
            return listener != null && listener.IsListening;
        }
    }
}
