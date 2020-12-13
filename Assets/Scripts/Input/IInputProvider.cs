using System;
using UnityEngine;

public interface IInputProvider
{
	IObservable<Vector2> StartDragAsObservable();
	IObservable<Vector2> EndDragStreamAsObservable();
	IObservable<Vector2> DragStreamAsObservable();
}
