namespace PhysikeffirebaseBE
{
    public class StudentExerciseResult
    {
        public string AnsweringStudentId { get; set; }
        public string Question { get; set; }
        public string StudentAnswer { get; set; }
        public bool isCorrect { get; set; }

        public override string ToString()
        {
            return "Student ID: " + AnsweringStudentId + ", Question: " + Question
                   + ", Student Answer: " + StudentAnswer + ", which is " + (isCorrect ? "Correct" : "Wrong");
        }
    }
}