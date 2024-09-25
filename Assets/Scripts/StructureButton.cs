using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureButton : MonoBehaviour
{
    [SerializeField] private PlacementHandler placementHandler;
    [SerializeField] private GameObject structure;
    void Start(){
        if(placementHandler == null){
            placementHandler = FindAnyObjectByType<PlacementHandler>();
        }
        GetComponent<Button>().onClick.AddListener(setSelectedStructure);
    }

    void setSelectedStructure(){
        placementHandler.SelectedStructurePrefab = structure;
    } 
}
