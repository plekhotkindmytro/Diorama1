using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;

    // Update is called once per frame
    void Update()
    {
        g1.transform.Rotate(0, 0, 0.1f);
        g2.transform.Rotate(0, 0, -0.1f);
    }
}
