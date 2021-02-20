using System;
using UniRx;
using UnityEngine;

namespace Rocket
{
    public class RocketCollisionSender : MonoBehaviour
    {
        private Subject<Collision2D> _collisionEnterSubject = new Subject<Collision2D>();

        public IObservable<Collision2D> CollisionEnterAsObservable => _collisionEnterSubject;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _collisionEnterSubject.OnNext(collision);
        }
    }
}
