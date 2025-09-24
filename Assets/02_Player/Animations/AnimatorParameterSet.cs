using UnityEngine;

public class AnimatorParameterSet : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorParameterProfile profile;

    public void Set(EAnimParam key, object value = null)
    {
        var param = profile.Get(key);
        if (param == null) return;

        switch (param.type)
        {
            case AnimatorParameterType.Trigger:
                animator.SetTrigger(param.Hash);
                break;
            case AnimatorParameterType.Bool:
                animator.SetBool(param.Hash, (bool)value);
                break;
            case AnimatorParameterType.Float:
                animator.SetFloat(param.Hash, (float)value);
                break;
            case AnimatorParameterType.Int:
                animator.SetInteger(param.Hash, (int)value);
                break;
        }
    }
}