using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Jobs
{
    static class NativeJob
    {
        [DllImport("kernel32")]
        public static extern IntPtr CreateJobObject(IntPtr sa, string name);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AssignProcessToJobObject(IntPtr hjob, IntPtr hprocess);

        [DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr h);

        [DllImport("kernel32")]
        public static extern bool TerminateJobObject(IntPtr hjob, uint code);
    }

    public class Job : IDisposable
    {
        private readonly IntPtr _hJob;
        private readonly List<Process> _processes;
        private readonly long _sizeInByte;

        public Job(string name, long size)
        {
            _sizeInByte = size;
            _hJob = NativeJob.CreateJobObject(IntPtr.Zero, name);
            
            if (_hJob == IntPtr.Zero)
            {
                throw new InvalidOperationException();
            }
            _processes = new List<Process>();
            GC.AddMemoryPressure(_sizeInByte);
            Console.WriteLine("job was created");
            Console.WriteLine($"Memory: {GC.GetTotalMemory(false)}");

        }
        ~Job()
        {
            GC.RemoveMemoryPressure(_sizeInByte);
            Console.WriteLine("Job was released.");
            Console.WriteLine("Memory: " + GC.GetTotalMemory(false));
            Dispose(false);
        }

        public Job()
            : this(null, 0)
        {
        }
        public Job(long size)
            : this(null, size)
        {
        }

        public Job(string name)
            : this(name, 0)
        {
        }

        protected void AddProcessToJob(IntPtr hProcess)
        {
            CheckIfDisposed();

            if (!NativeJob.AssignProcessToJobObject(_hJob, hProcess))
                throw new InvalidOperationException("Failed to add process to job");
        }

        private void CheckIfDisposed()
        {
            if (disposedValue)
                throw new ObjectDisposedException("Failed dispose to job!!");
        }

        public void AddProcessToJob(int pid)
        {
            AddProcessToJob(Process.GetProcessById(pid));
        }

        public void AddProcessToJob(Process proc)
        {
            Debug.Assert(proc != null);
            AddProcessToJob(proc.Handle);
            _processes.Add(proc);
        }

        public void Kill()
        {
            NativeJob.TerminateJobObject(_hJob, 0);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            CheckIfDisposed();
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var process in _processes)
                    {
                        process.Dispose();
                    }   
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                NativeJob.CloseHandle(_hJob);
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        //~Job()
        //{
        //    // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //    Dispose(false);
        //}

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
