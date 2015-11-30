using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour
{
    Vector3 MousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(MousePos().x, MousePos().y, 0), 1f);
        RaycastSphere();
    }

    void RaycastSphere() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(MousePos().x, MousePos().y), 1);
        for (int i = 0; i < colliders.Length; i++) {
            Debug.Log(colliders[i].name);
            Debug.Log(colliders[i].tag);
            if (colliders[i].tag == "Tree")
            {
                Debug.Log("unit can be placed here");
            }
            else if(colliders[i].tag != "Tree")
            {
                Debug.Log("unit can't be placed here");
            }
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(new Vector3(MousePos().x, MousePos().y, 0), 1);
    }
}