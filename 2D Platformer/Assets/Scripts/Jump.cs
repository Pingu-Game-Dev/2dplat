using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public LayerMask m_ground;
    public Transform groundCheck;
    public float jumpForce = 100f;
    public bool fullAirControl = true;
    public float airSpeedDivider = 2f;
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
        if(CheckforGround()){
            gameObject.GetComponent<Run>().maxSpeed = speed;
            gameObject.GetComponent<Run>().air = false;
        }
        if (CheckforGround() && jump){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpForce));
            jump = false;
        }
        if(!fullAirControl && !CheckforGround() && !gameObject.GetComponent<Run>().air){
                gameObject.GetComponent<Run>().maxSpeed /= airSpeedDivider;
                gameObject.GetComponent<Run>().air = true;
            }
    }

    bool CheckforGround(){
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(groundCheck.position, new Vector2(gameObject.transform.localScale.x * 0.7f,gameObject.transform.localScale.y / 10f), 0f,m_ground);
        
        if (hitColliders.Length > 0){
            return true;
        }
        return false;
    }
}
