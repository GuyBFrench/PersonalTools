using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerEventsBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, triggerEnterEvent, triggerEnterRepeatEvent, triggerEnterEndEvent, triggerExitEvent;
    public float delayTime = 0.01f;
    private WaitForSeconds waitObj;
    public bool canRepeat;
    public int repeatTimes = 10;

    private void Start()
    {
        startEvent.Invoke();
        waitObj = new WaitForSeconds(delayTime);
    }
     
    private IEnumerator OnTriggerEnter(Collider other)
    {
          
        triggerEnterEvent.Invoke();

        if (canRepeat)
        {
            var i = 0;
            while (i < repeatTimes)
            {
                yield return waitObj;
                i++;
                triggerEnterRepeatEvent.Invoke();
            }
        }
        yield return waitObj;
        triggerEnterEndEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent.Invoke();
    }
}