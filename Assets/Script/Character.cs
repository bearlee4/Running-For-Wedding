using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody rb;
    bool isGround;
    public GameManagerLogic manager;
    bool ProtectToken;
    public GameObject SlidePosition;
    public GameObject StandPosition;
    public GameObject EatSound;
    public Animator ani;
    AudioSource audio;
    AudioSource Eataudio;


    void Start()
    {
        SlidePosition.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        isGround = true;
        ani = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        Eataudio = EatSound.GetComponent<AudioSource>();
        ProtectToken = false;
    }

    void Update()
    {
        /*Vector3 vec = new Vector3(0.025f, 0, 0);
        transform.Translate(vec);*/
        if (Input.GetButtonDown("Jump") && isGround && !Input.GetButton("Slide"))
        {
            ani.SetBool("Jump", true);
            Invoke("Jump", 0.11f);
        }
        Sliding();

        if (Input.GetButtonDown("Test"))
        {
            manager.Durability = manager.Durability - 20f;
            if (manager.Durability < 0)
                manager.Durability = 0;
            manager.DurabilityUpdate(manager.Durability);
        }
    }

    private void Jump()
    {
            isGround = false;
            rb.AddForce(new Vector3(0, 16f, 0), ForceMode.Impulse);
    }

    private void Sliding()
    {
        if (Input.GetButton("Slide"))
        {
            if (isGround == true)
            {
                SlidePosition.gameObject.SetActive(true);
                StandPosition.gameObject.SetActive(false);
                Debug.Log("슬라이딩중");
                if (ProtectToken == true)
                {
                    manager.ExtraDurability = manager.ExtraDurability - 0.02f;
                    manager.ExtraDurabilityUpdate(manager.ExtraDurability);
                    if (manager.ExtraDurability < 0)
                    {
                        manager.ExtraDurability = 0;
                        ProtectToken = false;
                        manager.ProtectText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    manager.Durability = manager.Durability - 0.02f;
                    if (manager.Durability < 0)
                        manager.Durability = 0;
                    manager.DurabilityUpdate(manager.Durability);
                }
            }
        }
        else
        {
            SlidePosition.gameObject.SetActive(false);
            StandPosition.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ani.SetBool("Jump", false);
        if (collision.gameObject.name == "Ground")
            isGround = true;
        else if (collision.gameObject.name == "TestGround(Clone)")
            isGround = true;
        else if (collision.gameObject.name == "Ground2(Clone)")
            isGround = true;
        else if (collision.gameObject.name == "Ground3(Clone)")
            isGround = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("충돌함");

            audio.Play();

            if (ProtectToken == true)
            {
                Debug.Log("1회방어");
                ProtectToken = false;
                manager.ProtectText.gameObject.SetActive(false);
            }

            else if (manager.Durability == 0)
            {
                if ((col.name == "Enemy1(Clone)") || (col.name == "Enemy6(Clone)"))
                {
                    manager.playerlife--;
                    manager.LifeUpdate(manager.playerlife);
                }
                else
                {
                    Debug.Log(manager.Durability);
                    manager.playerlife--;
                    manager.playerlife--;
                    manager.LifeUpdate(manager.playerlife);
                    if (manager.Durability < 0)
                        manager.Durability = 0;
                    manager.DurabilityUpdate(manager.Durability);
                }
            }

            else if (col.name == "Enemy1(Clone)" || col.name == "Enemy6(Clone)")
            {
                manager.Durability = manager.Durability - 60f;
                if (manager.Durability < 0)
                    manager.Durability = 0;
                manager.DurabilityUpdate(manager.Durability);
            }
            else
            {
                manager.playerlife--;
                manager.LifeUpdate(manager.playerlife);
                manager.Durability = manager.Durability - 20f;
                if (manager.Durability < 0)
                    manager.Durability = 0;
                manager.DurabilityUpdate(manager.Durability);
            }
            
        }

        if (col.tag == "HealItem")
        {
            Eataudio.Play();
            if (col.gameObject.name == "Heal1(Clone)")
            {
                Debug.Log("체력회복");
                manager.playerlife++;
                if(manager.playerlife > 3)
                {
                    manager.playerlife = 3;
                }
                manager.LifeUpdate(manager.playerlife);
            }
            else if (col.gameObject.name == "Heal2(Clone)")
            {
                Debug.Log("체력회복");
                manager.playerlife = manager.playerlife + 2;
                if (manager.playerlife > 3)
                {
                    manager.playerlife = 3;
                }
                manager.LifeUpdate(manager.playerlife);
            }
            else
            {
                Debug.Log("보호막생성");
                manager.ExtraDurability = 50f;
                manager.ExtraDurabilityUpdate(manager.ExtraDurability);
                ProtectToken = true;
                manager.ProtectText.gameObject.SetActive(true);
            }
        }
        if (col.tag == "Item")
        {
            Eataudio.Play();
            Debug.Log("내구도회복");
            if (col.gameObject.name == "DH1(Clone)")
            {
                manager.Durability = manager.Durability + 40.0f;
                if (manager.Durability > 100.0f)
                    manager.Durability = 100.0f;
                manager.DurabilityUpdate(manager.Durability);
            }
            else if (col.gameObject.name == "DH2(Clone)")
            {
                manager.Durability = manager.Durability + 60.0f;
                if (manager.Durability > 100.0f)
                    manager.Durability = 100.0f;
                manager.DurabilityUpdate(manager.Durability);
            }
            else
            {
                manager.Durability = manager.Durability + 100.0f;
                if (manager.Durability > 100.0f)
                    manager.Durability = 100.0f;
                manager.DurabilityUpdate(manager.Durability);
            }
        }
    }
}
