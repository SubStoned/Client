using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public GameObject hand;
    [SerializeField] float asd = -6f;
   // Vector3 position;
    

    void Start()
    {
        hand = GameObject.Find("Empty");
        // position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // position = hand.transform.position;
        this.transform.position = new Vector3(hand.transform.position.x*(-0.4f), hand.transform.position.y * (0.4f), hand.transform.position.z*(-0.4f)) + new Vector3 (0f,0f,asd);
        this.transform.rotation = Quaternion.Euler(hand.transform.rotation.x , hand.transform.rotation.y , hand.transform.rotation.z );   
    }
}
