using UnityEngine;
using System;
using UnityEngine.UI;


public class Control : MonoBehaviour
{
    private Actions inputs;
    private Vector3 Vector, VectorMov;
    private float Angle, rotate, IsActive, newShoot, newLazer;
    private int  framesforspawnmeteor = 100, framesforspawship=500;
    public GameObject Restart, Score;
    public static float speed, TimeRemaining = 5f;
    public static int RotateShip, LazerCount = 3;
    private GameObject[] Meteors, SmallMeteors, Enemies, EShoot;
    public void Awake()
    {
        inputs = new Actions();
    }
    public void Start()
    {
        inputs.Enable();
    }

    public void OnDisable()
    {
        inputs.Disable();
    }

    public void FixedUpdate()
    {
        if (LazerCount < 3)
        {
            if (TimeRemaining <= 0)
            {
                LazerCount++;
                TimeRemaining = 5;
            }
            else
            {
                TimeRemaining -= Time.deltaTime;
            }
        }

       System.Random rnd = new System.Random();
        
        if (framesforspawnmeteor == 0)
        {
            Meteor NewMeteor = new Meteor();
            NewMeteor.CreateMeteor();
            framesforspawnmeteor = rnd.Next(30,60);
        }
        else framesforspawnmeteor -= 1;

        if (framesforspawship == 0)
        {
            EnemySpaceShip NewShip = new EnemySpaceShip();
            NewShip.CreateEnemySpaceShip();
            framesforspawship = rnd.Next(500, 1000);
        }
        else framesforspawship -= 1;

        rotate = inputs.Ship.Rotate.ReadValue<float>();
        IsActive = inputs.Ship.Move.ReadValue<float>();
        newShoot = inputs.Ship.Shoot.ReadValue<float>();
        newLazer = inputs.Ship.Lazer.ReadValue<float>();
        this.gameObject.transform.Rotate(0,0,rotate*3);
        Angle = (float)(this.gameObject.transform.eulerAngles.z * Math.PI / 180);
        RotateShip = (int)this.gameObject.transform.eulerAngles.z;
        Vector = -new Vector3((float)Math.Sin(Angle), 0, 0) + new Vector3(0, (float)Math.Cos(Angle), 0);
        if (IsActive==1)
        {
            VectorMov +=  Vector*0.05f;
        } else
        {
           if (VectorMov != new Vector3(0,0,0))
            {
                VectorMov += new Vector3(-VectorMov.x * 0.01f, -VectorMov.y * 0.01f, 0);
            }
        }
        speed = (float)Math.Round(Math.Sqrt(Math.Pow(VectorMov.x, 2) + Math.Pow(VectorMov.y, 2)),3);
        this.gameObject.transform.position += new Vector3(VectorMov.x * 0.05f, VectorMov.y * 0.05f, 0);
        if (this.gameObject.transform.position.y>5)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -5, 1);
        }
        if (this.gameObject.transform.position.y < -5)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 5, 1);
        }
        if (this.gameObject.transform.position.x > 9)
        {
            this.gameObject.transform.position = new Vector3(-9,this.gameObject.transform.position.y, 1);
        }
        if (this.gameObject.transform.position.x < -9)
        {
            this.gameObject.transform.position = new Vector3(9,this.gameObject.transform.position.y, 1);
        }
    }

    public void OnShoot()
    {
        if (newShoot == 1)
        {
            Shoot Bullet = new Shoot();
            Bullet.CreateShoot(-new Vector2((float)Math.Sin(Angle), 0) + new Vector2(0, (float)Math.Cos(Angle)), this.gameObject.transform.eulerAngles.z, this.gameObject.transform.position);
        }
    }

    public void OnLazer()
    {
        if (newLazer == 1 && LazerCount > 0)
        {
            LazerCount--;
            Shoot Lazer = new Shoot();
            Lazer.CreateLazer(-new Vector2((float)Math.Sin(Angle), 0) + new Vector2(0, (float)Math.Cos(Angle)), this.gameObject.transform.eulerAngles.z, this.gameObject.transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Meteors = GameObject.FindGameObjectsWithTag("Meteor");
        SmallMeteors = GameObject.FindGameObjectsWithTag("SmallMeteor");
        Enemies= GameObject.FindGameObjectsWithTag("Enemy");
        EShoot = GameObject.FindGameObjectsWithTag("EnemyShoot");
        if (collision.gameObject.tag== "Meteor" || collision.gameObject.tag == "SmallMeteor" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyShoot")
        {
            for (int i=0; i<Meteors.Length; i++)
            {
                Destroy(Meteors[i]);
            }
            for (int i = 0; i < SmallMeteors.Length; i++)
            {
                Destroy(SmallMeteors[i]);
            }
            for (int i = 0; i < Enemies.Length; i++)
            {
                Destroy(Enemies[i]);
            }
            for (int i = 0; i < EShoot.Length; i++)
            {
                Destroy(EShoot[i]);
            }
            Destroy(this.gameObject);
        }
        Restart.SetActive(true);
        GameObject.Find("End").gameObject.transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("End").gameObject.transform.GetChild(0).GetComponent<Text>().text = "Your " + GameObject.Find("Score").GetComponent<Text>().text;
        GameObject.Find("Score").gameObject.transform.parent.gameObject.SetActive(false);
        
    }
}
