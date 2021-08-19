using UnityEngine;
using UnityEngine.UI;
using System;

public class Info : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Score: " + MeteorActions.Count;
        this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Rotate: " + Control.RotateShip;
        this.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Speed: " + Control.speed;
        this.gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Lazer Charges: " + Control.LazerCount;
        this.gameObject.transform.GetChild(4).gameObject.GetComponent<Text>().text = "Reload Lazer Time: " + Math.Round(Control.TimeRemaining,3);
    }
}
