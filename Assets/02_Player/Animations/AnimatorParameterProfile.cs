using System.Collections.Generic;
using UnityEngine;
public enum EAnimParam
{
    Walk,
    Jump,

}
[CreateAssetMenu(menuName = "UserMade/Animation/Animator Parameter Profile")]
public class AnimatorParameterProfile : ScriptableObject
{
    [System.Serializable]
    public struct Entry
    {
        public EAnimParam key;        // Enum Å°
        public AnimatorParameter parameter; // SO ÂüÁ¶
    }

    public Entry[] entries;
    private Dictionary<EAnimParam, AnimatorParameter> dict;

    void OnEnable()
    {
        dict = new Dictionary<EAnimParam, AnimatorParameter>();
        foreach (var e in entries)
        {
            dict[e.key] = e.parameter;
        }
    }

    public AnimatorParameter Get(EAnimParam key)
    {
        return dict.TryGetValue(key, out var param) ? param : null;
    }
}