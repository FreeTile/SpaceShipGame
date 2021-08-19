using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorActions : MonoBehaviour
{
    public Vector3 Vector;
    private float TimeRemaining=5, ShootTime=4,Acos;
    public static int Count;
    void FixedUpdate()
    {
        System.Random rnd = new System.Random();
        if (this.gameObject.tag == "Meteor")
        {
            this.gameObject.transform.position += Vector * 0.1f;
            if (this.gameObject.transform.position.y > 8)
            {
                Destroy(this.gameObject);
            }
            if (this.gameObject.transform.position.y < -8)
            {
                Destroy(this.gameObject);
            }
            if (this.gameObject.transform.position.x > 12)
            {
                Destroy(this.gameObject);
            }
            if (this.gameObject.transform.position.x < -12)
            {
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "Enemy")
        {
            if (TimeRemaining <= 0)
            {
                TimeRemaining = 3;
                Vector = new Vector2((float)rnd.NextDouble()*rnd.Next(-1,1), (float)rnd.NextDouble() * rnd.Next(-1, 1));
            }
            else
            {
                TimeRemaining -= Time.deltaTime;
                this.gameObject.transform.position += Vector*0.1f;
            }

            if (TimeRemaining <= 0)
            {
                TimeRemaining = 1;
                Shoot EnemyShoot = new Shoot();
                Acos = Mathf.Sqrt(Mathf.Pow((GameObject.Find("Ship(Clone)").gameObject.transform.position.x - this.gameObject.transform.position.x), 2) + Mathf.Pow((GameObject.Find("Ship(Clone)").gameObject.transform.position.y - this.gameObject.transform.position.y), 2));
                EnemyShoot.CreateEnemyShoot(GameObject.Find("Ship(Clone)").gameObject.transform.position - this.gameObject.transform.position, Mathf.Acos((GameObject.Find("Ship(Clone)").gameObject.transform.position - this.gameObject.transform.position).x)/ Acos, this.gameObject.transform.position);
            }
            else
            {
                TimeRemaining -= Time.deltaTime;                
            }

            if (this.gameObject.transform.position.y > 8)
            {
                Destroy(this.gameObject);
            }
            if (this.gameObject.transform.position.y < -8)
            {
                Destroy(this.gameObject);
            }
            if (this.gameObject.transform.position.x > 12)
            {
                Destroy(this.gameObject);
            }
            if (this.gameObject.transform.position.x < -12)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && this.gameObject.tag != "SmallMeteor")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Count+=2;
            if (this.gameObject.tag != "Enemy")
            {
                Count--;
                Meteor SmallMeteor = new Meteor();
                SmallMeteor.CreateSmallMeteors(this.gameObject.transform.position, Vector);
            }
        } 
        if (collision.gameObject.tag == "Lazer" && this.gameObject.tag != "SmallMeteor")
        {
            Destroy(this.gameObject);
            Count+=2;
            if (this.gameObject.tag != "Enemy")
            {
                Count--;
                Meteor SmallMeteor = new Meteor();
                SmallMeteor.CreateSmallMeteors(this.gameObject.transform.position, Vector);
            }
        }
        if (collision.gameObject.tag == "Bullet" && this.gameObject.tag == "SmallMeteor")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Count++;
        }
        if (collision.gameObject.tag == "Lazer" && this.gameObject.tag == "SmallMeteor")
        {
            Destroy(this.gameObject);
            Count++;         
        }

    }
}
