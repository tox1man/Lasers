using UnityEngine;

public class TileObjectView : GameObjectView
{
    [Range(0.1f,  1f)] public float WaveAmplitude;
    [Range(0.1f, 10f)] public float Frequency;
    [Range(-32f, 32f)] public float Elevation = 0;
    private bool elevated;
    private float elevationAmount;
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
                elevationAmount = Parameters.GetRoot().CurrentStage.Level.GridSize;

                Elevation = value ? Elevation + elevationAmount : Elevation - elevationAmount;
                elevated = value;
            }
        } 
    }
    public float Phase;
    public Vector2Int Coordinates { get; set; }
}
