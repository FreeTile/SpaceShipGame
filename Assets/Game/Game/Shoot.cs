using UnityEngine;


public class Shoot 
{
   public void CreateShoot(Vector3 Mov, float Rotate, Vector3 Pos)
    {
        GameObject Bullet = new GameObject();
        Bullet.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bullet");
        Bullet.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0);
        Bullet.GetComponent<Transform>().position = Pos;
        Bullet.GetComponent<Transform>().Rotate(0,0,Rotate+90);
        Bullet.AddComponent<BoxCollider2D>().size=new Vector2(7.29f,1.5f);
        Bullet.AddComponent<BulletActions>();
        Bullet.GetComponent<BulletActions>().Movement = Mov;
        Bullet.GetComponent<BulletActions>().Rotate = Rotate;
        Bullet.gameObject.name = "Bullet";
        Bullet.gameObject.tag = "Bullet";
    }
    public void CreateLazer(Vector3 Mov, float Rotate, Vector3 Pos)
    {
        GameObject Lazer = new GameObject();
        Lazer.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lazer");
        Lazer.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0);
        Lazer.GetComponent<Transform>().position = Pos;
        Lazer.GetComponent<Transform>().Rotate(0, 0, Rotate +180);
        Lazer.AddComponent<BoxCollider2D>().size = new Vector2(1f, 3f);
        Lazer.AddComponent<BulletActions>();
        Lazer.GetComponent<BulletActions>().Movement = Mov;
        Lazer.gameObject.name = "Lazer";
        Lazer.gameObject.tag = "Lazer";
    }

    public void CreateEnemyShoot(Vector3 Mov, Vector3 Pos)
    {
        GameObject EnemyShoot = new GameObject();
        EnemyShoot.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("EnemyShoot");
        EnemyShoot.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0);
        EnemyShoot.GetComponent<Transform>().position = Pos;
        EnemyShoot.AddComponent<BoxCollider2D>().size = new Vector2(2.19f, 2.19f);
        EnemyShoot.GetComponent<BoxCollider2D>().isTrigger = true;
        EnemyShoot.AddComponent<BulletActions>();
        EnemyShoot.GetComponent<BulletActions>().Movement = Mov*0.5f;
        EnemyShoot.AddComponent<Rigidbody2D>().gravityScale = 0;
        EnemyShoot.gameObject.name = "EnemyShoot";
        EnemyShoot.gameObject.tag = "EnemyShoot";
    }
}
