using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class AnimationController :MonoBehaviour
{
    [SerializeField] private AnimatorParameterSet paramSet;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Move(bool value)
    {
        paramSet.Set(EAnimParam.Walk, value);
    }
    public void Jump()
    {
        paramSet.Set(EAnimParam.Jump);
    }
}
