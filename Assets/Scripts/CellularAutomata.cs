using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularAutomata : MonoBehaviour
{
    public float CellSize = 1f;
    public int CellResolution = 16;
    public int2 GridSize = new int2(10, 20);
    public bool isChanged = true;
    public int Rule = 30;

    // a grid where we will store our matrice of Cells
    private List<MyCell<bool>> Grid;
    public bool makeCellsStatRandom = false;
    public float ProbabilityOfItAlive = 0.1f;
    // Ectra variabke cause we have a plan so the 1 in plan is not really one in the world size 
    private int originalSize = 10;
    public List<bool> theRuleInBin;

    private Texture2D texture;

    private int getNbrOfIndex(int positionInList)
    {
        int output = 0;
        int k = 0;
        for(int i = 2; i >= 0;i--,k++)
        {
            int positionIndex = ((i + positionInList - 1) + GridSize.x) % GridSize.x;
            if (Grid[positionIndex].wasAlive)
            {
                output += (int)Mathf.Pow(2, k);
            }
        }
        return output;
    }

    private bool Rules(int stat)
    {
        return theRuleInBin[stat];
    }

    void Start()
    {
        InitializeGrid(!makeCellsStatRandom);
        setUpGrid();
    }

    // function finished and i think the position are correct [Finished]
    private void setUpGrid()
    {
        gameObject.transform.localScale = new Vector3((CellSize * GridSize.x) / originalSize, 1f, (CellSize * GridSize.y) / originalSize);

        // Create a new texture with the specified width and height
        texture = new Texture2D(GridSize.x * CellResolution, GridSize.y * CellResolution);

        // Set alternating colors for each pixel
        for (int x = 0; x < GridSize.x; x++)
        {
            DrowCell(x, GridSize.y - 1, Color.black);
            if (Grid[x].isAlive)
            {
                DrowCell(x, GridSize.y - 1, Color.white);
                //Debug.Log("Cell alive in position [ " + y + " ][ " + x + " ]");
            }
        }
        texture.Apply();
        GetComponent<Renderer>().material.mainTexture = texture;

    }

    // Function is [Finished]
    private void DrowAllFromGrid()
    {
        for (int j = 0; j < GridSize.y; j++)
        {
            for (int i = 0; i < GridSize.x; i++)
            {
                DrowCell(i, j, Color.black);
                Grid[i].wasAlive = Grid[i].isAlive;
                if (Grid[i].isAlive && j== GridSize.y - 1)
                {
                    DrowCell(i, j, Color.white);
                }
            }
        }
    }

    // this function is corrected . still need to add code
    private void ChangeToNextStat()
    {
        for (int j = GridSize.y - 1; j >= 0; j--)
        {
            for (int i = 0; i < GridSize.x; i++)
            {
                Grid[i].isAlive = Rules(getNbrOfIndex(i));
                //Debug.Log("Line [ " + j +" ] ,The position : [ " + i + " ] = the index is : " + getNbrOfIndex(i));
                DrowCell(i, j, Color.black);
                if (Grid[i].wasAlive)
                {
                    DrowCell(i, j, Color.white);
                }
            }
            for (int i = 0; i < GridSize.x; i++)
            {
                Grid[i].SetVisibility(Grid[i].isAlive);
            }
        }
        // do the frst one
        texture.Apply();
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    // function is finished [Finished]
    private void DrowCell(int i, int j, Color theColor)
    {
        for (int k = 0; k < CellResolution; k++)
        {
            for (int w = 0; w < CellResolution; w++)
            {
                texture.SetPixel(i * CellResolution + k, j * CellResolution + w, theColor);

            }
        }
    }

    // this function i think is almost finished [Finished]
    private void InitializeGrid(bool randomOrNot = false)
    {
        theRuleInBin = new List<bool>();
        int tmp = Rule;
        for (int i = 0; i < 8; i++)
        {
            theRuleInBin.Add(tmp % 2 == 1);
            tmp = tmp / 2;
        }

        Grid = new List<MyCell<bool>>();
        for (int i = 0; i < GridSize.x; i++) { 
            MyCell<bool> cellObject = new MyCell<bool>(false);
            Grid.Add(cellObject);
        }

        if (randomOrNot)
        {
            SetRandomAliveCells();
        }
        else
        {
            Grid[GridSize.x / 2].SetVisibility(true);
        }
    }

    // function [Finished]
    private void SetRandomAliveCells()
    {
        int totalCells = GridSize.x;
        int aliveCellsCount = Mathf.FloorToInt(totalCells * ProbabilityOfItAlive);

        HashSet<int> selectedIndices = new HashSet<int>();

        while (selectedIndices.Count < aliveCellsCount)
        {
            int randomIndex = Random.Range(0, totalCells);
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
                Grid[randomIndex].SetVisibility(true);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isChanged)
        {
            setUpGrid();
            ChangeToNextStat();
            isChanged = false;
        }
    }
}
