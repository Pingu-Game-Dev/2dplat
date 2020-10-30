using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public LayerMask m_ground;
    public Transform groundCheck;
    public float jumpForce = 100f;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
    }


    void FixedUpdate(){
        if (CheckforGround() && jump){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpForce));
            jump = false;
        }
    }

    bool CheckforGround(){
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(groundCheck.position, gameObject.transform.localScale / 2, 0f,m_ground);
        
        if (hitColliders.Length > 0){
            return true;
        }
        return false;
    }
}
