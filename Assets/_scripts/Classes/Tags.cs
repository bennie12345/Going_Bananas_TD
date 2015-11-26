using UnityEngine;
using System.Collections;

public class Tags : MonoBehaviour
{
    public string unitTag = "Unit";
    public string enemyTag = "Enemy";
    public string projectileTag = "Projectile";
    public string baseTag = "Base";
    public string pos1Tag = "SpawnPos1";
    public string pos2Tag = "SpawnPos2";
    public string pos3Tag = "SpawnPos3";
    public string pos4Tag = "SpawnPos4";



    public void GiveTag(string tag, GameObject go)
    {
        go.tag = tag;
    }
}
