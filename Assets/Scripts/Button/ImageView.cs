using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageView : MonoBehaviour
{
    public GameObject panel;

    public void SetImageActive(bool isActive){
            this.GetComponent<Image>().enabled = isActive;
            foreach(Image image in this.GetComponentsInChildren<Image>()){
                image.enabled = isActive;
            }
            foreach(Text text in this.GetComponentsInChildren<Text>()){
                text.enabled = isActive;
            }
    }

    private void Update() {
        if(panel.active){
           SetImageActive(true); 
        }
        else{
            SetImageActive(false);
        }
    }
}
