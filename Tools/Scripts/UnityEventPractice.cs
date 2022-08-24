using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventPractice : MonoBehaviour
{
    
    [SerializeField] public UnityEvent practiceEvent;

    private void OnTriggerEnter(Collider other)
    {
       // if (other.CompareTag("Enemy"))
        //{
        //    practiceEvent.Invoke();
       // }
    }

}
