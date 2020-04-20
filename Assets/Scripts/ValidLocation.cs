using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class ValidLocation : MonoBehaviour
{

    // 1
    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    public Transform cameraRigTransform;
    public Transform headTransform;

    public GameObject dead;
	public Rigidbody rb;
    public Vector3 ball_pos;
    public Vector3 offset;
    public bool isFallen;
    public int num = 1;
    public float lastball;

    public float delay = 5f;
    [SerializeField]
    public float timeElapsed;

    public GameObject background;
    public GameObject sad;

    void Falling()
    {
            lastball = ball_pos.y;
            ball_pos = rb.position;
            ball_pos.x = cameraRigTransform.position.x;
            ball_pos.z = cameraRigTransform.position.z;
            ball_pos.y += (float)0.5;

            offset = cameraRigTransform.position - headTransform.position;
            offset.x = 0;
            offset.z = 0;

            cameraRigTransform.position = ball_pos + offset;
            Debug.Log(ball_pos.y);
    }
	
    void Start()
    {
        isFallen = false;
        rb.isKinematic = true;
        ball_pos = rb.position;
        dead.SetActive(false);
        lastball = 0;
        Debug.Log(num);
    }

	
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isFallen && ball_pos.y > num && ball_pos.y != lastball)
        {
            
            Vector3 force = new Vector3(0, (float)-20, 0);
            rb.AddForce(force);
            Falling();
          
        }
        else if (isFallen)
        {
            dead.SetActive(true);
            Destroy(background);
            sad.SetActive(true);
            timeElapsed += Time.deltaTime;

            if (timeElapsed > delay)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
