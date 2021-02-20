using System;
using UnityEngine;

public interface IInputProvider
{
    IObservable<Vector3> StartDragAsObservable();
    IObservable<Vector3> EndDragStreamAsObservable();
    IObservable<Vector3> DragStreamAsObservable();
}
