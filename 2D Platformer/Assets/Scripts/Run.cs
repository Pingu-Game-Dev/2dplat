﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

    public float maxSpeed = 5f;
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
        move = Input.GetAxisRaw("Horizontal");
        if (move != 0f){
            flag = true;
        }
        else {
            flag = false;
        }
        if (flag){
            if (speed < maxSpeed && speed > -maxSpeed){
                speed = 10f * move * Mathf.Pow(t,2f);
                t += Time.deltaTime;
            }
            else {}
        }
        else {
            speed = 10f * Mathf.Pow(t,2f);
            if (t > 0f){
                t -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate(){
        player.transform.position += new Vector3(speed * Time.fixedDeltaTime,0f,0f);
    }
}
