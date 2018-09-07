using System;
using System.Collections.Generic;
using System.Linq;
using Exercises;
using Attribute = Attributes.Attribute;

namespace Questions
{
    public class InternalExercisePublisher : IExercisePublisher
    {
        private readonly Dictionary<string, List<Exercise>> m_SceneExercises = new Dictionary<string, List<Exercise>>();

        protected InternalExercisePublisher()
        {
            addInitialExercises();
        }

        private void addInitialExercises()
        {
//            m_SceneExercises.Add("Pendulum",
//                new Exercise(
//                    "Given the length of the rope L=2m and the gravity is 9.8m/s^2 what would be the oscillation period in seconds?",
//                    new List<string> {"2.8", "1.6", "5.2", "5.7"}, "2.8"));
        }

        public List<Exercise> GetExercisesForScene(string sceneName)
        {
            return m_SceneExercises[sceneName];
        }


        public List<Attribute> GetAttributesForExercise(string sceneName, string exerciseName)
        {
            List<Exercise> exercises = m_SceneExercises[sceneName];
            Exercise chosenExercise = exercises.FirstOrDefault(e => e.Name.Equals(exerciseName));
            if (chosenExercise == null)
            {
                throw new Exception(string.Format("Exercise {0} for scene {1} not found!", exerciseName, sceneName));
            }

            return chosenExercise.Attributes;
        }
    }
}