using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    public Transform OldPlayer;
    public GameObject NewPlayer;
    public GameObject BlockBox;

    private int thisX;
    private int thisZ;
    private int targetX;
    private int targetZ;

    void Update()
    {
        thisX = Mathf.RoundToInt(this.transform.position.x);
        thisZ = Mathf.RoundToInt(this.transform.position.z);
        targetX = Mathf.RoundToInt(OldPlayer.position.x);
        targetZ = Mathf.RoundToInt(OldPlayer.transform.position.z);
        if (thisX == targetX && thisZ == targetZ)
        {
            Destroy(BlockBox.gameObject);
            Destroy(this.gameObject);
            Destroy(OldPlayer.gameObject);
            Instantiate(NewPlayer, OldPlayer.position, OldPlayer.rotation);
        }
    }
}
