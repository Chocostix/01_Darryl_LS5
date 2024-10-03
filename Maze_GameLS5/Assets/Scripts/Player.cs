﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    int cc;
    public Text CC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float MH = Input.GetAxis("Horizontal");
        float MV = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MH, 0, MV);
        transform.Translate(movement * Time.deltaTime * speed);

        if(cc == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Coin")
        {
            cc += 1;
            CC.text = "Coins Collected: " + cc;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Hazard")
        {
            
            SceneManager.LoadScene("Lose");
            PlayerPrefs.SetInt("SS", SceneManager.GetActiveScene().buildIndex);
        }
    }
}
