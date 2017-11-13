using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShadowshiftIndicator : MonoBehaviour
{
    GameObject cloakPickup;
    GameObject shadowShiftIcon;
    bool overrideOff;
    
	void Start ()
    {
        shadowShiftIcon = gameObject;
        cloakPickup = GameObject.Find("Collectible_Large (Cloak)");
        overrideOff = false;
	}

    void Update ()
    {
        if (!overrideOff)
        {
            if (cloakPickup.activeSelf == true)
            {
                shadowShiftIcon.GetComponent<Image>().enabled = false;
            }
            else if (cloakPickup.activeSelf == false)
            {
                shadowShiftIcon.GetComponent<Image>().enabled = true;
                StartCoroutine(ToggleOff());
            }
        }
    }

    IEnumerator ToggleOff()
    {
        yield return new WaitForSeconds(3f);
        shadowShiftIcon.GetComponent<Image>().enabled = false;
        overrideOff = true;
    }
}
