using System;
using System.Diagnostics;
using Lab3.PiCalculator;
using Lab3.PiCalculator.Types;
using Lab3.Util;

namespace Lab3
{
    class Program
    {
        static void Main( string[] args )
        {
            ProgramArguments programArguments = ParseProgramArguments( args );
            if ( programArguments == null )
            {
                Console.WriteLine( "Run so: <program.exe> <stepsCount> <timeout> <spinsCount>" );
                return;
            }

            IPiCalculator piCalculator = GetInitedPiCalculator( programArguments, EnterToCriticalSectionType.Enter );
            Stopwatch watch = Stopwatch.StartNew();
            double pi = piCalculator.CalculatePi();
            watch.Stop();
            Console.WriteLine( $"Pi:{pi}, ms: {watch.ElapsedMilliseconds}, enter to critical section type: Enter" );

            piCalculator = GetInitedPiCalculator( programArguments, EnterToCriticalSectionType.TryEnter );
            watch = Stopwatch.StartNew();
            pi = piCalculator.CalculatePi();
            watch.Stop();
            Console.WriteLine( $"Pi:{pi}, ms: {watch.ElapsedMilliseconds}, enter to critical section type: TryEnter" );
        }

        private static IPiCalculator GetInitedPiCalculator( ProgramArguments programArguments, EnterToCriticalSectionType enterToCSType )
        {
            return new MultiThreadPiCalculator(
                programArguments.StepsCount,
                programArguments.Timeout,
                programArguments.SpinsCount,
                EnterToCriticalSectionType.Enter );
        }

        private static ProgramArguments ParseProgramArguments( string[] args )
        {
            var argumentsParser = new ArgumentsParser( args );

            if ( argumentsParser.NextArgumentsCount != 3 )
                return null;

            int? stepsCount = argumentsParser.GetNextAsInt();
            int? timeout = argumentsParser.GetNextAsInt();
            int? spinsCount = argumentsParser.GetNextAsInt();

            if ( stepsCount == null || timeout == null || spinsCount == null )
                return null;

            return new ProgramArguments
            {
                StepsCount = stepsCount.Value,
                Timeout = timeout.Value,
                SpinsCount = spinsCount.Value
            };
        }
    }
}
