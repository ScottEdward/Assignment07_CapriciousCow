/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * 5463458053 * 3628273133 = 19822918066972390049
 * 18233  * 19541   = 356291053
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MultiThreadingWinFormsAppAsAGroupProject
{
    /// <summary>
    /// Exercise all the Fantastic Beast derived classes and see if they do what they should be doing
    /// </summary>
    class ClassProcessing
    {
        private static int timeoutSeconds = 5000;
        /// <summary>
        /// Exercise all the Fantastic Beast derived classes and see if they do what they should be doing
        /// </summary>
        /// <param name="txtMessages">A text box to write commentary in. Can't be null.</param>
        public static void ProcessClasses(TextBox txtMessages)
        {
            List<FantasticBeast> myBeasts = new List<FantasticBeast>();
            List<String> files = new List<string>();
            // Read the directory that contains all the FantasticBeast derived objects we will process
            foreach (string file in Directory.EnumerateFiles("..\\..\\FantasticBeasts", "*.cs")) {
                String s = file.Substring(file.LastIndexOf("\\") + 1);
                s = s.Substring(0, s.LastIndexOf(".cs"));
                files.Add(s);
            }
            FantasticBeast myFantasticBeast;
            // Attempt to span a thread for each FantasticBeast derived object.
            foreach (String s in files) {
                try {
                    myFantasticBeast = (FantasticBeast) (Activator.CreateInstance(null, "MultiThreadingWinFormsAppAsAGroupProject." + s).Unwrap());
                    myFantasticBeast.request = "356291053";
                    myBeasts.Add(myFantasticBeast);
                    myFantasticBeast.SayHello();
                    Spawn(myFantasticBeast, txtMessages);
                    txtMessages.AppendText(Environment.NewLine + s + " spawned");
                } catch (Exception ex) {
                   txtMessages.AppendText(Environment.NewLine + s + " did not spawn (" + ex.Message + ")");
                }
            }
            // All the beasts have been spawned. If any are running, wait for them to finish. Then get the computed response from the object.
            int passCount = 0, failCount = 0;
            foreach (FantasticBeast fb in myBeasts) {
                if (fb.IsAlive) {
                    Boolean joinStatus;
                    //Console.WriteLine("Waiting for thread to complete");
                    joinStatus = fb.Join(timeoutSeconds * 1000);
                    if (joinStatus == false) {
                        failCount++;
                        txtMessages.AppendText(Environment.NewLine + fb.GetType() + " thread timed out after " + timeoutSeconds + " seconds.");
                    } else {
                        if (GetResponse(fb, txtMessages) == true) { passCount++; } else { failCount++; }
                    }
                } else {
                    if (GetResponse(fb, txtMessages) == true) { passCount++; } else { failCount++; }
                }
            }
            String passCountPlural = passCount == 1 ? "" : "s";
            String failCountPlural = failCount == 1 ? "" : "s";

            txtMessages.AppendText(Environment.NewLine + passCount + " test" + passCountPlural + " passed and " + failCount +  " test" + failCountPlural + " failed");
            txtMessages.AppendText(Environment.NewLine + "****Done.****");
        }
        /// <summary>
        /// Get the computed response from the thread we spawned
        /// </summary>
        /// <param name="fb">The object that handled the thread and did the computing</param>
        /// <param name="txtMessages">A text box to write commentary into. Can't be null.</param>
        /// <returns></returns>
        private static Boolean GetResponse(FantasticBeast fb, TextBox txtMessages) {
            Boolean result = true;      // Hope for the best
            // The thread should have responded to our request so we can retrieve it.
            txtMessages.AppendText(Environment.NewLine + "Response from " + fb.GetType() + ": " + fb.response);
            if (fb.response.Trim() == "19541") {
                txtMessages.AppendText(": solution is correct");
            }
            else {
                txtMessages.AppendText(": solution IS NOT correct");
                result = false;
            }
            return result;
        }
        /// <summary>
        /// Get the message from the thread we spawned
        /// </summary>
        /// <param name="fb">The object that handled the thread and did the computing</param>
        /// <param name="txtMessages">A text box to write commentary into. Can't be null.</param>
        private static void GetMsg(FantasticBeast fb, TextBox txtMessages) {
            // The thread should have written a message so we can retrieve it.
            txtMessages.AppendText(Environment.NewLine + fb.msg);
        }
        /// <summary>
        /// Spawn the thread from the Fantastic Beast object
        /// </summary>
        /// <param name="fb">The object that will handle the thread.</param>
        /// <param name="txtMessages">A text box to write commentary into. Can't be null.</param>
        private static void Spawn(FantasticBeast fb, TextBox txtMessages) {
            txtMessages.AppendText(Environment.NewLine + "Spawning " + fb.GetType());
            fb.Start(); // This will invoke RunThread in the derived class
        }
    }
}
