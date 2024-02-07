using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformCreation : MonoBehaviour
{
    Tilemap tm;

    [HideInInspector]
    public float[] locationX = new float[3];
    [HideInInspector]
    public float[] locationY = new float[3];
    [HideInInspector]
    public float[] widths = new float[3];
    int listNum = 2;

    int countertest = 3;


    //can go 7 wide at anything lower 
    //can go 6 wide at -1, -2, and -3 height 
    //can go 5 wide at 0 and 1 height
    //can go 4 wide at 2 height

    // -5 is the bottom
    // 3 is the top

    Vector3Int curPlatform;
    Vector2Int newPlatform;
    Vector3Int place;

    //public TileBase[] tiles;

    public TileBase tile1;
    public TileBase tile2;
    public TileBase tile3;
    public GameObject thePlayer;
    int trigger = -6;
    int howWidth;
    int howHigh;

    // Start is called before the first frame update
    void Start()
    {
        
        tm = GetComponent<Tilemap>();
        curPlatform = new Vector3Int(6, -2, 0);
        //tile1.GetTileData();

        locationX[0] = -10;
        locationX[1] = -3;
        locationX[2] = 4;

        locationY[0] = -2;
        locationY[1] = -2;
        locationY[2] = -2;

        widths[0] = 3;
        widths[1] = 3;
        widths[2] = 3;

        /*
        locations.Add(new Vector3(-10, -2, 0));
        locations.Add(new Vector3(-3, -2, 0));
        locations.Add(new Vector3(4, -2, 0));

        widths.Add(3);
        widths.Add(3);
        widths.Add(3); */

        
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.transform.position.x > trigger)
        {
            addPlatform();
        }
    }

    void addPlatform()
    {
        // up or down
        int blerg = (int)Random.Range(0, 3);

        // how much down
        if (blerg < 1)
        {
            howHigh = (int)Random.Range(curPlatform.y - 4, curPlatform.y);
            //howHigh = (int)Random.Range(Mathf.Max(curPlatform.y - 8, -5), curPlatform.y);
        }
        // how much up
        else
        {
            howHigh = (int)Random.Range(curPlatform.y + 2, curPlatform.y);
            //howHigh = (int)Random.Range(Mathf.Min(curPlatform.y + 2, 3), curPlatform.y);
        }

        // how wide depending on which row
        if (curPlatform.y - howHigh == -2)
        {
            newPlatform = new Vector2Int((int)Random.Range(curPlatform.x + 2, curPlatform.x + 5), howHigh);
        }
        else if (curPlatform.y - howHigh <= 0)
        {
            newPlatform = new Vector2Int((int)Random.Range(curPlatform.x + 2, curPlatform.x + 6), howHigh);
        }
        else if (curPlatform.y - howHigh <= 3)
        {
            newPlatform = new Vector2Int((int)Random.Range(curPlatform.x + 2, curPlatform.x + 7), howHigh);
        }
        else
        {
            newPlatform = new Vector2Int((int)Random.Range(curPlatform.x + 2, curPlatform.x + 8), howHigh);
        }

        // sets a vector for the new platform
        place = new Vector3Int(newPlatform.x, newPlatform.y, 0);


        trigger += howWidth + newPlatform.x - curPlatform.x;
        //place first tile
        tm.SetTile(place, tile1);

        // how wide the platform
        howWidth = (int)Random.Range(0, 3);

        // place middle tiels based on width 
        for (int i = 0; i < howWidth; i++)
        {
            place.x += 1;
            tm.SetTile(place, tile2);
        }

        place.x += 1;

        // place last tile 
        tm.SetTile(place, tile3);

        //updates leading platform
        curPlatform = place;

        // moves the trigger the right amount forward


        //trigger += 10;





        // this adds adds info to arrays


        // makes temp arrays one larger 
        float[] tempX = new float[listNum + 2];
        float[] tempY = new float[listNum + 2];
        float[] tempW = new float[listNum + 2];

        //puts norm info on temp arrays
        for (int i = 0; i <= listNum; i++)
        {
            tempX[i] = locationX[i];
            tempY[i] = locationY[i];
            tempW[i] = widths[i];
        }

        //adds new info to temp array
        tempX[listNum + 1] = place.x - howWidth;
        tempY[listNum + 1] = place.y;
        tempW[listNum + 1] = howWidth + 2;

        // copies temp array to norm array
        locationX = tempX;
        locationY = tempY;
        widths = tempW;
 


        listNum++;
    }
}

