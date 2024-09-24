using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] private Grid grid;
    

    void Update(){
        Vector3 mousePos = inputManager.getMouseMappedPosition();
        Vector3Int mousePosInGrid = grid.WorldToCell(mousePos);
        mouseIndicator.transform.position = grid.CellToWorld(mousePosInGrid);
    }
    
}
