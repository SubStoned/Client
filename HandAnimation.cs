using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    bool ballInHand = false;

    Animator anim;
    //AnimationState ani;
    Animation ani;
    Rigidbody rb;
    float velocityZCurrent = 0f;
    float velocityZPrevious = 0f;
    [SerializeField] float backThreshold = 5f;
    [SerializeField] float forwardThreshold = 5f;
    bool throwing = false;
    bool prehod = false;
    Vector3 previous = Vector3.zero;
    Vector3 speed = Vector3.zero;
    //float previous;
    //float current;
    //float velocity;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ani = GetComponent<Animation>();
        //ani = GetComponent<AnimationState>();
        rb = GetComponent<Rigidbody>();
    }
    /*GetVelocity(float waitTime)
    {
        previous = transform.position.z;
        yield return new WaitForEndOfFrame(waitTime);
        current = transform.position.z;
        velocity = Mathf.Abs(current - previous);
    }*/
    // Update is called once per frame
    void Update()
    {
        ballInHand = GameObject.Find("Sphere").GetComponent<BallStart>().isHit;
 


        Catch();

        TestThrow();
    }

    private void LateUpdate()
    {
        zMovement();
        ThrowCoordinates();
    }

    private void ThrowCoordinates()
    {
        speed = (this.transform.position - previous) / Time.deltaTime;
        previous = this.transform.position;
    }

    private void TestThrow()
    {
        if ((velocityZCurrent > forwardThreshold) && prehod)
        {
            GameObject.Find("Sphere").GetComponent<BallStart>().isHit = false;
            GameObject.Find("Sphere").GetComponent<Rigidbody>().velocity = speed;
            // GameObject.Find("Sphere").GetComponent<Rigidbody>().angularVelocity = rb.angularVelocity;
            GameObject.Find("Sphere").GetComponent<Rigidbody>().angularVelocity = new Vector3(UnityEngine.Random.Range(-30f, 30f), UnityEngine.Random.Range(-30f, 30f), UnityEngine.Random.Range(-30f, 30f));

            rb.velocity = Vector3.zero;
        }
    }
 /*   private void TestThrow()
    {
        if (rb.velocity.z > 15f)
        {
            GameObject.Find("Sphere").GetComponent<BallStart>().isHit = false;
            GameObject.Find("Sphere").GetComponent<Rigidbody>().velocity = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), rb.velocity.z);
            // GameObject.Find("Sphere").GetComponent<Rigidbody>().angularVelocity = rb.angularVelocity;
            GameObject.Find("Sphere").GetComponent<Rigidbody>().angularVelocity = new Vector3(UnityEngine.Random.Range(-30f, 30f), UnityEngine.Random.Range(-30f, 30f), UnityEngine.Random.Range(-30f, 30f));

            rb.velocity = Vector3.zero;
        }
    }
*/
    private void zMovement()
    {
        velocityZCurrent = (this.transform.position.z - velocityZPrevious) / Time.deltaTime;
        velocityZPrevious = this.transform.position.z;

    }

    private void Catch()
    {
       //print(ani.normalizedTime);
        if (ballInHand && !throwing)
        {
            print("IT WORK");
            anim.Play("Armature|Catch");
        }
        else if (!ballInHand && anim.GetCurrentAnimatorStateInfo(0).IsTag("1"))
        {
           // if(anim.GetCurrentAnimatorStateInfo()
            anim.CrossFade("default", 1);
            throwing = false;
            prehod = false;
        }
        if ((velocityZCurrent < -forwardThreshold) && ballInHand)
        {
            anim.Play("Armature|Rotation");
            throwing = true;
            prehod = true;
        }
        else if ((velocityZCurrent > forwardThreshold)  && prehod)
        {
            anim.Play("Armature|Throw");
            throwing = true;
        }
    }

}

