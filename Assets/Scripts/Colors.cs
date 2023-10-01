using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    [SerializeField] private GameObject OutsideAreasContainer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(this.CompareTag("Red"))
        {
            if (other.CompareTag("Blue"))
            {
                LevelEndChecker.haram = true;
                Destroy(other.transform.parent.gameObject);
            }
            if (other.CompareTag("Green"))
            {
                Color colorPink;
                ColorUtility.TryParseHtmlString("#FF69F3",out colorPink);
                other.transform.parent.gameObject.GetComponent<SpriteRenderer>().color=colorPink;
                other.transform.gameObject.tag = "Red";
            }
        }
        else if (this.CompareTag("Blue"))
        {
            if (other.CompareTag("Green"))
            {
                if(IsGreenOutside(other)==true)
                {
                    LevelEndChecker.haram = true;
                }
                other.transform.gameObject.tag = "Violet";
                other.transform.parent.gameObject.GetComponent<SpriteRenderer>().color=Color.cyan;
                Destroy(other.transform.parent.gameObject.GetComponent<Rigidbody2D>());
            }
        }
    }

    private bool IsGreenOutside(Collider2D GreenCollider)
    {
        foreach (Transform child in OutsideAreasContainer.transform)
        {
            Collider2D childCollider = child.GetComponent<Collider2D>();
            if (childCollider.IsTouching(GreenCollider)) 
            {
                return true;
            }
        }
        return false;
    }
}
