using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PositioningConstraint : MonoBehaviour
{
    
    
    public Material hoverMaterial;
    public Material selectedMaterial;
    public Material notHoveredMaterial;
    public GameObject rightController;
    public GameObject originalParent;
    
    private bool _selected = false;
    private bool _hovered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) != 0.0f && (_hovered || _selected))
        {
            GetComponent<Renderer>().material = selectedMaterial;
            _selected = true;
            
            var rightControllerPosition = rightController.transform.position;
            var tableXMaxBounds = originalParent.GetComponent<Renderer>().bounds.max;
            var tableMinBounds = originalParent.GetComponent<Renderer>().bounds.min;
            var boxHalfSize = GetComponent<Renderer>().bounds.size /2; 

            if (rightControllerPosition.x < (tableXMaxBounds.x - boxHalfSize.x) &&
                rightControllerPosition.x > (tableMinBounds.x + boxHalfSize.x))
            {
                if (rightControllerPosition.z < (tableXMaxBounds.z - boxHalfSize.z) &&
                    rightControllerPosition.z > (tableMinBounds.z + boxHalfSize.z))
                {
                    GetComponent<Rigidbody>().transform.position = new Vector3(rightControllerPosition.x, transform.position.y,
                        rightControllerPosition.z);
                }
                else
                {
                    GetComponent<Rigidbody>().transform.position = new Vector3(rightControllerPosition.x, transform.position.y,
                        transform.position.z);
                }
                
            }
            else
            {
                if (rightControllerPosition.z < (tableXMaxBounds.z - boxHalfSize.z) &&
                    rightControllerPosition.z > (tableMinBounds.z + boxHalfSize.z))
                {
                    GetComponent<Rigidbody>().transform.position = new Vector3(transform.position.x, transform.position.y,
                        rightControllerPosition.z);
                }
            }
                       
           
        }
        else
        {
            _selected = false;
            if (!_hovered)
            {
                GetComponent<Renderer>().material = notHoveredMaterial;
            }
            else
            {
                
                GetComponent<Renderer>().material = hoverMaterial;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("GameController")) return;
        GetComponent<Renderer>().material = hoverMaterial;
        _hovered = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("GameController")) return;
        _hovered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("GameController")) return;
        _hovered = false;
        if(!_selected)
            GetComponent<Renderer>().material = notHoveredMaterial;
    }
}