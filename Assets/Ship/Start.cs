using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
public class Start : MonoBehaviour
{
    public Sprite sprite;
    public  GameObject Stats, ShipParent, NewShip;
    public void StartPlay()
    {
        NewShip = Instantiate(ShipParent); ;
        NewShip.SetActive(true);
        Stats.SetActive(true);
        GameObject Canvas = GameObject.Find("Canvas");
        GameObject Start = Canvas.transform.GetChild(0).gameObject;
        GameObject Exit = Canvas.transform.GetChild(1).gameObject;
        GameObject Restart = Canvas.transform.GetChild(2).gameObject;
        Start.SetActive(false);
        Exit.SetActive(false);
        Restart.SetActive(false);
    }
}
