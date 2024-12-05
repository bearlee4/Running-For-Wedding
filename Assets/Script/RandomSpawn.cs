using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Items;
    public GameObject[] enemies;
    float timer;
    float waitingTime;
    float Itimer;
    float spawnTime;
    float time;
    public GameManagerLogic manager;
    int randItem;
    int randSpawn;
    GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        waitingTime = 2;
        Itimer = 0;
        spawnTime = 4.5f;
        time = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (manager.second == 30 && manager.minute == 0)
        {
            Debug.Log("2단계 진입");
            waitingTime = 1.5f;
            spawnTime = 5f;
        }

        else if (manager.minute == 1 && manager.second == 0)
        {
            Debug.Log("3단계 진입");
            waitingTime = 1f;
            spawnTime = 7f;
        }*/
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            timer = 0;
            Ran();          
        }

        Itimer += Time.deltaTime;
        if (Itimer > spawnTime)
        {
            Itimer = 0;
            ItemSpawn();
        }
    }

    void Ran()
    {
        int randEnemy;
        GameObject test;
        if (manager.second >= 0 && manager.second < 28 && manager.minute == 0)
            randEnemy = Random.Range(0, 3);
        else if (manager.second >= 28 && manager.minute == 0)
            randEnemy = Random.Range(3, 6);
        else
            randEnemy = Random.Range(6, 9);


        if (enemies[randEnemy].name == "Enemy1")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 0.5f, -1), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(test, time);
        }

        else if (enemies[randEnemy].name == "Enemy7")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 3.03f, -1), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(test, time);
        }

        else if (enemies[randEnemy].name == "Enemy8")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 0.5f, 1.5f), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(test, time);
        }

        else if (enemies[randEnemy].name == "Enemy9")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 1.6f, -2), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-700, 0, 0));
            Destroy(test, time);
        }

        else if (enemies[randEnemy].name == "Enemy2")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 3f, -1), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-700, 0, 0));
            Destroy(test, time);
        }

        else if (enemies[randEnemy].name == "Enemy4")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 0.9f, -1), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(test, time);
        }

        else if (enemies[randEnemy].name == "Enemy3")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 5, -1), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(test, time);
        }

        else if (enemies[randEnemy].name == "Enemy5")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 3.25f, -1), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(test, time);
        }

        else if (enemies[randEnemy].name == "Enemy6")
        {
            test = Instantiate(enemies[randEnemy], transform.TransformPoint(0, 0.7f, -1), enemies[randEnemy].transform.rotation);
            test.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(test, time);
        }
    }
    void ItemRotate()
    {
        if (randSpawn == 0)
        {
            item = Instantiate(Items[randItem], transform.TransformPoint(0, 2, -1), Items[randItem].transform.rotation);
            item.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(item, time);
        }

        else if (randSpawn == 1)
        {
            item = Instantiate(Items[randItem], transform.TransformPoint(0, 3, -1), Items[randItem].transform.rotation);
            item.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(item, time);
        }

        else if (randSpawn == 2)
        {
            item = Instantiate(Items[randItem], transform.TransformPoint(0, 5, -1), Items[randItem].transform.rotation);
            item.GetComponent<Rigidbody>().AddForce(new Vector3(-500, 0, 0));
            Destroy(item, time);
        }

        /*else if (randSpawn == 3)
        {
            item = Instantiate(Items[randItem], transform.TransformPoint(0, 5, -1), Items[randItem].transform.rotation);
            item.GetComponent<Rigidbody>().AddForce(new Vector3(-700, 0, 0));
            Destroy(item, time);
        }

        else
        {
            item = Instantiate(Items[randItem], transform.TransformPoint(0, 6, -1), Items[randItem].transform.rotation);
            item.GetComponent<Rigidbody>().AddForce(new Vector3(-700, 0, 0));
            Destroy(item, time);
        }*/
    }
    void ItemSpawn()
    {
        randItem = Random.Range(0, 6);
        randSpawn = Random.Range(0, 3);

        ItemRotate();
    }
}
