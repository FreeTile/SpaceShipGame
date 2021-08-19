using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorActions : MonoBehaviour
{
    public Vector3 Vector, ControlSpeed, VecToShip;
    private float TimeRemaining = 5, ShootTime = 4, Angle;
    public static int Count;
    void FixedUpdate()
    {
        System.Random rnd = new System.Random();
        if (this.gameObject.tag == "Meteor" || this.gameObject.tag == "SmallMeteor")
        {
            this.gameObject.transform.position += Vector * 0.1f;
        }
        if (this.gameObject.tag == "Enemy")
        {
            if (TimeRemaining <= 0)
            {
                TimeRemaining = 3;
                Vector = new Vector2((float)rnd.NextDouble() * rnd.Next(-1, 1), (float)rnd.NextDouble() * rnd.Next(-1, 1));
            }
            else
            {
                TimeRemaining -= Time.deltaTime;
                this.gameObject.transform.position += Vector * 0.05f;
            }

            if (ShootTime <= 0)
            {
                ShootTime = 1;
                Shoot EnemyShoot = new Shoot();

                VecToShip = GameObject.Find("Ship(Clone)").gameObject.transform.position - this.gameObject.transform.position;
                Angle = Mathf.Acos(VecToShip.x / Mathf.Sqrt(Mathf.Pow(VecToShip.x, 2) + Mathf.Pow(VecToShip.y, 2)));
                if (GameObject.Find("Ship(Clone)").gameObject.transform.position.y < this.gameObject.transform.position.y)
                {
                    ControlSpeed = new Vector2(Mathf.Cos(Angle), -Mathf.Sin(Angle));
                }
                else ControlSpeed = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
                EnemyShoot.CreateEnemyShoot(ControlSpeed, this.gameObject.transform.position);
            }
            else
            {
                ShootTime -= Time.deltaTime;
            }

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
