using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlaing : MonoBehaviour
{
    int framesforspawn=10;
    void FixedUpdate()
    {
        if (framesforspawn == 0)
        {
            Meteor NewMeteor = new Meteor();
            NewMeteor.CreateMeteor();
            framesforspawn =  10;
        }
        else framesforspawn -= 1;
    }
}
