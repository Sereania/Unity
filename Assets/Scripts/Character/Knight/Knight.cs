using UnityEngine;

public class Knight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    AttackBoxZone _attackbBoxZone;
    // Update is called once per frame
    void Update()
    {
        _attackbBoxZone = GetComponentInChildren<AttackBoxZone>();
        if(_attackbBoxZone.detectionColliders.Count > 0 )
        {
            //_animatior.Settrigger(Animation.)
            //returen;
        }
    }
}
