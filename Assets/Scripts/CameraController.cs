using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform far, middle;
    public float minHeight, maxHeight;
    private Vector2 lastpos;
    // Start is called before the first frame update
    void Start()
    {
        lastpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
        Vector2 amounToMove = new Vector2(transform.position.x - lastpos.x, transform.position.y - lastpos.y);
        far.position = far.position + new Vector3(amounToMove.x, amounToMove.y,0f);
        middle.position += new Vector3(amounToMove.x, amounToMove.y, 0f) * 0.5f;

        lastpos = transform.position;
    }
}
