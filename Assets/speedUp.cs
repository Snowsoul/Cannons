using UnityEngine;
using System.Collections;

public class speedUp : MonoBehaviour {

    float oldGravity = 0f;
    float oldSpeed = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SimpleProjectile" || other.tag =="FireProjectile" || other.tag =="FreezeProjectile")
        {
            GameObject g = other.gameObject;
            Projectile projScript = g.GetComponent<Projectile>();

            oldGravity = g.GetComponent<Rigidbody2D>().gravityScale;
            oldSpeed = projScript.maxSpeed;

            projScript.maxSpeed = 0f;

            g.GetComponent<Rigidbody2D>().gravityScale = 0f;

             
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "SimpleProjectile" || other.tag == "FireProjectile" || other.tag == "FreezeProjectile")
        {
            GameObject g = other.gameObject;
            Projectile projScript = g.GetComponent<Projectile>();

            //projScript.maxSpeed = oldSpeed;
            g.GetComponent<Rigidbody2D>().gravityScale = oldGravity;


        }
    }
}
