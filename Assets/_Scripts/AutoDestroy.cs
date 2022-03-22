using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    [Tooltip("Tiempo despues del cual se destruye el objeto")]
    public float destructionDelay;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("HideObject", destructionDelay);
        
        //Destroy(gameObject, destructionDelay);
    }

    void HideObject()
    {
        gameObject.SetActive(false);
    }
}
