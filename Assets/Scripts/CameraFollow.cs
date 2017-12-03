using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public bool playerEnterBossRoom = false;
    private Player player;

    public void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        playerEnterBossRoom = false;
    }

    public void Update()
    {
        checkPlayerPos();
        if (playerEnterBossRoom) transform.position = new Vector3(target.position.x + 3, transform.position.y, transform.position.z);
        else transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }

    public void checkPlayerPos()
    {
        playerEnterBossRoom = player.enterBossRoom;
    }
}
