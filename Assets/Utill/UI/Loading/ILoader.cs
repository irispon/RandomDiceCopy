
public interface ILoader
{
    string GetContext();
    void Load();
    bool IsDone();
    void Clear();
}