using System;
using UnityEngine;
using UniRx;
using VContainer.Unity;

public class PlayerMover : IInitializable
{
	private Rigidbody2D rigidbody;
	private IInputProvider inputProvider;
	private PlayerCollisionSender collisionSender;
	
	public float jumpPower { get; private set; } = 50;
	private int jumpCount = 2;
	public bool isGround { get; private set; } = true;

	private PlayerMover(IInputProvider inputProvider, PlayerCollisionSender collisionSender)
	{
		this.inputProvider = inputProvider;
		this.collisionSender = collisionSender;
		rigidbody = collisionSender.GetComponent<Rigidbody2D>();
		//TODO:collisionSenderからPlayer関連のコンポーネント取るのっておかしい気がする
	}

	public void Initialize()
	{
		inputProvider
			.StartDragAsObservable()
			.Zip(inputProvider.EndDragStreamAsObservable(), (startPos, endPos) => startPos - endPos)
			.WithLatestFrom(Observable.EveryFixedUpdate(), (diff, _) => diff * jumpPower)
			.Where(_ => jumpCount > 0)
			.Subscribe(force =>
			{
				rigidbody.AddForce(force);
				jumpCount--;
				isGround = false;
			});

		collisionSender
			.CollisionEnterAsObservable
			.Subscribe(collision => jumpCount = 2);
	}
}
