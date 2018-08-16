namespace Questions
{
    public interface IQuestionPublisher
    {
        Question GetQuestionForScene(string sceneName);
    }
}