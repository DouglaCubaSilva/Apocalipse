using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{

    float speed;
    Vector3 positions;
    public CharacterController controller;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        positions = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            locatePosition();

        moveToPosition();
    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000)){
            positions = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log(positions);
        }
    }

    void moveToPosition()
    {
        Quaternion newRotation = Quaternion.LookRotation(positions-transform.position, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime*rotateSpeed);
    }
}
