using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Lab3.CriticalSection;
using Lab3.Util;

namespace Lab3
{
    class Program
    {
        private const int ThreadsCount = 4;
        private static double _pi = 0;


        static void Main( string[] args )
        {
            if ( args.Length != 1 || args[ 0 ].AsInt() == null )
            {
                Console.WriteLine( "Run so: <program.exe> <stepsCount>" );
                return;
            }
            int stepsCount = args[ 0 ].AsInt().Value;

            ICriticalSection criticalSection = new AutoResetEventCriticalSection();
            Action enterToCriticalSectionAction = () => criticalSection.Enter();
            void leaveCriticalSectionAction() => criticalSection.Leave();

            Stopwatch watch = Stopwatch.StartNew();
            List<Thread> workers = BeginCalculatePi( stepsCount, enterToCriticalSectionAction, leaveCriticalSectionAction );
            foreach ( Thread worker in workers )
            {
                worker.Join();
            }
            watch.Stop();
            Console.WriteLine( $"Pi:{_pi} ms: {watch.ElapsedMilliseconds} enter to critical section type: Enter" );

            _pi = 0;
            enterToCriticalSectionAction = () =>
            {
                while ( !criticalSection.TryEnter( 10 ) )
                {
                }
            };
            watch = Stopwatch.StartNew();
            workers = BeginCalculatePi( stepsCount, enterToCriticalSectionAction, leaveCriticalSectionAction );
            foreach ( Thread worker in workers )
            {
                worker.Join();
            }
            watch.Stop();
            Console.WriteLine( $"Pi:{_pi} ms: {watch.ElapsedMilliseconds} enter to critical section type: TryEnter" );
        }


        private static List<Thread> BeginCalculatePi( int stepsCount, Action EnterToCriticalSection, Action LeaveCriticalSection )
        {
            var workers = new List<Thread>();

            int stepsCountPerThread = stepsCount / ThreadsCount;
            double step = 1.0 / stepsCount;
            for ( int i = 0; i < ThreadsCount; i++ )
            {
                var newThread = new Thread( CalculatePi );
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

        private static void CalculatePi( object piCalculatingSettingsObject )
        {
            var piCalculatingSettings = ( PiCalculatingSettings )piCalculatingSettingsObject;
            for ( long i = piCalculatingSettings.LeftBoundary; i < piCalculatingSettings.RightBoundary; i++ )
            {
                var x = ( i + 0.5 ) * piCalculatingSettings.Step;
                var functionBase = 4.0 / ( 1.0 + x * x );

                piCalculatingSettings.EnterToCriticalSection();
                _pi += functionBase * piCalculatingSettings.Step;
                piCalculatingSettings.LeaveCriticalSection();
            }
        }

        private class PiCalculatingSettings
        {
            public long LeftBoundary { get; set; }
            public long RightBoundary { get; set; }
            public double Step { get; set; }
            public Action EnterToCriticalSection;
            public Action LeaveCriticalSection;
        }

        private ProgramArguments ParseProgramArguments( string[] args )
        {
            var argumentsParser = new ArgumentsParser( args );

            if ( argumentsParser.NextArgumentsCount != 3 )
                return null;
            int? stepsCount = argumentsParser.GetNextAsInt();
            int? timeout = argumentsParser.GetNextAsInt();
            int? spinsCount = argumentsParser.GetNextAsInt();

            if ( stepsCount == null || timeout == null || spinsCount == null )
                return null;
        }
    }
}
