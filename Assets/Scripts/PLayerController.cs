using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D myRB;
    [SerializeField]
    Vector2 movement;
    [Header("Player Settings")]
    [SerializeField]
    float pSpeed;
    [SerializeField]
    float jSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

        if (pSpeed == 0)
            pSpeed = 10;
        if (jSpeed == 0)
            jSpeed = 50;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRB.AddForce(Vector2.up * jSpeed);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        myRB.MovePosition(myRB.position + movement * pSpeed * Time.deltaTime);

        AnimateLR();

        if (Input.GetKeyDown(KeyCode.J))
        {
            //myRB.velocity = Vector2.up * jSpeed;
            myRB.AddForce(Vector2.up * jSpeed);
        }

    }

    void AnimateLR()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.x == 0)
        {
            //myAnim.SetBool("doRun", false);
        }
        else if (movement.x > 0)
        {
            //go right
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            //myAnim.SetBool("doRun", true);
        }
        else if (movement.x < 0)
        {
            //go left
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            //myAnim.SetBool("doRun", true);
        }
    }

}
