using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageTest
{
    public class Smiec:IDisposable
    {
        static Smiec()
        {
            Console.WriteLine($"Smiec class created");
        }
        
        public Smiec()
        {
            Console.WriteLine($"Smiec {this.GetHashCode()} created");
            System.Diagnostics.Trace.WriteLine($"Smiec {this.GetHashCode()} created");
        }

        ~Smiec()
        {
            Console.WriteLine("Smiec is destroyed");
            System.Diagnostics.Trace.WriteLine("Smiec is destroyed");
            ReleaseUnmanagedResources();
        }

        private void ReleaseUnmanagedResources()
        {
            
        }

        public void Dispose()
        {
            //GC.SuppressFinalize(this);
            Console.WriteLine($"Smiec {this.GetHashCode()} is disposed");
            System.Diagnostics.Trace.WriteLine($"Smiec {this.GetHashCode()} is disposed");
            ReleaseUnmanagedResources();
            //GC.SuppressFinalize(this);
        }
    }
}
