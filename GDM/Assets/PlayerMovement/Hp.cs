using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public float hp;
    public float currenthp;
    public Movement moveMent;
    // Start is called before the first frame update
    void Start()
    {
        currenthp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(float damge)
    {
        currenthp -= damge;
        Debug.Log("Take Damege");
        if(currenthp <= 0)
        {
            this.moveMent.isDead = true;
        }
    }
}
