using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DestroyBehavior : MonoBehaviour
{
    public UnityEvent destroyEvent;
    public float seconds = 1;
    private WaitForSeconds wfsObj;
    IEnumerator Start()
    {
        wfsObj = new WaitForSeconds(seconds);
        yield return wfsObj;
        Destroy(gameObject);
        destroyEvent.Invoke();
    }
}
