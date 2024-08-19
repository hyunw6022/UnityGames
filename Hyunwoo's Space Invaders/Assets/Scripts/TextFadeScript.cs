using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeScript : MonoBehaviour
{
    public Text titleText, anyKeyText, scrollingText;
    public GameObject anyKey;
    public float fadeTime;

    void Start()
    {
        Time.timeScale = 1;
        titleText.canvasRenderer.SetAlpha(0.0f);
        anyKeyText.canvasRenderer.SetAlpha(0.0f);
        scrollingText.canvasRenderer.SetAlpha(0.0f);
        scrollingText.text = "In 2054 BC, Humanity was purged from Unknown entities known as Angels. Due to this, over 50% of humanity died from these Angels. However, during this purge, the goverment who was near annihilation create one machine to end these Angels. That machine is you.  AKM-001 a.k.a. Codename: Bael.";

        scrollingText.CrossFadeAlpha(1.0f, fadeTime, true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag =="Reset")
        {
            titleText.CrossFadeAlpha(1.0f, fadeTime, true);
            anyKeyText.CrossFadeAlpha(1.0f, fadeTime, true);
            scrollingText.CrossFadeAlpha(0.0f, fadeTime, true);
            anyKey.SetActive(true);
        }
    }
}
