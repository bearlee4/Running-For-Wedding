using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public GameObject[] Grounds;
    float timer;
    float waitingTime;
    public GameManagerLogic manager;
    GameObject sg;

    // Start is called before the first frame update
    void Start()
    {
        sg = Grounds[0];
        timer = 0;
        waitingTime = 1.65f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject copy;

        if (manager.second == 28 && manager.minute == 0)
            sg = Grounds[1];

        else if (manager.minute == 0 && manager.second == 58)
            sg = Grounds[2];

        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            timer = 0;
            copy = Instantiate(sg, transform.TransformPoint(-10.0f, 0, -1), Quaternion.identity);
            copy.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 0));
            Destroy(copy, 60.0f);
        }
    }
}
