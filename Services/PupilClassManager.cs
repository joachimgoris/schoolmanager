using SchoolManager.Models;
using SchoolManager.Models.Db;
using SchoolManager.Models.Diff;

namespace SchoolManager.Services;

/**
 * This class manages the division of pupils into classes.
 *
 * It's your job to implement the UpdatePupilClassDivision method and the Diff method.
 */
public static class PupilClassManager
{
    /// <summary>
    /// Updates the class assignments for pupils based on the specified assignment requests.
    /// </summary>
    /// <remarks>The method creates a shallow copy of the provided state and applies all assignment operations
    /// atomically. The original state is not modified.
    /// After assignments, pupils in each class are assigned follow-up numbers in alphabetical order by name.
    /// Since the original state remains unchanged, if data consistency is at risk, the method will write no data to its data store.
    /// For additional safety we could add write to the data via a transaction but this is out of scope.
    /// </remarks>
    /// <param name="state">The current state containing the lists of classes and pupils to be updated. This object is not modified.</param>
    /// <param name="request">The request containing the collection of pupil-to-class assignment operations to apply.</param>
    /// <returns>A new <see cref="State"/> instance reflecting the updated class assignments and follow-up numbers for pupils.</returns>
    /// <exception cref="Exception">Thrown if a specified pupil or class does not exist, if a pupil is assigned to multiple classes, if a class
    /// exceeds its maximum capacity, or if any pupil remains unassigned after processing.
    /// </exception>
    public static State UpdatePupilClassDivision(State state, Request request)
    {
        // Create a shallow copy of the state to avoid modifying the original state
        var newState = new State
        {
            Classes = state.Classes.Select(_ => _.Copy()).ToList(),
            Pupils = state.Pupils.Select(_ => _.Copy()).ToList()
        };

        foreach (var assignment in request.Assignments)
        {
            // Find the pupil by id, if not found throw EntityNotFoundException
            var pupil = newState.Pupils.SingleOrDefault(_ => _.Id == assignment.PupilId) ?? throw new Exception($"Pupil with id {assignment.PupilId} does not exist.");

            // Check if the pupil is assigned to many classes, if so throw PupilAssignedToManyClassesException
            IsPupilAssignedToManyClasses(pupil, request.Assignments);

            // Find the class by id, if not found throw EntityNotFoundException
            var foundClass = newState.Classes.SingleOrDefault(_ => _.Id == assignment.ClassId) ?? throw new Exception($"Class with id {assignment.ClassId} does not exist.");
            DoesClassExist(foundClass);

            if (pupil.ClassName == foundClass.ClassName)
            {
                // Pupil is already in the correct class, skip to next assignment
                continue;
            }
            // If the class is not full
            if (foundClass.AmountOfPupils < foundClass.MaxAmountOfPupils)
            {
                // If the pupil is already assigned to a class, decrease the amount of pupils in that class
                if (!string.IsNullOrWhiteSpace(pupil.ClassName))
                {
                    var previousClass = newState.Classes.Single(_ => _.ClassName == pupil.ClassName);
                    previousClass.AmountOfPupils--;
                }

                // Add pupil to class
                pupil.ClassName = foundClass.ClassName;
                foundClass.AmountOfPupils++;
            }
            else
            {
                throw new Exception($"Class {foundClass.ClassName} has too many pupils assigned.");
            }
        }

        // Assign follow up numbers to pupils in each class, ordered by name.
        foreach (var classroom in newState.Classes)
        {
            var orderedPupilsInClass = newState.Pupils.Where(_ => _.ClassName == classroom.ClassName).ToList().OrderBy(_ => _.Name);
            var index = 1;
            foreach (var pupil in orderedPupilsInClass)
            {
                pupil.FollowUpNumber = index;
                index++;
            }
        }

        if (newState.Pupils.Any(_ => string.IsNullOrWhiteSpace(_.ClassName)))
        {
            var unassignedPupil = newState.Pupils.First(_ => string.IsNullOrWhiteSpace(_.ClassName)).Id;
            throw new Exception($"Pupil with id {unassignedPupil} is not assigned to a class.");
        }

            return newState;
    }

    public static (List<UpdatedPupil>, List<UpdatedClass>) Diff(State oldState, State newState)
    {
        List<UpdatedPupil> updatedPupils = DiffPupils(oldState.Pupils, newState.Pupils);
        List<UpdatedClass> updatedClasses = DiffClasses(oldState.Classes, newState.Classes);

        return (updatedPupils, updatedClasses);
    }

    private static List<UpdatedPupil> DiffPupils(List<Pupil> oldPupils, List<Pupil> newPupils)
    {
        List<UpdatedPupil> updatedPupils = [];
        foreach (var newPupil in newPupils)
        {
            var oldPupil = oldPupils.SingleOrDefault(_ => _.Id == newPupil.Id);
            if (oldPupil is null || oldPupil.ClassName != newPupil.ClassName || oldPupil.FollowUpNumber != newPupil.FollowUpNumber)
            {
                updatedPupils.Add(new UpdatedPupil
                {
                    PupilId = newPupil.Id,
                    ClassName = newPupil.ClassName,
                    FollowUpNumber = newPupil.FollowUpNumber
                });
            }
        }
        return updatedPupils;
    }

    private static List<UpdatedClass> DiffClasses(List<Class> oldClasses, List<Class> newClasses)
    {
        List<UpdatedClass> updatedClasses = [];
        foreach (var newClass in newClasses)
        {
            var oldClass = oldClasses.SingleOrDefault(_ => _.Id == newClass.Id);
            if (oldClass is null || oldClass.AmountOfPupils != newClass.AmountOfPupils)
            {
                updatedClasses.Add(new UpdatedClass
                {
                    ClassId = newClass.Id,
                    AmountOfPupils = newClass.AmountOfPupils
                });
            }
        }
        return updatedClasses;
    }

    private static void IsPupilAssignedToManyClasses(Pupil pupil, List<Assignment> assignments)
    {
        var assignedClasses = assignments.Where(_ => _.PupilId == pupil.Id).ToList();
        if (assignedClasses.Count > 1)
        {
            throw new Exception($"Duplicate pupil IDs provided.");
        }
    }

    private static void DoesClassExist(Class foundClass)
    {
        if (string.IsNullOrWhiteSpace(foundClass.ClassName))
        {
            throw new Exception($"Class with id {foundClass.Id} does not exist.");
        }
    }
}


// Custom exceptions for better error handling but noticed tests expect base Exception

//public class EntityNotFoundException(int entityId)
//    : Exception()
//{
//}

//public class ClassLimitReachedException(int classId, string className)
//    : Exception($"The limit of class {className} (id: {classId}) has been reached.")
//{
//}

//public class PupilAssignedToManyClassesException(int pupilId)
//    : Exception($"Pupil with id {pupilId} is assigned to many classes.")
//{
//}

//public class  ClassDoesNotExistException(int classId)
//    : Exception($"Class with id {classId} does not exist.")
//{
//}
