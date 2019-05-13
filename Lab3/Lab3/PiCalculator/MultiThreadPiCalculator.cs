
using System;
using System.Collections.Generic;
using System.Threading;
using Lab3.CriticalSection;
using Lab3.PiCalculator.Types;

namespace Lab3.PiCalculator
{
    class MultiThreadPiCalculator : IPiCalculator
    {
        private const int ThreadsCount = 4;

        private static double _pi = 0;

        private readonly int _stepsCount;
        private readonly int _timeout;
        private readonly EnterToCriticalSectionType _enterToCriticalSectionType;
        private readonly ICriticalSection _criticalSection;

        public MultiThreadPiCalculator(
            int stepsCount,
            int timeout,
            int spinsCount,
            EnterToCriticalSectionType enterToCriticalSectionType )
        {
            _stepsCount = stepsCount;
            _timeout = timeout;
            _enterToCriticalSectionType = enterToCriticalSectionType;
            _criticalSection = new AutoResetEventCriticalSection();
            _criticalSection.SetSpinCount( spinsCount );
        }

        public double CalculatePi()
        {
            _pi = 0;
            Action enterToCriticalSectionAction;
            void leaveCriticalSectionAction() => _criticalSection.Leave();
            if ( _enterToCriticalSectionType == EnterToCriticalSectionType.Enter )
            {
                enterToCriticalSectionAction = () => _criticalSection.Enter();
            }
            else
            {
                enterToCriticalSectionAction = () => { while ( !_criticalSection.TryEnter( _timeout ) ) { } };
            }

            List<Thread> workers = BeginCalculatePi( _stepsCount, enterToCriticalSectionAction, leaveCriticalSectionAction );
            foreach ( Thread worker in workers )
            {
                worker.Join();
            }

            return _pi;
        }

        private List<Thread> BeginCalculatePi( int stepsCount, Action EnterToCriticalSection, Action LeaveCriticalSection )
        {
            var workers = new List<Thread>();

            int stepsCountPerThread = stepsCount / ThreadsCount;
            double step = 1.0 / stepsCount;
            for ( int i = 0; i < ThreadsCount; i++ )
            {
                var newThread = new Thread( CalculatePartOfPi );
                newThread.Start( new PiCalculatingSettings
                {
                    LeftBoundary = i * stepsCountPerThread,
                    RightBoundary = ( i + 1 ) * stepsCountPerThread,
                    Step = step,
                    EnterToCriticalSection = EnterToCriticalSection,
                    LeaveCriticalSection = LeaveCriticalSection
                } );

                workers.Add( newThread );
            }

            return workers;
        }

        private static void CalculatePartOfPi( object piCalculatingSettingsObject )
        {
            var piCalculatingSettings = ( PiCalculatingSettings )piCalculatingSettingsObject;
            for ( long i = piCalculatingSettings.LeftBoundary; i < piCalculatingSettings.RightBoundary; i++ )
            {
                double x = ( i + 0.5 ) * piCalculatingSettings.Step;
                double functionBase = 4.0 / ( 1.0 + x * x );

                piCalculatingSettings.EnterToCriticalSection();
                _pi += functionBase * piCalculatingSettings.Step;
                piCalculatingSettings.LeaveCriticalSection();
            }
        }
    }
}
