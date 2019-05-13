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
            bool isControlCapturedWhileSpin = false;
            for ( int i = 0; i < _spinCount; i++ )
            {
                if ( _waitHandler.WaitOne( 10 ) )
                {
                    isControlCapturedWhileSpin = true;
                    break;
                }
            }

            if ( !isControlCapturedWhileSpin )
            {
                Thread.Sleep( 10 ); // требование задания
                _waitHandler.WaitOne();
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

            var beginingTime = DateTime.UtcNow;
            var isControlCapturedWhileSpin = false;
            for ( int i = 0; i < _spinCount; i++ )
            {
                if ( _waitHandler.WaitOne( 10 ) )
                {
                    isControlCapturedWhileSpin = true;
                    break;
                }
                if ( beginingTime.AddMilliseconds( timeout ) <= DateTime.UtcNow )
                {
                    break;
                }
            }
            if ( isControlCapturedWhileSpin )
                return true;
            Thread.Sleep( 10 ); // требование задания

            double timeoutLeft = beginingTime.AddMilliseconds( timeout ).Subtract( DateTime.UtcNow ).TotalMilliseconds;
            if ( timeoutLeft <= 0 )
                return false;

            if ( _waitHandler.WaitOne( ( int )timeoutLeft ) )
                return true;

            return false;
        }

        public void Dispose()
        {
            _waitHandler.Dispose();
        }
    }
}
