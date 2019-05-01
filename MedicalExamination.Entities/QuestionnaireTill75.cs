using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalExamination.Entities
{
    public sealed class QuestionnaireTill75
    {
        [Key]
        public Guid AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }

        public bool QuestionOneOne { get; set; }
        public bool QuestionOneOneOne { get; set; }

        public bool QuestionOneTwo { get; set; }

        public bool QuestionOneThree { get; set; }

        public bool QuestionOneFour { get; set; }

        public bool QuestionOneFive { get; set; }

        public bool QuestionOneSix { get; set; }
        public bool QuestionOneSixOne { get; set; }

        public bool QuestionOneSeven { get; set; }

        public bool QuestionOneEight { get; set; }

        public bool QuestionOneNine { get; set; }
        public string QuestionOneNineOne { get; set; }

        public bool QuestionOneTen { get; set; }
        public bool QuestionOneTenOne { get; set; }

        public bool QuestionTwo { get; set; }

        public bool QuestionThree { get; set; }

        public bool QuestionFour { get; set; }

        public bool QuestionFive { get; set; }

        public bool QuestionSix { get; set; }

        public QuestionSevenAnswers QuestionSeven { get; set; }

        public bool QuestionEight { get; set; }

        public bool QuestionNine { get; set; }

        public bool QuestionTen { get; set; }

        public bool QuestionEleven { get; set; }

        public bool QuestionTwelve { get; set; }

        public bool QuestionThirteen { get; set; }

        public bool QuestionFourteen { get; set; }

        public bool QuestionFifteen { get; set; }

        public bool QuestionSixteen { get; set; }

        public bool QuestionSeventeen { get; set; }

        public bool QuestionEighteen { get; set; }

        public bool QuestionNineteen { get; set; }

        public int QuestionTwenty { get; set; }

        public bool QuestionTwentyOne { get; set; }

        public bool QuestionTwentyTwo { get; set; }

        public bool QuestionTwentyThree { get; set; }

        public bool QuestionTwentyFour { get; set; }

        public QuestionTwentyFiveAnswers QuestionTwentyFive { get; set; }

        public QuestionTwentySixAnswers QuestionTwentySix { get; set; }

        public QuestionTwentySevenAnswers QuestionTwentySeven { get; set; }
    }
}
