
public interface ILoader
{
    string getContext();
    bool Load();
    bool isDone();
    void Clear();
}