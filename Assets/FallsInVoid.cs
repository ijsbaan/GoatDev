using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallsInVoid : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    private PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 closestTileWorldPosition = FindClosestTileWorldPosition(tilemap, collision.transform.position);
            playerMovement = collision.GetComponent<PlayerMovement>(); 
            StartCoroutine(TeleportToClosestTile(closestTileWorldPosition, collision.transform));
        }
    }

    private Vector3 FindClosestTileWorldPosition(Tilemap tilemap, Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);

        // Check if the initial tile is not null
        if (tilemap.HasTile(cellPosition))
        {
            return tilemap.CellToWorld(cellPosition) + tilemap.cellSize / 2; // Adjust position to the center of the tile
        }

        // Search in surrounding cells for the closest tile using Euclidean distance
        float closestDistance = float.MaxValue;
        Vector3 closestTileWorldPosition = worldPosition;
        int searchRadius = 1;

        while (true)
        {
            bool found = false;
            for (int x = -searchRadius; x <= searchRadius; x++)
            {
                for (int y = -searchRadius; y <= searchRadius; y++)
                {
                    Vector3Int testPosition = cellPosition + new Vector3Int(x, y, 0);
                    if (tilemap.HasTile(testPosition))
                    {
                        Vector3 testTileWorldPosition = tilemap.CellToWorld(testPosition) + tilemap.cellSize / 2;
                        float distance = Vector3.Distance(worldPosition, testTileWorldPosition);
                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            closestTileWorldPosition = testTileWorldPosition;
                            found = true;
                        }
                    }
                }
            }

            if (found) break;
            searchRadius++;
        }

        return closestTileWorldPosition;
    }

    private IEnumerator TeleportToClosestTile(Vector3 closestTile, Transform player)
    {
        playerMovement.canMove = false;

        yield return new WaitForSeconds(0.5f);

        player.position = closestTile;

        playerMovement.canMove = true;
    }
}
