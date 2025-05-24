using System.Runtime.InteropServices.Marshalling;
using myconsoleapp.Helpers;

namespace InventoryManagementSystem
{
    public class ErrorHandler
    {
        protected static int exception_count = 0;

        public virtual void Handle(Exception ex)
        {
            Logger.LogError(ex);
            exception_count++;
        }
    }

public class FileErrorHandler : ErrorHandler
{
        public override void Handle(Exception ex)
        {
            base.Handle(ex);
            Logger.LogError($"errors_count");
            Logger.LogError($"exception_count{exception_count}");
    }
}

}
