using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollider : MonoBehaviour
{

    public ValidLocation obj;
    public bool Right;
    public bool Left;
    public bool arrived;

    // Use this for initialization
    void Start()
    {
        Right = true;
        Left = true;
        arrived = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Right && !Left && !arrived)
        {
            obj.rb.isKinematic = false;
            obj.isFallen = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tracker 1(9)")
        {
            Right = true;
        }
        if (other.gameObject.name == "Tracker 2(7)")
        {
            Left = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Tracker 1(9)")
        {
            Right = false;
        }
        if (other.gameObject.name == "Tracker 2(7)")
        {
            Left = false;
        }
    }
}
