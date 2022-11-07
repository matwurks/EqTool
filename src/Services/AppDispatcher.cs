﻿using System;
using System.Threading;

namespace EQTool.Services
{
    public interface IAppDispatcher
    {
        void DispatchUI(Action action);
    }

    public class FakeAppDispatcher : IAppDispatcher
    {
        public void DispatchUI(Action action)
        {
            action();
        }
    }

    public class AppDispatcher : IAppDispatcher
    {
        public void DispatchUI(Action action)
        {
            if (Thread.CurrentThread == App.Current.Dispatcher.Thread)
            {
                action();
            }
            else
            {
                App.Current.Dispatcher.Invoke(action);
            }
        }
    }
}