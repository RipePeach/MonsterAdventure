using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapClicker : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Tilemap map;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private TileBase _tileBase;
    // Start is called before the first frame update
    void Start()
    {
        map = GetComponent<Tilemap>();
        mainCamera = Camera.main;
    }
     

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // позиция клика в мировых коорд.
            Vector3 clickWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
            
            // получить координаты тайла и перевести в мировые координаты
            Vector3Int  clickCellPosition = map.WorldToCell(clickWorldPosition);
            
            player.position = map.CellToWorld(clickCellPosition);
        }
    }
}
