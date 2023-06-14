using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation {
    public class BezierPathManager : MonoBehaviour {

        private PathCreator pathCreator;
        private BezierPath path;

        public Transform origin;
        public Transform destination;

        private int numPoints;

        // Start is called before the first frame update
        void Start() {
            pathCreator = GetComponent<PathCreator>();
            path = pathCreator.bezierPath;
            numPoints = path.NumPoints;

            path.SetPoint(0, transform.InverseTransformPoint(origin.position));
            path.SetPoint(numPoints - 1, transform.InverseTransformPoint(destination.position));
        }

        // Update is called once per frame
        void Update() {
            path.SetPoint(numPoints - 1, transform.InverseTransformPoint(destination.position));
        }
    }
}
