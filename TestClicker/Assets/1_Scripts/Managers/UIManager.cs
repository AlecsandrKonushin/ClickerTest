using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIManager : Singleton<UIManager>, IInitialize
    {
        private Dictionary<Type, Window> windows;

        #region INITIALIZE

        public void OnInitialize()
        {
            Window[] getWindows = GetComponentsInChildren<Window>();
            windows = new Dictionary<Type, Window>();

            foreach (var window in getWindows)
            {
                windows.Add(window.GetType(), window);
            }

            foreach (var window in windows)
            {
                window.Value.OnInitialize();
            }
        }

        public void OnStart()
        {
            foreach (var window in windows)
            {
                window.Value.OnStart();
            }
        }

        #endregion INITIALIZE

        #region GET/SHOW/HIDE

        public static T GetWindow<T>() where T : Window
        {
            if (Instance.windows.TryGetValue(typeof(T), out var window))
            {
                return window as T;
            }
            else
            {
                Debug.Log($"<color=red>Нет окна {typeof(T)}, для показа!");

                return null;
            }
        }

        public static void ShowWindow<T>() where T : Window
        {
            if(Instance.windows.TryGetValue(typeof(T) ,out var window))
            {
                window.Show();

            }
            else
            {
                Debug.Log($"<color=red>Нет окна {typeof(T)}, для показа!</color>");
            }
        }

        public static void HideWindow<T>() where T : Window
        {
            if (Instance.windows.TryGetValue(typeof(T), out var window))
            {
                window.Hide();
            }
            else
            {
                Debug.Log($"<color=red>Нет окна {typeof(T)}, для закрытия!");
            }
        }

        public static void ChangeLanguage()
        {
            foreach (var window in Instance.windows)
            {
                window.Value.ChangeLanguage();
            }
        }

        #endregion GET/SHOW/HIDE
    }
}