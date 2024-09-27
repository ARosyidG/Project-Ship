using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask placementLayerMask;
    private Vector3 lastPotision;
    void Start(){
        if(_camera == null){
            _camera = Camera.main;
        }
    }
    public Vector3 getMouseMappedPosition(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        Ray _ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit raycastHit;
        if(Physics.Raycast(_ray,out raycastHit, placementLayerMask)){
            lastPotision = raycastHit.point;
        }
        return lastPotision;
    }
}
