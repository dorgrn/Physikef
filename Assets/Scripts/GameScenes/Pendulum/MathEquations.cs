using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameScenes.Pendulum
{
    public class MathEquations
    {
        public static float FindClosestToAnswer(List<float> possibleAnswers, float ropeLength)
        {
            float actualAnswer = GetOscillationPeriod(ropeLength);
            int indexOfClosest = getIndexOfMin(
                new List<float>(possibleAnswers.Select(possibleAnswer => Mathf.Abs(possibleAnswer - actualAnswer))));
            return possibleAnswers[indexOfClosest];
        }

        private static int getIndexOfMin(List<float> list)
        {
            float min = list[0];
            int minIndex = 0;

            for (var i = 1; i < list.Count; ++i)
            {
                if (list[i] < min)
                {
                    min = list[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        // Period of time, in seconds, in which a simple pendulum completes a cycle.
        private static float GetOscillationPeriod(float ropeLength)
        {
            return 2 * Mathf.PI * Mathf.Sqrt(ropeLength / Physics.gravity.normalized.y);
        }
    }
}