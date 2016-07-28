using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour {

    public enum Death { OutofBounds, BodyCollision }
    private enum Direction { Up, Down, Left, Right }

    public int currentScore { get; private set; }
    public float speed;
    private Direction currentDirection = Direction.Up;

    private Transform head;
    private Transform body;

    public GameController gameController;
    public GameObject bodyPart;

    void Start()
    {
        head = transform.FindChild("Head");
        body = transform.FindChild("Body");

        speed = GetSpeed(GameSettings.difficulty);
        HandleMovement();
    }

    void Update()
    {
        HandleDirectionChange();

        if (CheckHeadBodyCollision())
        {
            gameController.PlayerDead(this, Death.BodyCollision);
        }
        else if (CheckHeadOutofBounds())
        {
            gameController.PlayerDead(this, Death.OutofBounds);
        }
    }

    void HandleMovement()
    {
        // TODO: Increase body by X allocate X in 1 block
        IncreaseBody(currentDirection);

        Fruit fruitCaught = gameController.fruitManager.CheckCaughtFruit(head.position);

        if (fruitCaught)
        {
            currentScore += fruitCaught.gainScore;
            gameController.FruitCaught(fruitCaught);
        }
        else
        {
            Destroy(GetButt().gameObject);
        }

        Invoke("HandleMovement", 1 / speed);
    }

    float GetSpeed(Difficulty difficulty)
    {
        float coef = (int)difficulty + 1;
        return coef * 10;
    }

    Transform GetNeck()
    {
        if (body.childCount == 0)
            return head;

        return body.GetChild(0);
    }

    Transform GetButt()
    {
        if (body.childCount == 0)
            return head;

        return body.GetChild(body.childCount - 1);
    }

    Vector3 DirectionToVector(Direction dir)
    {
        float xOffset = 0, yOffset = 0;

        switch (currentDirection)
        {
            case Direction.Left:
                xOffset = -1;
                break;
            case Direction.Right:
                xOffset = 1;
                break;
            case Direction.Up:
                yOffset = 1;
                break;
            case Direction.Down:
                yOffset = -1;
                break;
        }

        return new Vector3(xOffset, yOffset);
    }

    void HandleDirectionChange()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 headPos = head.position;
        Vector3 neckPos = transform.childCount < 1 ? headPos : GetNeck().position;

        if (horizontal >= 1 && headPos.x >= neckPos.x)
            currentDirection = Direction.Right;
        else if (horizontal <= -1 && headPos.x <= neckPos.x)
            currentDirection = Direction.Left;
        else if (vertical >= 1 && headPos.y >= neckPos.y)
            currentDirection = Direction.Up;
        else if (vertical <= -1 && headPos.y <= neckPos.y)
            currentDirection = Direction.Down;
    }

    bool CheckHeadBodyCollision()
    {
        Transform deadBlock = gameController.playerManager
                                            .GetAllPlayersOccupiedBlocks()
                                            .FirstOrDefault(b => b != head && b.position == head.position);
        return deadBlock != null;
    }

    bool CheckHeadOutofBounds()
    {
        Vector3 point = Camera.main.WorldToViewportPoint(head.position);

        return point.x < 0 || point.x > 1 || point.y < 0 || point.y > 1;
    }

    void IncreaseBody(Direction dir)
    {
        Vector3 newHeadPos = head.position + DirectionToVector(currentDirection) * GameSettings.gridUnit;
        GameObject neckObj = Instantiate(bodyPart, newHeadPos, Quaternion.identity) as GameObject;
        Transform neck = neckObj.transform;

        neck.SetParent(body);
        neck.position = head.position;
        head.position = newHeadPos;
        neck.SetSiblingIndex(0);
    }

    public IEnumerable<Transform> GetOccupiedBlocks()
    {
        yield return head;

        foreach (Transform bodyPart in body)
            yield return bodyPart;
    }

}
