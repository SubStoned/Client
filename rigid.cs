using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigid : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.position.Set(this.transform.position.x, 0.0f, this.transform.position.z);
    }
}
