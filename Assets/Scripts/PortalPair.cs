using UnityEngine;

public class PortalPair
{
    public PortalView View;

    public Transform TransformOne;
    public Transform TransformTwo;

    public Vector2Int TileOne;
    public Vector2Int TileTwo;

    public PortalPair(PortalView view, Vector2Int tile1, Vector2Int tile2)
    {
        View = view;

        TransformOne = View.gameObject.transform.Find(Parameters.PORTAL1_NAME).transform;
        TransformTwo = View.gameObject.transform.Find(Parameters.PORTAL2_NAME).transform;

        TileOne = tile1;
        TileTwo = tile2;
    }
    public void MovePortalOne(Vector2Int tilePos)
    {
        TileObjectView tile = Parameters.GetLevel().Tiles[tilePos];
        TransformOne.position = new Vector3(tile.Transform.position.x, TransformOne.position.y, tile.Transform.position.z);
        TileOne = tilePos;
    }    
    public void MovePortalTwo(Vector2Int tilePos)
    {
        TileObjectView tile = Parameters.GetLevel().Tiles[tilePos];
        TransformTwo.position = new Vector3(tile.Transform.position.x, TransformTwo.position.y, tile.Transform.position.z);
        TileTwo = tilePos;
    }
}