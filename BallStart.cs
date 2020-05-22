using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallStart : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float xSpeedMax = 1f, ySpeedMax = 1f, zSpeedMax = 1f;
    [SerializeField] float xSpeedMin = 1f, ySpeedMin = 1f, zSpeedMin = 1f;
    GameObject tempo;
    GameObject tempo2;
    public bool isHit = false;
    public bool isHit2 = false;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = this.transform.position;
        // Ball Cannon
        Invoke("JumpStart()", 3);
    }

    private void JumpStart()
    {
        float xSpeed = Random.Range(xSpeedMin, xSpeedMax);
        float ySpeed = Random.Range(ySpeedMin, ySpeedMax);
        float zSpeed = Random.Range(zSpeedMin, zSpeedMax);
        rb.velocity = new Vector3(xSpeed, ySpeed, zSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {

        GameHasStarted();

        if (this.transform.position.z < -5f)
        {
            isHit = false;
            this.transform.position = startPos;
            JumpStart();
        }
        if (isHit)
        {
            this.rb.transform.position = tempo.transform.position + new Vector3(0f, 0.2f, 0.3f);
            // Invoke("Restart", 2.5f);
        }
        if (isHit2)
        {
            this.rb.transform.position = tempo2.transform.position + new Vector3(0f, 0.2f, -0.3f);
        }
        
  
    }
    private void OnTriggerEnter(Collider other)
    {
        this.rb.velocity = new Vector3(0f, 0f, 0f);
        this.rb.angularVelocity = Vector3.zero;

        if(other.tag == "1")
        {
            isHit = true;
        }
        else if (other.tag == "2")
        {
            isHit2 = true;
        }
    }
    void Restart()
    {
        //SceneManager.LoadScene(0);
        this.transform.position = startPos;
        isHit = false;
        JumpStart();
    }
    
    void GameHasStarted()
    {
        if (GameManager.players.ContainsKey(1) && GameManager.players.ContainsKey(2))
        {
            tempo = GameObject.Find("LocalPlayer(Clone)");
            tempo2 = GameObject.Find("Player(Clone)");
        }
    }
}
