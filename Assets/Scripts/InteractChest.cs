using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractChest : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject camera;
    [SerializeField] private Transform player;


    private bool isInteracting;
   
    public void Interact()
    {
        isInteracting = !isInteracting;

        if (isInteracting)
        {
            camera.SetActive(true);
        }

        else
            camera.SetActive(false);
    }


    private void Update()
    {
        if(isInteracting)
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, player.position);

            if (distance > 2)
            {
                isInteracting = false;
                camera.SetActive(false);

                isInteracting = false;
            }
        }
    }
}