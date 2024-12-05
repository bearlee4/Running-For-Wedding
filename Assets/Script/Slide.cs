using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public GameObject SlidePosition;

    // Start is called before the first frame update
    void Start()
    {
        SlidePosition.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
