using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageBehaviour : MonoBehaviour
{
    public UnityEvent startEvent;
    public Image img;
    void Start()
    {
        img = GetComponent<Image>();
        startEvent.Invoke();
    }

    public void UpdateImage(FloatData1 obj)
    {
        img.fillAmount = obj.value;
    }
    
}
