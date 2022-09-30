using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class MoveableComponent : MonoBehaviour
    {
        private float speed = 4f;
        private float step;
        private Vector3 _destination;
        private bool isMoving;

        private void Awake()
        {
            step = speed * Time.deltaTime;
            isMoving = false;
        }
        private void Update()
        {
            if (isMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, _destination, step);
                Debug.Log(transform.position);
                Debug.Log(_destination);
            }
            if(transform.position.x >= _destination.x)
            {
                gameObject.SetActive(false);
            }
        }
        public void SetDestination(Vector3 destination)
        {
            //add implementation to move this object to destination
            //and destroy it when it reach the destination
            //desination must be some vector3 where y and z coordinate not change from current coordinate
            //only x coordinate change and to positive direction (to the right)
            Debug.Log("destination setting");
            _destination = destination;
            isMoving = true;
            Debug.Log(isMoving);
        }

    }
}