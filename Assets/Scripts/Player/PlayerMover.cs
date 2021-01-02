using UniRx;
using UnityEngine;
using VContainer.Unity;

public class PlayerMover : IInitializable
{
    private readonly PlayerCollisionSender collisionSender;
    private readonly IInputProvider inputProvider;
    private int jumpCount = 2;
    private readonly Rigidbody2D rigidbody;

    private PlayerMover(IInputProvider inputProvider, PlayerCollisionSender collisionSender)
    {
        this.inputProvider = inputProvider;
        this.collisionSender = collisionSender;
        rigidbody = collisionSender.GetComponent<Rigidbody2D>();
        //TODO:collisionSenderからPlayer関連のコンポーネント取るのっておかしい気がする
    }

    public float jumpPower { get; } = 50;
    public bool isGround { get; private set; } = true;

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