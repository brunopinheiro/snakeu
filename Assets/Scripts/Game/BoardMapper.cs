using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace SnakeU.GameScene {
    public class BoardMapper {
        HashSet<Vector2> occupiedCoordinates = new HashSet<Vector2>();

        public void StartListeningEventsFrom(NotificationCenter notificationCenter) {
            notificationCenter.AddListener("snake.coordinateOccupied", AddOccupiedCoordinate);
            notificationCenter.AddListener("snake.coordinateDisoccupied", RemoveOccupiedCoordinate);
        }

        void AddOccupiedCoordinate(Hashtable args) {
            var coordinate = (Vector2)args["coordinates"];
            occupiedCoordinates.Add(coordinate);
        }

        void RemoveOccupiedCoordinate(Hashtable args) {
            var coordinate = (Vector2)args["coordinates"];
            occupiedCoordinates.Remove(coordinate);
        }

        public void StopListeningEventsFrom(NotificationCenter notificationCenter) {
            notificationCenter.RemoveListener("snake.coordinateOccupied", AddOccupiedCoordinate);
            notificationCenter.RemoveListener("snake.coordinateDisoccupied", RemoveOccupiedCoordinate);
        }

        public Vector2[] OccupiedCoordinates {
            get { return occupiedCoordinates.ToArray(); }
        }
    }
}