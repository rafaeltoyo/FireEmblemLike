using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class MapController : MonoBehaviour
{
    private Grid mapGrid;

    [SerializeField]
    private List<CharacterData> players = new List<CharacterData>();

    [SerializeField]
    private List<CharacterData> enemies = new List<CharacterData>();

    void Awake()
    {
        mapGrid = GetComponent<Grid>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (CharacterData player in players)
        {
            Debug.Log(player.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
