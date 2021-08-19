using UnityEngine;
public class Start : MonoBehaviour
{
    public Sprite sprite;
    public  GameObject Stats, ShipParent, NewShip;
    public void StartPlay()
    {
        NewShip = Instantiate(ShipParent); ;
        NewShip.SetActive(true);
        MeteorActions.Count = 0;
        Control.LazerCount = 3;
        Control.TimeRemaining = 5f;
        Stats.SetActive(true);
        GameObject Canvas = GameObject.Find("Canvas");
        GameObject Start = Canvas.transform.GetChild(0).gameObject;
        GameObject Exit = Canvas.transform.GetChild(1).gameObject;
        GameObject Restart = Canvas.transform.GetChild(2).gameObject;
        Start.SetActive(false);
        Exit.SetActive(false);
        Restart.SetActive(false);
        GameObject.Find("End").gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
