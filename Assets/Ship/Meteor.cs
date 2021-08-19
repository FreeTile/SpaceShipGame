using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Meteor 
{
    public Vector3 Vector;
    public void CreateMeteor()
    {
        System.Random rnd = new System.Random();
        int Pos=rnd.Next(1, 5);
        GameObject Meteor = new GameObject();
        int[] num = new int[2] { -1, 1 };
        if (Pos == 1)
        {
            Meteor.gameObject.transform.position = new Vector3(rnd.Next(-12, -10), rnd.Next(-5, 5), 1);
            Vector = new Vector3((float)rnd.NextDouble(), (float)(rnd.NextDouble() * 0.5 * num[rnd.Next(num.Length)]), 0);

        }
        else if (Pos == 2)
        {
            Meteor.gameObject.transform.position = new Vector3(rnd.Next(-9, 9), rnd.Next(6, 8), 1);
            Vector = new Vector3((float)(rnd.NextDouble() * 0.5 * num[rnd.Next(num.Length)]), (float)rnd.NextDouble() * -1, 0);
        }
        else if (Pos == 3)
        {
            Meteor.gameObject.transform.position = new Vector3(rnd.Next(10, 12), rnd.Next(-5, 5), 1);
            Vector = new Vector3((float)rnd.NextDouble() * -1, (float)(rnd.NextDouble() * 0.5 * num[rnd.Next(num.Length)]), 0);
        }
        else if (Pos == 4)
        {
            Meteor.gameObject.transform.position = new Vector3(rnd.Next(-9, 9), rnd.Next(-8, -6), 1);
            Vector = new Vector3((float)(rnd.NextDouble() * 0.5 * num[rnd.Next(num.Length)]), (float)rnd.NextDouble(), 0);
        }

        Meteor.AddComponent<MeteorActions>().Vector = Vector; ;
        Meteor.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Meteor");
        Meteor.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 1f);
        Meteor.GetComponent<Transform>().Rotate(0, 0, rnd.Next(180));
        Meteor.AddComponent<BoxCollider2D>().size = new Vector2(6, 6);
        Meteor.GetComponent<BoxCollider2D>().isTrigger = true;
        Meteor.AddComponent<Rigidbody2D>().gravityScale = 0;
        Meteor.name = "Meteor";
        Meteor.gameObject.tag = "Meteor";
    }

    public void CreateSmallMeteors(Vector3 position, Vector3 Move)
    {
        System.Random rnd = new System.Random();

        GameObject SmallMeteor1= new GameObject();
        SmallMeteor1.GetComponent<Transform>().position = position;
        SmallMeteor1.AddComponent<MeteorActions>().Vector = new Vector2(Move.y/2, Move.x/2);
        SmallMeteor1.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Meteor");
        SmallMeteor1.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 1f);
        SmallMeteor1.GetComponent<Transform>().Rotate(0, 0, rnd.Next(180));
        SmallMeteor1.AddComponent<BoxCollider2D>().size = new Vector2(6, 6);
        SmallMeteor1.GetComponent<BoxCollider2D>().isTrigger = true;
        SmallMeteor1.AddComponent<Rigidbody2D>().gravityScale = 0;
        SmallMeteor1.name = "SmallMeteor";
        SmallMeteor1.gameObject.tag = "SmallMeteor";


        GameObject SmallMeteor2 = new GameObject();
        SmallMeteor2.GetComponent<Transform>().position = position;
        SmallMeteor2.AddComponent<MeteorActions>().Vector = -(new Vector2(Move.y/2, Move.x/2));
        SmallMeteor2.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Meteor");
        SmallMeteor2.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 1f);
        SmallMeteor2.GetComponent<Transform>().Rotate(0, 0, rnd.Next(180));
        SmallMeteor2.AddComponent<BoxCollider2D>().size = new Vector2(6, 6);
        SmallMeteor2.GetComponent<BoxCollider2D>().isTrigger = true;
        SmallMeteor2.AddComponent<Rigidbody2D>().gravityScale = 0;
        SmallMeteor2.name = "SmallMeteor";
        SmallMeteor2.gameObject.tag = "SmallMeteor";
    }
}
