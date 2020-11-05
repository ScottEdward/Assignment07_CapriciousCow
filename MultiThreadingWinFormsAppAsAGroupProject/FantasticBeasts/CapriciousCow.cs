/*****************************
 * Edward Scott
 * scottew@ucmail.uc.edu
 * MultiThreading GUI Group Project (GitHub)
 * Assignment 07
 * November 4, 2020
 * Notes: Wasn't sure of the exact coding for this. I hope it is correct. 
 *****************************/
using System;
using System.Threading;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    /// <summary>
    /// A Fantastic Beast that will help us maintain a secure world
    /// </summary>
    class CapriciousCow : FantasticBeast
    {
        public override void SayHello()
        {
            ///throw new NotImplementedException();
            Console.WriteLine("Hello from " + this.GetType());
        }
        public override void RunThread()
        {
            ///throw new NotImplementedException();
            msg = "Hello from CapriciousCow.RunThread()";
            Thread.Sleep(2000);
            long num = Convert.ToInt64(request);
            response = Convert.ToString(19541);
        }

    }
}
