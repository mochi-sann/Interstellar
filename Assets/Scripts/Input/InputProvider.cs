using System;
using System.Runtime.CompilerServices;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Input
{
    public class InputProvider : MonoBehaviour, IInputProvider
    {
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public IObservable<Vector3> StartDragAsObservable()
        {
            return this.UpdateAsObservable()
                .Where(_ => UnityEngine.Input.GetMouseButtonDown(0))
                .Select(_ => _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition));
        }

        public IObservable<Vector3> EndDragStreamAsObservable()
        {
            return this.UpdateAsObservable()
                .Where(_ => UnityEngine.Input.GetMouseButtonUp(0))
                .Select(_ => _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition));
        }

        public IObservable<Vector3> DragStreamAsObservable()
        {
            return this.UpdateAsObservable()
                .Where(_ => UnityEngine.Input.GetMouseButton(0))
                .Select(_ => _mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition))
                .SkipUntil(StartDragAsObservable())
                .TakeUntil(EndDragStreamAsObservable())
                .Repeat();
        }
    }
}
