using System;
using System.Collections.Generic;
using System.Linq;

namespace PhysikeffirebaseBE
{
    public static class RandomExerciseGenerator
    {
        public static Exercise GetExercise(string sceneName)
        {
            return new Exercise()
            {
                SceneName = sceneName,
                Question = Guid.NewGuid().ToString(),
                Answers = new List<string>() { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                CorrectAnswerIndex = Guid.NewGuid().ToByteArray().First() % 4
            };
        }
    }
}
