using UnityEngine;
using UnityEngine.UI;


public class InteractIndicator : MonoBehaviour
{
    Image interactIcon;
    bool iconOn;
    bool overrideOff;

    void Start()
    {
        iconOn = false;
        overrideOff = false;
    }

    void Update()
    {
        if(iconOn)
        {
            if(Input.GetButtonDown("Grab"))
            {
                interactIcon.gameObject.SetActive(false);
                iconOn = false;
            }
        }
    }
     
	void OnTriggerEnter(Collider other)
    {
        if(!overrideOff)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                overrideOff = true;
                interactIcon.gameObject.SetActive(true);
                iconOn = true;
            }
        }
    }
}
