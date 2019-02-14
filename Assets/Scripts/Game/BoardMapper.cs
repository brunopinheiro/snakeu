using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace SnakeU.GameScene {
    public class BoardMapper {
        HashSet<Vector2> occupiedCoordinates = new HashSet<Vector2>();

        public void StartListeningEventsFrom(NotificationCenter notificationCenter) {
            notificationCenter.AddListener(GameEvents.coordinateOccupied, AddOccupiedCoordinate);
            notificationCenter.AddListener(GameEvents.coordinateDisoccupied, RemoveOccupiedCoordinate);
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
            notificationCenter.RemoveListener(GameEvents.coordinateOccupied, AddOccupiedCoordinate);
            notificationCenter.RemoveListener(GameEvents.coordinateDisoccupied, RemoveOccupiedCoordinate);
        }

        public Vector2[] OccupiedCoordinates {
            get { return occupiedCoordinates.ToArray(); }
        }
    }
}