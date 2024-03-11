using UnityEngine;

public class PlayerLevelDetection : MonoBehaviour
{
    public Transform player;
    private Vector3 loc;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {   
        if (Physics.Raycast(player.position, Vector3.down, out hit))
        {
            loc = hit.point;
        }
        transform.position = new Vector3(player.position.x , loc.y - 0.49f, player.position.z);
    }
}
