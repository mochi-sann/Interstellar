using System;
using UniRx;
using UnityEngine;

namespace Rocket
{
    public class RocketCollisionSender : MonoBehaviour
    {
        private readonly Subject<Collision2D> _triggerEnterSubject = new Subject<Collision2D>();
        private readonly Subject<Collision2D> _triggerStaySubject = new Subject<Collision2D>();
        
        public IObservable<Collision2D> TriggerEnterAsObservable => _triggerEnterSubject;
        public IObservable<Collision2D> TriggerStayAsObservable => _triggerStaySubject;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _triggerEnterSubject.OnNext(collision);
        }
        
        private void OnCollisionStay2D(Collision2D collision)
        {
            _triggerStaySubject.OnNext(collision);

        }
    }
}
