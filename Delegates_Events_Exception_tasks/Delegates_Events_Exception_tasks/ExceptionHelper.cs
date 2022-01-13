using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates_Events_Exception_tasks
{
    public static class ExceptionHelper
    {
        public static void CheckBoolExpression<T>(bool condition, string message = "Exception catched") where T : Exception
        {
            if (condition)
                throw (T)Activator.CreateInstance(typeof(T), message);
        }
    }
}
