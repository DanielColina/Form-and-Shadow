using UnityEngine;

public class ShadowmeldIndicator : MonoBehaviour
{
    GameObject shadowmeldIcon;
    bool turnedOff;

    void Start()
    {
        shadowmeldIcon = gameObject;
    }

    void Update()
    {
        if(!turnedOff)
            UpdateShadowmeldInput();
    }

    void UpdateShadowmeldInput()
    {
        if (Input.GetKey(KeyCode.F))
        {
            shadowmeldIcon.SetActive(false);
        }
    }
}