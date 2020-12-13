using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class InputProvider : MonoBehaviour, IInputProvider
{
	private Camera mainCamera;
	private void Awake()
	{
		mainCamera = Camera.main;
	}

	public IObservable<Vector2> StartDragAsObservable()
	{
		return this.UpdateAsObservable()
			.Where(_ => Input.GetMouseButtonDown(0))
			.Select(_ => (Vector2) mainCamera.ScreenToWorldPoint(Input.mousePosition));
	}
	
	public IObservable<Vector2> EndDragStreamAsObservable()
	{
		return this.UpdateAsObservable()
			.Where(_ => Input.GetMouseButtonUp(0))
			.Select(_ => (Vector2) mainCamera.ScreenToWorldPoint(Input.mousePosition));
	}

	public IObservable<Vector2> DragStreamAsObservable()
	{
		return this.UpdateAsObservable()
			.Where(_ => Input.GetMouseButton(0))
			.Select(_ => (Vector2) mainCamera.ScreenToWorldPoint(Input.mousePosition))
			.SkipUntil(StartDragAsObservable())
			.TakeUntil(EndDragStreamAsObservable())
			.DistinctUntilChanged()
			.Repeat();
		;
	}
}
