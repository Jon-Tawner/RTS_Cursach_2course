using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activeImage : MonoBehaviour
{
    public void SetActiveImage(bool isActive)
    {
        this.GetComponent<Image>().enabled = isActive;
        foreach (Image i in gameObject.GetComponentsInChildren<Image>())
        {
            i.enabled = isActive;
        }
        foreach (Text i in gameObject.GetComponentsInChildren<Text>())
        {
            i.enabled = isActive;
        }
    }
}
