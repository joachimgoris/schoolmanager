using SchoolManager.Models;
using SchoolManager.Models.Db;

namespace SchoolManager;

public class BogusStateProvider : IStateProvider
{
    private readonly State _state = new()
    {
        Pupils = [
            new Pupil() {
                Id = 1,
                Name = "Vermaercke Tim",
            },
            new Pupil() {
                Id = 2,
                Name = "Portauw Pieter"
            },
            new Pupil() {
                Id = 3,
                Name = "Maekelbergh Thibault",
            },
            new Pupil() {
                Id = 4,
                Name = "Petrescu Adrian-Mihai"
            },
            new Pupil() {
                Id = 5,
                Name = "De Vos Andres"
            },
            new Pupil() {
                Id = 6,
                Name = "Demaecker Caro",
            },
            new Pupil() {
                Id = 7,
                Name = "Goderis Jonas"
            },
            new Pupil() {
                Id = 8,
                Name = "Huyghe Lowie"
            },
            new Pupil () {
                Id = 9,
                Name = "Cornille Lukas"
            },
            new Pupil () {
                Id = 10,
                Name = "Nanescu Maria"
            },
            new Pupil () {
                Id = 11,
                Name = "Lasseel Siem"
            },
            new Pupil() {
                Id = 12,
                Name = "Spanhove Stijn"
            },
            new Pupil() {
                Id = 13,
                Name = "Verween Stijn"
            },
            new Pupil() {
                Id = 14,
                Name = "Dekiere Thomas"
            },
            new Pupil() {
                Id = 15,
                Name = "Akin Özgür"
            }
        ],
        Classes = [
            new Class() {
                Id = 1,
                ClassName = "First grade",
                TeacherName = "Mr. Lemaire Jeroen",
                MaxAmountOfPupils = 5,
            },
            new Class() {
                Id = 2,
                ClassName = "Second grade",
                TeacherName = "Mr. Verbist Frank",
                MaxAmountOfPupils = 20,
            }
            ]
    };
    public State GetState() => _state;
}
