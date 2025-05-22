

using myconsoleapp.Helpers;

namespace InventoryManagementSystem
{
    public class ErrorHandler
    {
        public virtual void Handle(Exception ex)
        {
            Logger.LogError(ex);
        }
    }

    public class FileErrorHandler : ErrorHandler
    {
        public override void Handle(Exception ex)
        {
            Logger.LogError($"[File Error] {ex.Message}");
        }
    }
}
