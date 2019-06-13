using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Shape
{
    private void Start()
    {
        StartCoroutine(DestroyObject(10f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Animator>().SetInteger("Shape", (int)myShape);


        try
        {
            Shape hitShape = collision.transform.GetComponent<Shape>();
            if(hitShape.myShape == myShape)
            {
                hitShape.GetComponent<Animator>().SetBool("IsRetracted", true);
                GameManager.Instance.HasHitHole();
            } else
            {
                GameManager.Instance.HasMissedHole();
            }
        } catch (System.Exception)
        {
            GameManager.Instance.HasMissedHole();
        }
    }

    IEnumerator DestroyObject(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this);
    }
}
