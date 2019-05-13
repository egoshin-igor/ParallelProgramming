using System;

namespace Lab3.PiCalculator
{
    public class PiCalculatingSettings
    {
        public long LeftBoundary { get; set; }
        public long RightBoundary { get; set; }
        public double Step { get; set; }
        public Action EnterToCriticalSection { get; set; }
        public Action LeaveCriticalSection { get; set; }
    }
}
