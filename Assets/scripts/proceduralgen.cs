using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralgen : MonoBehaviour

{
    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tile_groups;
    public GameObject prfb_stone;
    public GameObject prfb_grass2;
    public GameObject grass;
    public GameObject water;
    public GameObject ore_1;
 

    public float noiseFreq = 0.5f;
    public float seed;

    public int map_width = 160;
    public int map_height = 90;
    //public int chunkSize = 16;

    //private GameObject[] worldChunks;
 
    //[Header("BiomeMap")]
    //public float biomeFreq;
    //public Gradient biomeColors;
    //public Texture2D biomeMap;


    List<List<int>> noise_grid = new List<List<int>>();
    List<List<GameObject>> tile_grid = new List<List<GameObject>>();
 
    // recommend 4 to 20
    float magnification = 7.0f;
 
    int x_offset = 0; // <- +>
    int y_offset = 0; // v- +^
 
    void Start()
    {
        seed = Random.Range(-100000, 100000);

        CreateTileset();
        CreateTileGroups();
        GenerateMap();
        //CreateChunks();
        //DrawBiome();
    }

    //public void CreateChunks()
    //  int numChunks = map_width / chunkSize;
        //worldChunks = new GameObject[numChunks];
        //for (int i = 0; i < numChunks; i++)
        //{
        //    GameObject newChunk = new GameObject(name = i.ToString());
        //    newChunk.name = i.ToString();
        //    newChunk.transform.parent = this.transform;
        //    worldChunks[i] = newChunk;
        //}
    //}

    //public void DrawBiome()
    //{
        //for (int x = 0; x < biomeMap.width; x++)
        //{
            //for (int y = 0; y < biomeMap.width; y++)
            //{
                //float v = Mathf.PerlinNoise((x + seed) * biomeFreq, (y + seed) * biomeFreq);
                //Color col = biomeColors.Evaluate(v);
                //biomeMap.SetPixel(x, y, col);
            //}
        //}
        //biomeMap.Apply();
    //}
 
    void CreateTileset()
    {
        /** Collect and assign ID codes to the tile prefabs, for ease of access.
            Best ordered to match land elevation. **/
 
        tileset = new Dictionary<int, GameObject>();
        tileset.Add(0, prfb_stone);
        tileset.Add(1, prfb_grass2);
        tileset.Add(2, grass);
        tileset.Add(3, water);
        tileset.Add(4, ore_1);
    }
 
    void CreateTileGroups()
    {
        /** Create empty gameobjects for grouping tiles of the same type, ie
            forest tiles **/
 
        tile_groups = new Dictionary<int, GameObject>();
        foreach(KeyValuePair<int, GameObject> prefab_pair in tileset)
        {
            GameObject tile_group = new GameObject(prefab_pair.Value.name);
            tile_group.transform.parent = gameObject.transform;
            tile_group.transform.localPosition = new Vector3(0, 0, 0);
            tile_groups.Add(prefab_pair.Key, tile_group);
        }
    }
 
    void GenerateMap()
    {
        /** Generate a 2D grid using the Perlin noise fuction, storing it as
            both raw ID values and tile gameobjects **/
 
        for(int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<int>());
            tile_grid.Add(new List<GameObject>());
 
            for(int y = 0; y < map_height; y++)
            {
                int tile_id = GetIdUsingPerlin(x, y);
                noise_grid[x].Add(tile_id);
                CreateTile(tile_id, x, y);
            }
        }
    }
 
    int GetIdUsingPerlin(int x, int y)
    {
        /** Using a grid coordinate input, generate a Perlin noise value to be
            converted into a tile ID code. Rescale the normalised Perlin value
            to the number of tiles available. **/
 
        float raw_perlin = Mathf.PerlinNoise(
            (x + x_offset + seed) * noiseFreq / magnification,
            (y + y_offset + seed) * noiseFreq / magnification
        );
        float clamp_perlin = Mathf.Clamp01(raw_perlin); // Thanks: youtu.be/qNZ-0-7WuS8&lc=UgyoLWkYZxyp1nNc4f94AaABAg
        float scaled_perlin = clamp_perlin * tileset.Count;
 
        // Replaced 4 with tileset.Count to make adding tiles easier
        if(scaled_perlin == tileset.Count)
        {
            scaled_perlin = (tileset.Count - 1);
        }
        return Mathf.FloorToInt(scaled_perlin);
    }
 
    void CreateTile(int tile_id, int x, int y)
    {
        /** Creates a new tile using the type id code, group it with common
            tiles, set it's position and store the gameobject. **/

        GameObject tile_prefab = tileset[tile_id];
        GameObject tile_group = tile_groups[tile_id];
        GameObject tile = Instantiate(tile_prefab, tile_group.transform);
 
        tile.name = string.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, 0);
 
        tile_grid[x].Add(tile);
    }

}