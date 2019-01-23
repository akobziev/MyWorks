using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    class WevServer
    {
        private HttpListener _listener;
        private string _baseFolder;

        public WevServer(string prefixUrl, string baseFolder)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefixUrl);
            _baseFolder = baseFolder;
        }

        public async void Start()
        {
            _listener.Start();
            while (true)
            {
                HttpListenerContext context = await _listener.GetContextAsync();
                Task.Run(() => ProcessRequestAsync(context));
            }
        }

        public void Stop()
        {
            _listener.Stop();
        }

        private async void ProcessRequestAsync(HttpListenerContext context)
        {
            string fileName = Path.GetFileName(context.Request.RawUrl);
            string path = Path.Combine(_baseFolder, fileName);

            byte[] msg;
            if (!File.Exists(path))
            {
                Console.WriteLine("Resource not found");
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                msg = Encoding.UTF8.GetBytes("sorry, this file doesn't exist");
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                msg = File.ReadAllBytes(path);
            }

            context.Response.ContentLength64 = msg.Length;
            using (Stream s = context.Response.OutputStream)
            {
                await s.WriteAsync(msg, 0, msg.Length);
            }
        }
    }
}
