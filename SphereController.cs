using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public Transform sphereTransform;
    public static SphereController instance;
    public int compare = 0;

    private void Start()
    {
        instance = this;
    }
    void FixedUpdate()
    {

 
    }
}
