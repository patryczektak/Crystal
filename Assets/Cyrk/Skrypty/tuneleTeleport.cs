using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class tuneleTeleport : MonoBehaviour
    {
        public Transform player;
        public Transform target;
    public int id;
    public pleyerController pC;

    //false mean teleport on Yaxis
    //true mean telepoty on Xaxis
    public bool XorY;

    public bool tele;
        // Start is called before the first frame update
        void Start()
        {
        tele = false;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == 8)
            {

            if (XorY == false)
            {
                tele = true;
                pC.teleportacja = true;
                player.transform.position = new Vector3(target.transform.position.x, player.transform.position.y, player.transform.position.z);
                Debug.Log("tele " + id);
            }

            if (XorY == true)
            {
                tele = true;
                pC.teleportacja = true;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, target.transform.position.z);
                Debug.Log("teleZ "+ id);
            }

            //tele = false;
            StartCoroutine (TeleON());
            }
        }

    IEnumerator TeleON()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("teleONNN");
        pC.teleportacja = false;
        tele = false;
    }

    }
