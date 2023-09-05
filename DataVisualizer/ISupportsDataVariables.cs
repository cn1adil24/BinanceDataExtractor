namespace DataVisualizer
{
    interface IRendersDataVariables
    {
        void StartEmbedding(string name);
        void Embed(object value);
        void StopEmbedding();
    }
}
