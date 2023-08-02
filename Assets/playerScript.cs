using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    [SerializeField] private LayerMask whatCanBeClikedOn;
    [SerializeField] private LayerMask whatCanBeShootOn;
    [SerializeField] private NavMeshAgent myAgent;
    [SerializeField] private Text pontos;
    private int pontosNum;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        pontosNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClikedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }
            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeShootOn))
            {
               hitInfo.transform.gameObject.active = false;
                pontosNum++;
                pontos.text = "Pontos: " + pontosNum;
            }
        }
    }
}
