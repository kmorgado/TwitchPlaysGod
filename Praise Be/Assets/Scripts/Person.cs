using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Person : MonoBehaviour {

    public Image personImage;
    public float moveChancePct;
    
    public enum walkDirection
    {
        NORTH = 0,
        SOUTH = 1,
        WEST = 2,
        EAST = 3,
        STOP = 4        // This needs to stay the last
    }

    public walkDirection currentWalkDirection;

	// Use this for initialization
	void Start () {
        moveChancePct = 0.03f;
        currentWalkDirection = walkDirection.STOP;
	}
	
	// Update is called once per frame
	void Update () {
        MoveSmarter();
	}

    private void MoveSmarter()
    {
        // TODO: AVOID STRUCTURES AND STAY ON ISLAND
        if (Random.Range(0.0f, 1.0f) < moveChancePct)
            ChooseRandomDirection();

        Move();
    }

    private void Move()
    {
        RectTransform transform = (RectTransform)GetComponentInParent(typeof(RectTransform));

        switch (currentWalkDirection)
        {
            case walkDirection.NORTH:
                // Move up
                transform.Translate(new Vector3(0, -1, 0));
                break;
            case walkDirection.SOUTH:
                // Move down
                transform.Translate(new Vector3(0, 1, 0));
                break;
            case walkDirection.WEST:
                // Move left
                transform.Translate(new Vector3(-1, 0, 0));
                break;
            case walkDirection.EAST:
                // Move right
                transform.Translate(new Vector3(1, 0, 0));
                break;
        }

        if (!IsValidTransform())
        {
            switch (currentWalkDirection)
            {
                case walkDirection.NORTH:
                    // Move up
                    transform.Translate(new Vector3(0, 1, 0));
                    break;
                case walkDirection.SOUTH:
                    // Move down
                    transform.Translate(new Vector3(0, -1, 0));
                    break;
                case walkDirection.WEST:
                    // Move left
                    transform.Translate(new Vector3(1, 0, 0));
                    break;
                case walkDirection.EAST:
                    // Move right
                    transform.Translate(new Vector3(-1, 0, 0));
                    break;
            }

            currentWalkDirection = walkDirection.STOP;
        }
    }

    private void ChooseRandomDirection()
    {
        switch (currentWalkDirection)
        {
            case walkDirection.NORTH:
            case walkDirection.SOUTH:
                currentWalkDirection = (walkDirection)Random.Range((int)walkDirection.WEST, (int)walkDirection.STOP);
                break;
            case walkDirection.EAST:
            case walkDirection.WEST:
                if (Random.Range(0, 2) > 0)
                    currentWalkDirection = walkDirection.STOP;
                else
                    currentWalkDirection = (walkDirection)Random.Range((int)walkDirection.NORTH, (int)walkDirection.WEST);
                break;
            case walkDirection.STOP:
                currentWalkDirection = (walkDirection)Random.Range(0, (int)walkDirection.STOP);
                break;
        }
    }

    //
    private bool IsValidTransform()
    {
        return true;
    }
}
