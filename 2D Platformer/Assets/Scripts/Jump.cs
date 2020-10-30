using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public LayerMask m_ground;
    public Transform groundCheck;
    public float jumpForce = 100f;
    public bool fullAirControl = true;
    bool jump = false;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = gameObject.GetComponent<Run>().maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
        else if (Input.GetButtonUp("Jump")){
            jump = false;
        }
    }


    void FixedUpdate(){
        Debug.Log(gameObject.GetComponent<Run>().maxSpeed);
        if(CheckforGround()){
            gameObject.GetComponent<Run>().maxSpeed = speed;
        }
        if (CheckforGround() && jump){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpForce));
            jump = false;
            if(!fullAirControl){
                gameObject.GetComponent<Run>().maxSpeed /= 2f;
            }
        }
    }

    bool CheckforGround(){
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(groundCheck.position, new Vector2(gameObject.transform.localScale.x,gameObject.transform.localScale.y / 10f), 0f,m_ground);
        
        if (hitColliders.Length > 0){
            return true;
        }
        return false;
    }
}
