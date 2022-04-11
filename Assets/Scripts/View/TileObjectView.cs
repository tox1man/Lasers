using UnityEngine;

public class TileObjectView : GameObjectView
{
    [Range(0.1f,  1f)] public float WaveAmplitude;
    [Range(0.1f, 10f)] public float Frequency;
    [Range(-32f, 32f)] public float Elevation = 0;
    private bool elevated;
    public bool Elevated 
    { 
        get { return elevated; } 
        set 
        {
            if (elevated == value) 
            {
                return;
            }
            else
            {
                Elevation = value ? Elevation + 1f : Elevation - 1f;
                elevated = value;
            }
        } 
    }
    public float Phase;
    public Vector2Int Coordinates { get; set; }
}
