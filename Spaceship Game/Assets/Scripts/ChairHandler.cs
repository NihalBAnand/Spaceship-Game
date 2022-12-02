using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairHandler : MonoBehaviour
{
    private GameObject tooltip;

    private GameObject player;

    public bool canSit;
    // Start is called before the first frame update
    void Start()
    {
        tooltip = GameObject.Find("ChairTooltip");
        tooltip.transform.localScale = new Vector3(0, 0, 0);

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerInfo>().sitting && player.GetComponent<PlayerInfo>().chair == this)
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
            player.GetComponent<PlayerInfo>().chair = this;
            
            canSit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tooltip.transform.localScale = new Vector3(1, 1, 1);
            canSit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            tooltip.transform.localScale = new Vector3(0, 0, 0);
            canSit = false;
        }
    }
}
