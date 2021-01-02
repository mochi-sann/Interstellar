using System;
using UniRx;
using UnityEngine;

public class PlayerCollisionSender : MonoBehaviour
{
    private readonly Subject<Collision2D> collisionEnterSubject = new Subject<Collision2D>();
    public IObservable<Collision2D> CollisionEnterAsObservable => collisionEnterSubject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnterSubject.OnNext(collision);
    }
}