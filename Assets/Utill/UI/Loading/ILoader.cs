
public interface ILoader
{
    string getContext();
    void Load();
    void ThreadLoad();
    bool IsDone();
    void Clear();
}