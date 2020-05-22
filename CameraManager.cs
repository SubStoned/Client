using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    bool run1 = true;
    bool run2 = true;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
     
        int player = GameObject.Find("LocalPlayer(Clone)").GetComponent<PlayerManager>().id;
        

        if (player == 2 && run2)
        {
            GameObject.Find("Camera1").SetActive(false);
            GameObject.Find("ImageTarget").SetActive(false);
            Debug.Log("working");
            run2 = false;
        }
        if (player == 1 && run1)
        {
            GameObject.Find("Camera2").SetActive(false);
            GameObject.Find("ImageTarget2").SetActive(false);
            run1 = false;
        }
     
    }
}
