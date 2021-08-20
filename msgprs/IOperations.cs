namespace msgprs
{
    internal interface IOperations
    {
        string Id { get; }

        void RunOptions(Options opts);
    }
}