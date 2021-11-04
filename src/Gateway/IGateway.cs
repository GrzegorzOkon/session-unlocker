namespace session_unlocker.src.Gateway
{
    public interface IGateway {
        string ExecuteCommand();

        void Close();
    }
}
