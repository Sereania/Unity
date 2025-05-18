using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxZone : MonoBehaviour
{
    public List<Collider2D> detectionColliders = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectionColliders.Add(collision);
    }

    private void OnTriggerExit(Collider collision)
    {
        
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
