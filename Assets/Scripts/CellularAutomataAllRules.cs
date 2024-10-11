using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularAutomataAllRules : MonoBehaviour
{
    public GameObject Ref;
    public int nbrOfRulesStart = 0;
    public int nbrOfRulesEnd = 100;
    public float CellSize = 1f;
    public int CellResolution = 16;
    public int2 GridSize = new int2(10, 20);
    public bool makeCellsStatRandom = false;

    private void InstantiateGrid()
    {
        int numberOfInstances = nbrOfRulesEnd - nbrOfRulesStart;
        float spacing = CellSize * 2f;

        for (int i = 0; i < numberOfInstances; i++)
        {
            // Instantiate the object
            GameObject clone = Instantiate(Ref, new Vector3(i * CellSize * GridSize.x + i*spacing, 0, 0), Quaternion.identity);
            clone.GetComponent<CellularAutomata>().Rule = i + nbrOfRulesStart;
            clone.GetComponent<CellularAutomata>().CellSize = CellSize;
            clone.GetComponent<CellularAutomata>().CellResolution = CellResolution;
            clone.GetComponent<CellularAutomata>().GridSize.x = GridSize.x;
            clone.GetComponent<CellularAutomata>().GridSize.y = GridSize.y;
            clone.GetComponent<CellularAutomata>().makeCellsStatRandom = makeCellsStatRandom;
            clone.gameObject.transform.parent = gameObject.transform;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InstantiateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
