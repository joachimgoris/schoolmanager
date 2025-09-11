using SchoolManager.Models;
using SchoolManager.Models.Diff;

namespace SchoolManager.Services;

/**
 * This class manages the division of pupils into classes.
 *
 * It's your job to implement the UpdatePupilClassDivision method and the Diff method.
 */
public static class PupilClassManager
{
    public static State UpdatePupilClassDivision(State state, Request request)
    {
        throw new NotImplementedException("It's your job to implement this method.");
    }

    public static (List<UpdatedPupil>, List<UpdatedClass>) Diff(State oldState, State newState)
    {
        throw new NotImplementedException("It's your job to implement this method.");
    }
}
