
using UnityEngine;
using UnityEngine.UI;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    Cell[,] cells;
    public int NumberOfColloms, NumberOfRows;
    public float cellSize = 0.28f;
    public float spawnChanceproc = 15;
    bool[,] nextState;
    
    
    //public InputField Cellsize;



    void Start()
    {


        
        NumberOfColloms = (int)Mathf.Floor((Camera.main.orthographicSize * Camera.main.aspect * 2) / cellSize);
        NumberOfRows = (int)Mathf.Floor(Camera.main.orthographicSize * 2 / cellSize);

        cells = new Cell[NumberOfColloms, NumberOfRows];
        nextState = new bool[NumberOfColloms, NumberOfRows];

        for (int y = 0; y < NumberOfRows; y++)
        {
            //for each column in each row
            for (int x = 0; x < NumberOfColloms; x++)
            {
                //Create our game cell objects, multiply by cellSize for correct world placement
                Vector2 newPos = new Vector2(x * cellSize - Camera.main.orthographicSize * Camera.main.aspect,
                    y * cellSize - Camera.main.orthographicSize);

                var newCell = Instantiate(cellPrefab, newPos, Quaternion.identity);
                newCell.transform.localScale = Vector2.one * cellSize;
                cells[x, y] = newCell.GetComponent<Cell>();

                //Random check to see if it should be alive
                if (Random.Range(0, 100) < spawnChanceproc)
                {
                    cells[x, y].alive = true;
                }

                cells[x, y].UpdateStatus();
            }
        }
    }




    void Update()
    {

        for (int y = 0; y < NumberOfRows; y++)
        {
            for (int x = 0; x < NumberOfColloms; x++)
            {
                // Check the neighbors of grid[x, y] (left, right, top, bottom, diagonals)
                int liveNeighbors = 0;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0) continue;
                        // Skip the cell itself
                        
                        int neighborX = x + j;
                        int neighborY = y + i;

                        // Make sure the neighbor is within bounds
                        if (neighborX >= 0 && neighborX < NumberOfColloms && neighborY >= 0 && neighborY < NumberOfRows)
                        {
                            if (cells[neighborX, neighborY].alive)
                            {
                                liveNeighbors++;
                            }
                        }



                    }
                }

                if (cells[x, y].alive && (liveNeighbors < 2 || liveNeighbors > 3))
                {

                    nextState[x, y] = false;

                }

                else if (cells[x, y].alive == false && liveNeighbors == 3)
                {

                    nextState[x, y] = true;
                }

                else
                {

                    nextState[x, y] = cells[x,y].alive;


                }



            }
        }


        for (int y = 0; y < NumberOfRows; y++)
        {

            for (int x = 0; x < NumberOfColloms; x++)
            {


             
                cells[x, y].alive = nextState[x, y];
                cells[x, y].UpdateStatus();
            }
        }

    }
}
