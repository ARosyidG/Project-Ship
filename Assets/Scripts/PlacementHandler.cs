using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject tileOrigin;
    [SerializeField] private GameObject m_activeFloor;
    public GameObject ActiveFloor{
        set{
            m_activeFloor = value;
            grid = m_activeFloor.transform.Find("Grid").GetComponent<Grid>();
            mouseIndicator = grid.transform.Find("MouseIndicator").gameObject;
            tileOrigin = mouseIndicator.transform.Find("Tile Origin").gameObject;
        }
        get{
            return m_activeFloor;
        }
    }
    [SerializeField] private GameObject m_selectedStructurePrefab;
    void Start(){
        ActiveFloor = m_activeFloor;
    }
    public GameObject SelectedStructurePrefab{
        set{
            m_selectedStructurePrefab = value;
            if (value == null){
                if(PlacingCoroutine != null) StopCoroutine(PlacingCoroutine);
                grid.gameObject.SetActive(false);
            }else{
                PlacingCoroutine = StartCoroutine(PlacingStructure());
            }
        }
        get{
            return m_selectedStructurePrefab;
        }
    }
    Coroutine PlacingCoroutine;
    [SerializeField] GameObject testObject;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            this.SelectedStructurePrefab = testObject;
        }
        if(Input.GetKeyDown(KeyCode.W)){
            this.SelectedStructurePrefab = null;
        }
    }

    IEnumerator PlacingStructure(){
        grid.gameObject.SetActive(true);
        m_selectedStructurePrefab = Instantiate(m_selectedStructurePrefab,tileOrigin.transform);
        while (true)
        {
            Vector3 mousePos = inputManager.getMouseMappedPosition();
            Vector3Int mousePosInGrid = grid.WorldToCell(mousePos);
            mouseIndicator.transform.position = grid.CellToWorld(mousePosInGrid);
            Debug.Log("Placing...");
            if(Input.GetMouseButtonDown(0)){
                bool isPlaceable = validatePlacement();
                if(isPlaceable){
                    SelectedStructurePrefab.transform.SetParent(ActiveFloor.transform);
                    SelectedStructurePrefab = null;
                    yield return new WaitForEndOfFrame();        
                }
            }
            yield return null;
        }
    }

    private bool validatePlacement()
    {
        return true;
    }
}
