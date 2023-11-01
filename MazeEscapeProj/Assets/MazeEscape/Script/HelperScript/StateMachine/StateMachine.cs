

using UnityEngine;

[CreateAssetMenu(fileName ="State Machine", menuName = "kg/StateMachine", order =0)]
public class StateMachine : ScriptableObject
{
    public State CurrentState => _currentState;
    private State _currentState;


    public void SetCurrentState(State newState)
    {
        _currentState = newState; 
    }
   
}
