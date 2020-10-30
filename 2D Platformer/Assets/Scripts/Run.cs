using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

    public float maxSpeed = 5f;
    public float sharpness = 1f;
    public Animator animator;
    private GameObject player;
    float speed;
    float t = 0f;
    float move = 0f;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Move", move);
        move = Input.GetAxisRaw("Horizontal");

        if (move != 0f){
            flag = true;
        }
        else {
            flag = false;
        }

        // MOVE = 1/-1 GO
        if (flag){

            if (speed < maxSpeed && speed > - maxSpeed){
                speed = 20f * move * Mathf.Pow(t*sharpness,2f);
                t += Time.deltaTime;
            }

        }


        // MOVE = 0 STOP
        else {
            if (t > 0f && speed > 0f){
                t -= Time.deltaTime;
                speed = 20f * Mathf.Pow(t*sharpness,2f);
            }
            else if (t > 0f && speed <0f){
                t -= Time.deltaTime;
                speed = -20f * Mathf.Pow(t*sharpness,2f);
            }
        }

        if (speed >= maxSpeed || speed <= -maxSpeed){
            speed = maxSpeed * move;
        }

        
    }

    void FixedUpdate(){
        player.transform.position += new Vector3(speed * Time.fixedDeltaTime,0f,0f);
    }
}
