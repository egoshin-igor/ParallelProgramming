namespace Lab3.CriticalSection
{
    interface ICriticalSection
    {
        void Enter();
        bool TryEnter( int timeout );
        void SetSpinCount( int count );
        void Leave();
    }
}
