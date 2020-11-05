/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Threading;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    abstract class FantasticBeast
    {
        private String _msg;
        public String msg {get { return _msg; } set { _msg = value; } }
        private String _request, _response;
        public String request  { get { return _request; } set { _request = value; } }
        public String response { get { return _response; } set { _response = value; } }

        public virtual void SayHello() { Console.WriteLine("Hello from FantasticBeast.SayHello()"); }

        private Thread _thread;

        protected FantasticBeast() {
            _thread = new Thread(new ThreadStart(this.RunThread));
            msg = "";
            request = "";
            response = "";
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public Boolean Join(int waitMilliseconds) => _thread.Join(waitMilliseconds);
        public bool IsAlive => _thread.IsAlive;

        // Override in the derived class class
        public virtual void RunThread() {}
    }
}
