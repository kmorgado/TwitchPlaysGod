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
                    currentWalkDirection = walkDirection.SOUTH;
                    break;
                case walkDirection.SOUTH:
                    // Move down
                    transform.Translate(new Vector3(0, -1, 0));
                    currentWalkDirection = walkDirection.NORTH;
                    break;
                case walkDirection.WEST:
                    // Move left
                    transform.Translate(new Vector3(1, 0, 0));
                    currentWalkDirection = walkDirection.EAST;
                    break;
                case walkDirection.EAST:
                    // Move right
                    transform.Translate(new Vector3(-1, 0, 0));
                    currentWalkDirection = walkDirection.WEST;
                    break;
            }
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
        GameObject checker = GameObject.Find("IslandBounds");

        if (checker == null)
        {
            Debug.Log("No IslandBounds");
            return false;
        }

        PolygonCollider2D islandCollider = checker.GetComponent<PolygonCollider2D>();
        Collider2D personCollider = GetComponent<Collider2D>();

        if (islandCollider == null)
        {
            Debug.Log("No Island Collider");
            return false;
        }
        if (personCollider == null)
        {
            Debug.Log("No Person Collider");
            return false;
        }

        // Ok, so we have colliders, lets see if they are touching
        bool onIsland = islandCollider.IsTouching(personCollider);
        bool touchingBuildings = personCollider.IsTouchingLayers(LayerMask.NameToLayer("Buildings"));
        Debug.Log(string.Format("OnIsland: {0}", onIsland ? "TRUE" : "FALSE"));
        Debug.Log(string.Format("buildings: {0}", touchingBuildings ? "*******TOUCH*******" : "Empty"));
        Debug.Log(string.Format("curDirection: {0}", currentWalkDirection.ToString()));
        return onIsland && !touchingBuildings;
    }
}
