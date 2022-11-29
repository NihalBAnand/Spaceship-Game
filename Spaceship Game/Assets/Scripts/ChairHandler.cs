using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairHandler : MonoBehaviour
{
    GameObject tooltip;

    GameObject player;

    public bool canSit;
    // Start is called before the first frame update
    void Start()
    {
        tooltip = GameObject.Find("ChairTooltip");
        tooltip.SetActive(false);

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerInfo>().sitting)
        {
            Transform seat = transform.Find("Seat");

            seat.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") * .5f, 0);

            player.transform.position = seat.Find("MoveTo").position;
            Vector3 target = seat.eulerAngles;
            target.x = 0;
            target.y += 90;
            target.z = 0;
            player.transform.eulerAngles = target;

            if (Input.GetKeyDown("f"))
            {
                player.GetComponent<PlayerInfo>().sitting = false;
            }
        }

        if (canSit && Input.GetKeyDown("f"))
        {
            player.GetComponent<PlayerInfo>().sitting = true;
            
            canSit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tooltip.SetActive(true);
            canSit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tooltip.SetActive(false);
            canSit = false;
        }
    }
}
