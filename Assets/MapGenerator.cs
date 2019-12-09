using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Waypoint waypointPrefab; //our waypoint prefab
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Canvas canvas;
    public static List<Waypoint> path; //list to store our waypoints 

    //public (drag and drop other classes have direct object)
    //serialized field (other classes can't interact with it)

    public int sizeX;
    public int sizeY;
    public int turnPercent;
    private int[,] grid;
    public float heightOffset;

    // Start is called before the first frame update
    void Awake() //Awake happens before start //auto gen funcs are private by default?
    {
        //size x by y grid, start on the left of the grid. 
        //it can be anywhere on the left column, we end at the right of the grid.
        //you can only go up down or right.
        //grid
        //1 is the start point
        //2 is normal point
        //3 is an end point
        //4 is a tower placement slot

        grid = new int[sizeX, sizeY];
        path = new List<Waypoint>();
        int x = 0;
        int y = Random.Range(0, sizeY);
        grid[x, y] = 1;
        path.Add(Instantiate(waypointPrefab, new Vector3(x, findHeight(x, y), y),new Quaternion(), transform));
        path[0].index = 0;

        bool down = false;
        bool up = false;
        //when both are false we're moving right

        while (x < sizeX - 1)
        {
            //do we turn?
            if(Random.Range(0, 100) < turnPercent)
            {
                if(down || up) //what exactly does this mean?
                {
                    down = false;
                    up = false;
                }
                else
                {
                    if(Random.Range(0,2) == 0)
                    {
                        down = true;
                    }
                    else
                    {
                        up = true;
                    }
                }
            }
            //are we at the top or the bottom
            if (y == sizeY - 1)
            {
                up = false;
            }
            if (y == 0)
            {
                down = false;
            }

            //move in the direction we are facing
            if (!down && !up)
            {
                x++;
            }
            else if (down)
            {
                y--;
            }
            else if (up)
            {
                y++;
            }
            path.Add(Instantiate(waypointPrefab, new Vector3(x, findHeight(x, y), y), new Quaternion(), transform));
            path[path.Count - 1].index = path.Count;

            addTowerToGrid(x - 1, y - 1);
            addTowerToGrid(x + 1, y - 1);
            addTowerToGrid(x - 1, y + 1);
            addTowerToGrid(x + 1, y + 1);

            if(x == sizeX -1)
            {
                grid[x, y] = 3;
            }
            else
            {
                grid[x, y] = 2;
            }
            for(int i = 0; i < sizeX; i++)
            {
                for(int j = 0; j < sizeY; j++)
                {
                    if (grid[i, j] == 4)
                    {
                        Instantiate(buttonPrefab, new Vector3(i, findHeight(i,j), j), buttonPrefab.transform.rotation, canvas.transform);
                    }
                }
            }

        }
    }
    void addTowerToGrid(int indexX, int indexY)
    {
        if(indexX > 0 && indexY > 0 && indexX < sizeX -1 && indexY < sizeY -1 && grid[indexX,indexY] ==0)
        {
            grid[indexX, indexY] = 4;
        }
    }

    float findHeight(float x, float y)
    {
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(x, 0, y), new Vector3(0, -1, 0), out hit))
        {
            return hit.point.y + heightOffset;
        }
        else
        {
            return heightOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
