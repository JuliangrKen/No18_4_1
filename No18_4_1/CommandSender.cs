namespace No18_4_1
{
    internal class CommandSender
    {
        public event Action? Started;
        public event Action? Completed;

        private ICommand? command;

        public void Execute()
        {
            Started?.Invoke();
            command?.Execute();
            Completed?.Invoke();
        }

        public void SetCommand(ICommand command) =>
            this.command = command;

        public void ClearEvents()
        {
            Started = null;
            Completed = null;
        }
    }
}