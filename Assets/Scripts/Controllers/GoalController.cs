using UnityEngine;
using static Parameters;

public class GoalController : IUpdatable
{
    public static GoalController instance { get; set; }
    public bool GoalReached { get; private set; }

    public delegate void Action(ModuleObjectView[] viewArray);
    public event Action AbsorberColorChanged;
    public virtual void OnAbsorberColorChanged(ModuleObjectView[] viewArray)
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
    
    public void CheckGoal(ModuleObjectView[] modules)
    {
        int numberOfCorrect = 0;
        if (GoalReached) { return; }

        for(int i = 0; i < modules.Length; i++)
        {
            if (modules[i] == null || modules[i].Type != ModuleType.Absorber) 
            {
                Debug.LogError("This module type is not an absorber.");
                return;
            }
            if (modules[i].CheckTargetColor()) { numberOfCorrect++; }
        }
        if (numberOfCorrect != modules.Length) { Debug.Log($"{numberOfCorrect}/{modules.Length}"); }
        else { Debug.Log("GOAL REACHED"); GoalReached = true; }
    }

    public void Update() 
    { 
        // ??
    }
}

