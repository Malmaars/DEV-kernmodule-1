﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IMoveable, ISpawnable
{
    public Vector3 _direction;

    public void SpawnTo(Coordinate spawnPoint)
    {

    }

    public void MoveActor(GameObject actor, Vector3 newDirection, List<Coordinate> possibleMoves)
    {
        if (newDirection != null)
        {
            Vector2 originalDirectionFuture = actor.transform.position + _direction;
            Coordinate originalDirectionStep = new Coordinate((int)originalDirectionFuture.x, (int)originalDirectionFuture.y);


            Vector2 futureStep = actor.transform.position + newDirection;
            Coordinate oneStepAhead = new Coordinate((int)futureStep.x, (int)futureStep.y);

            if (possibleMoves.Contains(oneStepAhead))
            {
                Debug.Log("Changing route");
                _direction = newDirection;
                actor.transform.position += _direction;
            }

            else if (possibleMoves.Contains(originalDirectionStep))
            {
                actor.transform.position += _direction;
            }
        }
    }
}
