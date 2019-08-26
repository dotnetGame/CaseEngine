using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CaseEngine.Utility
{
    public class NativeArray<T> : IDisposable
    {
        private IntPtr _buffer;
        private int _length;
        private int _byteCount;
        private int _elementSize;
        private bool disposed;

        public NativeArray(int length)
        {
            _buffer = IntPtr.Zero;
            _length = 0;
            _byteCount = 0;
            _elementSize = 0;
            disposed = false;

            _elementSize = Marshal.SizeOf(typeof(T));
            if (_elementSize > 4)
                _elementSize = (_elementSize / 4 + 1) * 4;

            _byteCount = _elementSize * length;
            _buffer = Marshal.AllocHGlobal(_byteCount);
            if (_buffer == null)
                throw new OutOfMemoryException("Native Array oom");
            _length = length;

        }

        ~NativeArray()
        {
            Dispose();
        }


        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            IntPtr ptr = _buffer;

            if (ptr != IntPtr.Zero)
            {
                _length = 0;
                _buffer = IntPtr.Zero;
                Marshal.FreeHGlobal(ptr);
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        //public T this[int key]
        //{
        //    get =>
        //    {
        //        if (key < 0 || key >= _length)
        //            throw new IndexOutOfRangeException("Native Array Index Out Of Range.");
        //        var keyPtr = _buffer + _elementSize * key;
        //        unsafe
        //        {

        //        }
        //    };
        //    set => SetValue(key, value);
        //}
    }
}
