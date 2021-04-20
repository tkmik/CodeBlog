using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class TestClass : IDisposable
    {
        private bool disposed = false;
        public TestClass()
        {

        }

        ~TestClass()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // release managed resources
                }
                // release unmanaged resources
                disposed = true;
            }
        }
    }
}
