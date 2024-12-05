using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mground : MonoBehaviour
{
    public GameObject perfab;
    private Rigidbody g;

    // Start is called before the first frame update
    void Start()
    {
        g = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float check = 5;
        Vector3 move = new Vector3(-0.2f, 0, 0);
        transform.Translate(move);
        Destroy(perfab, check);
    }
}
