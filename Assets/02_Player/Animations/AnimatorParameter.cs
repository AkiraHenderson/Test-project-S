using UnityEngine;


public enum AnimatorParameterType
{
    Trigger,
    Bool,
    Float,
    Int
}

[CreateAssetMenu(fileName = "AnimatorParameter", menuName = "UserMade/Animation/Animator Parameter")]
public class AnimatorParameter : ScriptableObject
{
    public AnimatorParameterType type;
    public string parameterName;   // Animator �Ķ���� �̸�
    private int _hash;

    public int Hash
    {
        get
        {
            if (_hash == 0)
            {
                _hash = Animator.StringToHash(parameterName);
            }
            return _hash;
        }
    }
}
