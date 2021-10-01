using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkOnInput : MonoBehaviour
{
    public GameObject GM;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) GM.transform.localScale = new Vector3(8f, 0.01f,8f);
        else GM.transform.localScale = new Vector3(11f, 0.01f,11f);;
    }
}
