using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustMoveSpeed = 3f;

    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        levelGenerator.changeChunkMoveSpeed(adjustMoveSpeed);
        Debug.Log("Power Up!");
    }
}
