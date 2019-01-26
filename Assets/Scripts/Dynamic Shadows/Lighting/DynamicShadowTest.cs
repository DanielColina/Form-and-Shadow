//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DynamicShadowTest : MonoBehaviour
//{

//    public GameObject[] spotlights;

//    private bool shifted = false;
//    private bool melded = false;

//    // Use this for initialization
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (!melded && Input.GetButtonDown("Shadowshift"))
//        {
//            if (!shifted)
//            {
//                foreach (GameObject light in spotlights)
//                {
//                    light.GetComponent<SpotlightShadow>().destroyColliders();
//                    light.GetComponent<SpotlightShadow>().createColliders = true;
//                    shifted = true;
//                }
//            }
//            else {
//                foreach (GameObject light in spotlights)
//                {
//                    light.GetComponent<SpotlightShadow>().destroyColliders();
//                    shifted = false;
//                }
//            }
//        }

//        if (!shifted && Input.GetButtonDown("Shadowmeld"))
//        {
//            if (!melded)
//            {
//                foreach (GameObject light in spotlights)
//                {
//                    light.GetComponent<SpotlightShadow>().destroyColliders();
//                    light.GetComponent<SpotlightShadow>().createMeld = true;
//                    melded = true;
//                }
//            }
//            else {
//                foreach (GameObject light in spotlights)
//                {
//                    light.GetComponent<SpotlightShadow>().destroyColliders();
//                    melded = false;
//                }
//            }
//        }
//    }
//}
