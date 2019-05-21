using System;
using System.Threading;

namespace Lab3.CriticalSection
{
    class AutoResetEventCriticalSection : ICriticalSection, IDisposable
    {
        private int _spinCount = 1;
        private readonly AutoResetEvent _waitHandler = new AutoResetEvent( true );

        public void Enter()
        {
            while ( true )
            {
                for ( int i = 0; i < _spinCount; i++ )
                {
                    if ( _waitHandler.WaitOne( 10 ) )
                        return;
                }

                Thread.Sleep( 10 );
            }
        }

        public void Leave()
        {
            _waitHandler.Set();
        }

        public void SetSpinCount( int count )
        {
            if ( count < 1 )
                throw new ArgumentOutOfRangeException();

            _spinCount = count;
        }

        public bool TryEnter( int timeout )
        {
            if ( timeout < 0 )
                throw new ArgumentOutOfRangeException();

            var timeoutEndingTime = DateTime.UtcNow.AddMilliseconds( timeout );
            do
            {
                for ( int i = 0; i < _spinCount; i++ )
                {
                    if ( _waitHandler.WaitOne( 10 ) )
                        return true;
                    if ( timeoutEndingTime <= DateTime.UtcNow )
                        return false;
                }
                Thread.Sleep( 10 ); // требование задания
            } while ( timeoutEndingTime > DateTime.UtcNow );

            return false;
        }

        public void Dispose()
        {
            _waitHandler.Dispose();
        }
    }
}
