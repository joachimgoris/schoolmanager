using SchoolManager.Models;

namespace SchoolManager;

public interface IStateProvider
{
    State GetState();
}
