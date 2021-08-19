using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShip
{
    public Vector3 Vector;
    public void CreateEnemySpaceShip()
    {
        System.Random rnd = new System.Random();
        int Pos = rnd.Next(1, 5);
        GameObject SpaceShip = new GameObject();
        int[] num = new int[2] { -1, 1 };
        if (Pos == 1)
        {
            SpaceShip.gameObject.transform.position = new Vector3(rnd.Next(-12, -10), rnd.Next(-5, 5), 1);
            Vector = new Vector3((float)rnd.NextDouble(), (float)(rnd.NextDouble() * 0.5 * num[rnd.Next(num.Length)]), 0);

        }
        else if (Pos == 2)
        {
            SpaceShip.gameObject.transform.position = new Vector3(rnd.Next(-9, 9), rnd.Next(6, 8), 1);
            Vector = new Vector3((float)(rnd.NextDouble() * 0.5 * num[rnd.Next(num.Length)]), (float)rnd.NextDouble() * -1, 0);
        }
        else if (Pos == 3)
        {
            SpaceShip.gameObject.transform.position = new Vector3(rnd.Next(10, 12), rnd.Next(-5, 5), 1);
            Vector = new Vector3((float)rnd.NextDouble() * -1, (float)(rnd.NextDouble() * 0.5 * num[rnd.Next(num.Length)]), 0);
        }
        else if (Pos == 4)
        {
            SpaceShip.gameObject.transform.position = new Vector3(rnd.Next(-9, 9), rnd.Next(-8, -6), 1);
            Vector = new Vector3((float)(rnd.NextDouble() * 0.5 * num[rnd.Next(num.Length)]), (float)rnd.NextDouble(), 0);
        }

        SpaceShip.AddComponent<MeteorActions>().Vector = Vector; ;
        SpaceShip.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("EnemyShip");
        SpaceShip.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1f);
        SpaceShip.AddComponent<BoxCollider2D>().size = new Vector2(1.8f, 1.5f);
        SpaceShip.GetComponent<BoxCollider2D>().isTrigger = true;
        SpaceShip.AddComponent<Rigidbody2D>().gravityScale = 0;
        SpaceShip.name = "Enemy";
        SpaceShip.gameObject.tag = "Enemy";
    }
}
