using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerPawn PlayerPawn;

    public KeyCode teleportKey;

    public KeyCode moveforward;
    public KeyCode movebackward;
    public KeyCode rotateClockwise;
    public KeyCode rotateCounterClockwise;

    public KeyCode worldUp;
    public KeyCode worldDown;
    public KeyCode worldLeft;
    public KeyCode worldRight;

    public KeyCode shoot;

    public KeyCode turboIngaged; // Correctly defined as a KeyCode

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPawn != null)
        {
            if (Input.GetKeyDown(shoot))
            {
                //Pawn shoots a projectile
                PlayerPawn.Shoot();
            }

            if (Input.GetKeyDown(teleportKey))
            {
                // Teleport the player to a random position within the defined bounds
                PlayerPawn.TeleportToPosition();
            }
            if (!Input.GetKey(turboIngaged))
            {
                if (Input.GetKey(moveforward))
                {
                    // Move the player forward
                    PlayerPawn.MoveForward();
                }
                if (Input.GetKey(movebackward))
                {
                    // Move the player backward
                    PlayerPawn.MoveBackward();
                }
                if (Input.GetKey(rotateClockwise))
                {
                    // Rotate the player clockwise
                    PlayerPawn.RotateClockwise();
                }
                if (Input.GetKey(rotateCounterClockwise))
                {
                    // Rotate the player counter-clockwise
                    PlayerPawn.RotateCounterClockwise();
                }
            }
            else
            {
                if (Input.GetKey(moveforward))
                {
                    // Move the player forward
                    PlayerPawn.MoveForwardTurbo();
                }
                if (Input.GetKey(movebackward))
                {
                    // Move the player backward
                    PlayerPawn.MoveBackwardTurbo();
                }
                if (Input.GetKey(rotateClockwise))
                {
                    // Rotate the player clockwise
                    PlayerPawn.RotateClockwiseTurbo();
                }
                if (Input.GetKey(rotateCounterClockwise))
                {
                    // Rotate the player counter-clockwise
                    PlayerPawn.RotateCounterClockwiseTurbo();
                }
            }

            if (Input.GetKeyDown(worldUp))
            {
                // Move the world up
                PlayerPawn.MoveWorldUp();
            }

            if (Input.GetKeyDown(worldDown))
            {
                // Move the world down
                PlayerPawn.MoveWorldDown();
            }

            if (Input.GetKeyDown(worldLeft))
            {
                // Move the world left
                PlayerPawn.MoveWorldLeft();
            }

            if (Input.GetKeyDown(worldRight))
            {
                // Move the world right
                PlayerPawn.MoveWorldRight();
            }
        }
    }
}

