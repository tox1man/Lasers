using UnityEngine;
using static Parameters;

public class GoalController : IUpdatable
{
    public static GoalController instance { get; set; }
    public bool GoalReached { get; private set; }

    public delegate void Action(AbsorberView[] viewArray);
    public event Action AbsorberColorChanged;
    public virtual void OnAbsorberColorChanged(AbsorberView[] viewArray)
    {
        AbsorberColorChanged?.Invoke(viewArray);
    }

    public GoalController()
    {
        if (instance != null)
        {
            Debug.LogWarning(this + " instance already exists. Cant make multiple instances of " + this);
        }
        instance = this;

        AbsorberColorChanged += CheckGoal;
    }
    
    public void CheckGoal(AbsorberView[] absorbers)
    {
        int numberOfCorrect = 0;
        if (GoalReached) { return; }

        for(int i = 0; i < absorbers.Length; i++)
        {
            if (absorbers[i] == null || absorbers[i].Type != ModuleType.Absorber) 
            {
                Debug.LogError("This module type is not an absorber.");
                return;
            }
            if (absorbers[i].CheckTargetColor()) { numberOfCorrect++; }
        }
        if (numberOfCorrect != absorbers.Length) { Debug.Log($"{numberOfCorrect}/{absorbers.Length}"); }
        else { Debug.Log("GOAL REACHED"); GoalReached = true; }
    }

    public void Update() 
    { 
        // ??
    }
}

