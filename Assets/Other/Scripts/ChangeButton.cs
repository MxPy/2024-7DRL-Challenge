using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButton : MonoBehaviour
{
    public Sprite hoverSprite;
    private Sprite defaultSprite; 

    private Image buttonImage;
    // Start is called before the first frame update
    void Start(){
        buttonImage = GetComponent<Image>();
        defaultSprite = buttonImage.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData){
        if (hoverSprite != null)
        {
            buttonImage.sprite = hoverSprite;
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        buttonImage.sprite = defaultSprite;
    }
}
