using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;
using UI.Buttons;

namespace UI
{
    public abstract class Window : MonoBehaviour, IInitialize
    {
        [HideInInspector]
        public UnityEvent EndShow, EndChange, EndHide;

        private CloseButton closeButton;

        public void OnInitialize()
        {
            closeButton = GetComponentInChildren(typeof(CloseButton), true) as CloseButton;

            if (closeButton != null)
            {
                closeButton.GetComponent<Button>().onClick.AddListener(Hide);
            }

            AfterInitialize();
        }

        protected virtual void AfterInitialize() { }
        public virtual void OnStart() { }

        public abstract void Show();
        public abstract void Hide();
        public virtual void Change() { }

        public virtual void ChangeLanguage() { }
    }
}