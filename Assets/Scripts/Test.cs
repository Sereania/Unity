using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public bool moveRight = true;
    public bool bigger = true;
    public bool moveUp = true;
    public GameObject[] Targets;
    private GameObject currentTarget;
    public float speed =1f;
    void Start()
    {
        if (Targets.Length > 0)
        {
            PickRandomTarget();
        }
        Debug.Log("Debug �޽���");
        

    }
    void PickRandomTarget()
    {
        int randomindex = UnityEngine.Random.Range(0, Targets.Length);
        currentTarget = Targets[randomindex];
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 direction = currentTarget.transform.position - transform.position;
        float distance = Vector3.Distance(currentTarget.transform.position, transform.position);
        transform.position += direction.normalized * Time.deltaTime* speed;
        if(distance <0.1f)
        {
            Debug.Log("Ÿ�ٿ� �����߽��ϴ�");
            PickRandomTarget();
        }




        Debug.Log("Update �޽���");

    }
}
















/*
if (moveRight==true)
{
    transform.position += new Vector3(0.01f, 0, 0);

}
else
{
    transform.position += new Vector3(-0.01f, 0, 0);
}


if (transform.position.x > 7)
{
    moveRight = false;
}
else if (transform.position.x < -7)
{
    moveRight = true;
}
if (bigger==true)
{
    transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
}
else
{
    transform.localScale += new Vector3(-0.001f, -0.001f, -0.001f);
}

if (transform.localScale.x > 3)
{
    bigger = false;
}
else if (transform.localScale.x < 1)
{
    bigger = true;
}

if (moveUp == true)
{
    transform.position += new Vector3(0, 0.01f, 0);

}
else
{
    transform.position += new Vector3(0, -0.01f, 0);
}


if (transform.position.y > 5)
{
    moveUp = false;
}
else if (transform.position.y < -5)
{
    moveUp = true;
}
*/
