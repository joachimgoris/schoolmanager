using SchoolManager.Models;
using SchoolManager.Models.Db;
using SchoolManager.Models.Diff;
using SchoolManager.Services;

namespace SchoolManager.Tests;

/**
 * These tests are meant to test the PupilClassManager class.
 */
public class PupilClassManagerTests
{
    [Fact]
    public void Assign_New_Pupils_To_Classes()
    {
        // Arrange
        State initialState = new()
        {
            Pupils = [
                new() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                },
                new() {
                    Id = 2,
                    Name = "Portauw Pieter"
                },
                new() {
                    Id = 3,
                    Name = "Maekelbergh Thibault",
                },
                new() {
                    Id = 4,
                    Name = "Petrescu Adrian-Mihai"
                },
                new() {
                    Id = 5,
                    Name = "De Vos Andres"
                },
                new() {
                    Id = 6,
                    Name = "Demaecker Caro",
                },
                new() {
                    Id = 7,
                    Name = "Goderis Jonas"
                },
                new() {
                    Id = 8,
                    Name = "Huyghe Lowie"
                },
                new() {
                    Id = 9,
                    Name = "Cornille Lukas"
                },
                new() {
                    Id = 10,
                    Name = "Nanescu Maria"
                },
                new() {
                    Id = 11,
                    Name = "Lasseel Siem"
                },
                new() {
                    Id = 12,
                    Name = "Spanhove Stijn"
                },
                new() {
                    Id = 13,
                    Name = "Verween Stijn"
                },
                new() {
                    Id = 14,
                    Name = "Dekiere Thomas"
                },
                new() {
                    Id = 15,
                    Name = "Akin Özgür"
                }
            ],
            Classes = [
                new() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 5,
                },
                new() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 20,
                }
            ]
        };
        Request incomingRequest = new()
        {
            Assignments = [
                new() {
                    PupilId = 1,
                    ClassId = 1
                },
                new() {
                    PupilId = 2,
                    ClassId = 1
                },
                new() {
                    PupilId = 3,
                    ClassId = 1
                },
                new() {
                    PupilId = 4,
                    ClassId = 1
                },
                new() {
                    PupilId = 5,
                    ClassId = 1
                },
                new() {
                    PupilId = 6,
                    ClassId = 2
                },
                new() {
                    PupilId = 7,
                    ClassId = 2
                },
                new() {
                    PupilId = 8,
                    ClassId = 2
                },
                new() {
                    PupilId = 9,
                    ClassId = 2
                },
                new() {
                    PupilId = 10,
                    ClassId = 2
                },
                new() {
                    PupilId = 11,
                    ClassId = 2
                },
                new() {
                    PupilId = 12,
                    ClassId = 2
                },
                new() {
                    PupilId = 13,
                    ClassId = 2
                },
                new() {
                    PupilId = 14,
                    ClassId = 2
                },
                new() {
                    PupilId = 15,
                    ClassId = 2
                }
            ]
        };

        // Act
        State newState = PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest);
        var diff = PupilClassManager.Diff(initialState, newState);

        // Assert
        State expectedState = new()
        {
            Pupils =
            [
                new() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 5
                },
                new() {
                    Id = 2,
                    Name = "Portauw Pieter",
                    ClassName = "First grade",
                    FollowUpNumber = 4
                },
                new() {
                    Id = 3,
                    Name = "Maekelbergh Thibault",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new() {
                    Id = 4,
                    Name = "Petrescu Adrian-Mihai",
                    ClassName = "First grade",
                    FollowUpNumber = 3
                },
                new() {
                    Id = 5,
                    Name = "De Vos Andres",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                },
                new() {
                    Id = 6,
                    Name = "Demaecker Caro",
                    ClassName = "Second grade",
                    FollowUpNumber = 4
                },
                new() {
                    Id = 7,
                    Name = "Goderis Jonas",
                    ClassName = "Second grade",
                    FollowUpNumber = 5
                },
                new() {
                    Id = 8,
                    Name = "Huyghe Lowie",
                    ClassName = "Second grade",
                    FollowUpNumber = 6
                },
                new() {
                    Id = 9,
                    Name = "Cornille Lukas",
                    ClassName = "Second grade",
                    FollowUpNumber = 2
                },
                new() {
                    Id = 10,
                    Name = "Nanescu Maria",
                    ClassName = "Second grade",
                    FollowUpNumber = 8
                },
                new() {
                    Id = 11,
                    Name = "Lasseel Siem",
                    ClassName = "Second grade",
                    FollowUpNumber = 7
                },
                new() {
                    Id = 12,
                    Name = "Spanhove Stijn",
                    ClassName = "Second grade",
                    FollowUpNumber = 9
                },
                new() {
                    Id = 13,
                    Name = "Verween Stijn",
                    ClassName = "Second grade",
                    FollowUpNumber = 10
                },
                new() {
                    Id = 14,
                    Name = "Dekiere Thomas",
                    ClassName = "Second grade",
                    FollowUpNumber = 3
                },
                new() {
                    Id = 15,
                    Name = "Akin Özgür",
                    ClassName = "Second grade",
                    FollowUpNumber = 1
                }
            ],
            Classes =
            [
                new() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 5,
                    AmountOfPupils = 5
                },
                new() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 20,
                    AmountOfPupils = 10
                }
            ]
        };
        var expectedDiff = (
            new List<UpdatedPupil> {
                new() { PupilId = 1, ClassName = "First grade", FollowUpNumber = 5 },
                new() { PupilId = 2, ClassName = "First grade", FollowUpNumber = 4 },
                new() { PupilId = 3, ClassName = "First grade", FollowUpNumber = 2 },
                new() { PupilId = 4, ClassName = "First grade", FollowUpNumber = 3 },
                new() { PupilId = 5, ClassName = "First grade", FollowUpNumber = 1 },
                new() { PupilId = 6, ClassName = "Second grade", FollowUpNumber = 4 },
                new() { PupilId = 7, ClassName = "Second grade", FollowUpNumber = 5 },
                new() { PupilId = 8, ClassName = "Second grade", FollowUpNumber = 6 },
                new() { PupilId = 9, ClassName = "Second grade", FollowUpNumber = 2 },
                new() { PupilId = 10, ClassName = "Second grade", FollowUpNumber = 8 },
                new() { PupilId = 11, ClassName = "Second grade", FollowUpNumber = 7 },
                new() { PupilId = 12, ClassName = "Second grade", FollowUpNumber = 9 },
                new() { PupilId = 13, ClassName = "Second grade", FollowUpNumber = 10 },
                new() { PupilId = 14, ClassName = "Second grade", FollowUpNumber = 3 },
                new() { PupilId = 15, ClassName = "Second grade", FollowUpNumber = 1 }
            },
            new List<UpdatedClass> {
                new() { ClassId = 1, AmountOfPupils = 5 },
                new() { ClassId = 2, AmountOfPupils = 10 }
            }
        );

        Assert.Equivalent(expectedState, newState, strict: true);
        Assert.Equal(5, newState.Classes[0].AmountOfPupils);
        Assert.Equal(10, newState.Classes[1].AmountOfPupils);
        Assert.Equal(5, newState.Pupils.First(p => p.Name == "Vermaercke Tim").FollowUpNumber);
        Assert.Equal(5, newState.Pupils.First(p => p.Name == "Goderis Jonas").FollowUpNumber);
        Assert.Equivalent(expectedDiff, diff, strict: true);
    }

    [Fact]
    public void Move_Some_Pupils_From_One_Class_To_Another()
    {
        // Arrange
        State initialState = new()
        {
            Pupils =
            [
                new() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            ],
            Classes =
            [
                new() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 2
                },
                new() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 0
                }
            ]
        };
        Request incomingRequest = new()
        {
            Assignments =
            [
                new() {
                    PupilId = 1,
                    ClassId = 2
                }
            ]
        };

        // Act
        State newState = PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest);
        var diff = PupilClassManager.Diff(initialState, newState);

        // Assert
        State expectedState = new()
        {
            Pupils = [
                new()
                {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "Second grade",
                    FollowUpNumber = 1
                },
                new()
                {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            ],
            Classes = [
                new()
                {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",

                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 1
                },
                new()
                {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 1
                }
            ]
        };
        var expectedDiff = (
            new List<UpdatedPupil> {
                new() { PupilId = 1, ClassName = "Second grade", FollowUpNumber = 1 }
            },
            new List<UpdatedClass> {
                new() { ClassId = 1, AmountOfPupils = 1 },
                new() { ClassId = 2, AmountOfPupils = 1 }
            }
        );

        Assert.Equivalent(expectedState, newState, strict: true);
        Assert.Equal(1, newState.Classes[0].AmountOfPupils);
        Assert.Equal(1, newState.Classes[1].AmountOfPupils);
        Assert.Equal(1, newState.Pupils.First(p => p.Name == "Vermaercke Tim").FollowUpNumber);
        Assert.Equal(1, newState.Pupils.First(p => p.Name == "Goderis Jonas").FollowUpNumber);
        Assert.Equivalent(expectedDiff, diff, strict: true);
    }

    [Fact]
    public void Assigning_Pupil_To_A_Non_Existing_Class_Should_Fail()
    {
        State initialState = new()
        {
            Pupils =
            [
                new() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            ],
            Classes =
            [
                new() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 2
                },
            ]
        };
        Request incomingRequest = new()
        {
            Assignments =
            [
                new() {
                    PupilId = 1,
                    ClassId = 2 // This class does not exist
                }
            ]
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Class with id 2 does not exist.", ex.Message);
    }

    [Fact]
    public void Assigning_Non_Existing_Pupil_To_A_Class_Should_Fail()
    {
        State initialState = new()
        {
            Pupils =
            [
                new() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            ],
            Classes =
            [
                new() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 3
                },
            ]
        };
        Request incomingRequest = new()
        {
            Assignments =
            [
                new() {
                    PupilId = 3,// This pupil does not exist
                    ClassId = 1
                }
            ]
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Pupil with id 3 does not exist.", ex.Message);
    }

    [Fact]
    public void Assigning_The_Same_Pupil_To_Multiple_Classes_Should_Fail()
    {
        State initialState = new()
        {
            Pupils =
            [
                new() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            ],
            Classes =
            [
                new() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 2
                },
                new() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 0
                }
            ]
        };
        Request incomingRequest = new()
        {
            Assignments =
            [
                new() {
                    PupilId = 1,
                    ClassId = 1
                },
                new() {
                    PupilId = 1,
                    ClassId = 2
                }
            ]
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Duplicate pupil IDs provided.", ex.Message);
    }

    [Fact]
    public void When_A_Pupil_Is_Not_Assigned_To_A_Class_It_Should_Fail()
    {
        State initialState = new()
        {
            Pupils =
            [
                new() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "", // This pupil is not assigned to a class
                    FollowUpNumber = 1
                }
            ],
            Classes =
            [
                new() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 2
                },
                new() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 0
                }
            ]
        };
        Request incomingRequest = new()
        {
            Assignments =
            [
                new() {
                    PupilId = 1,
                    ClassId = 1
                },
            ]
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Pupil with id 2 is not assigned to a class.", ex.Message);
    }

    [Fact]
    public void When_The_Amount_Of_Pupils_In_A_Class_Exceeds_The_Maximum_Amount_It_Should_Fail()
    {
        State initialState = new()
        {
            Pupils =
            [
                new() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "Second grade",
                    FollowUpNumber = 1
                }
            ],
            Classes =
            [
                new() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 1
                },
                new() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 0
                }
            ]
        };
        Request incomingRequest = new()
        {
            Assignments =
            [
                new() {
                    PupilId = 2,
                    ClassId = 1
                },
            ]
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Class First grade has too many pupils assigned.", ex.Message);
    }
}
