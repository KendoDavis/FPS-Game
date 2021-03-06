using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{

    public bool shouldMove, shouldRotate;

    public float moveSpeed, rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }

        if (shouldRotate)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotateSpeed * Time.deltaTime, 0));
        }
    }
}
