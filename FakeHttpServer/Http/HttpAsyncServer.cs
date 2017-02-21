using System;
using System.Net;
using System.Threading;

namespace FakeHttpServFakeServers.Httper
{
    public class HttpAsyncServer
    {
        private string[] listenedAddresses;       
        private HttpListener listener;
        public delegate void OnHttpServerRecived(HttpListenerContext context);
        private event OnHttpServerRecived OnRecived;
        private Thread ReciverThread;

        public HttpAsyncServer(string[] listenedAddresses, OnHttpServerRecived onRecivedHandle)
        {
            this.listenedAddresses = listenedAddresses;            
            OnRecived = onRecivedHandle;
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
                OnRecived(context);
                listener.BeginGetContext(GetContextCallback, listener);
            }

        }

        private bool IsStarted()
        {
            return listener != null && listener.IsListening;
        }
    }
}
