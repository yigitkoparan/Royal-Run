using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustMoveSpeed = 3f;
    [SerializeField] AudioSource audioSource;

    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        levelGenerator.changeChunkMoveSpeed(adjustMoveSpeed);
        AudioSource.PlayClipAtPoint(audioSource.clip,transform.position);
    }
}
