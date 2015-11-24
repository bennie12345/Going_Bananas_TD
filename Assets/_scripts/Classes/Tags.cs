using UnityEngine;
using System.Collections;

public class Tags : MonoBehaviour
{
    public string unitTag = "Unit";
    public string enemyTag = "Enemy";
    public string projectileTag = "Projectile";
    public string baseTag = "Base";


    public void GiveTag(string tag, GameObject go)
    {
        go.tag = tag;
    }
}
