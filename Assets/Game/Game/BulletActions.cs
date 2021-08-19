using UnityEngine;

public class BulletActions : MonoBehaviour
{
    public Vector3 Movement;
    public float Rotate;
    public void Start()
    {      

    }
    void FixedUpdate()
    {
        this.gameObject.transform.position += Movement*0.2f ;
        if (this.gameObject.transform.position.x >9 || this.gameObject.transform.position.x < -9 || this.gameObject.transform.position.y > 5 || this.gameObject.transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
