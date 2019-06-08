using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    public class QuestionnaireTill75ViewModel
    {
        [DisplayName("1.1 гипертоническая болезнь (повышенное артериальное давление)?")]
        public bool QuestionOneOne { get; set; }

        [DisplayName("Если 'Да', то принимаете ли вы препараты для снижения давления?")]
        public bool QuestionOneOneOne { get; set; }

        [DisplayName("1.2 ишемическая болезнь сердца (стенокардия)?")]
        public bool QuestionOneTwo { get; set; }

        [DisplayName("1.3.цереброваскулярное заболевание (заболевание сосудов головного мозга)?")]
        public bool QuestionOneThree { get; set; }

        [DisplayName("1.4.хроническое заболевание бронхов или легких (хронический бронхит, эмфизема, бронхиальная астма)?")]
        public bool QuestionOneFour { get; set; }

        [DisplayName("1.5. туберкулез (легких или иных локализаций)?")]
        public bool QuestionOneFive { get; set; }

        [DisplayName("1.6.сахарный диабет или повышенный уровень сахара в крови?")]
        public bool QuestionOneSix { get; set; }

        [DisplayName("Если «Да», то принимаете ли Вы препараты для снижения уровня сахара?")]
        public bool QuestionOneSixOne { get; set; }

        [DisplayName("1.7.заболевания желудка (гастрит, язвенная болезнь)?")]
        public bool QuestionOneSeven { get; set; }

        [DisplayName("1.8. хроническое заболевание почек?")]
        public bool QuestionOneEight { get; set; }

        [DisplayName("1.9. злокачественное новообразование?")]
        public bool QuestionOneNine { get; set; }

        [DisplayName("Если «Да», то какое?")]
        public string QuestionOneNineOne { get; set; }

        [DisplayName("1.10. повышенный уровень холестерина?")]
        public bool QuestionOneTen { get; set; }

        [DisplayName("Если «Да», то принимаете ли Вы препараты для снижения уровня холестерина?")]
        public bool QuestionOneTenOne { get; set; }

        [DisplayName("2. Был ли у Вас инфаркт миокарда?")]
        public bool QuestionTwo { get; set; }

        [DisplayName("3. Был ли у Вас инсульт?")]
        public bool QuestionThree { get; set; }

        [DisplayName("4. Был ли инфаркт миокарда или инсульт у Ваш их близких родственников в молодом или среднем возрасте (до 65 лет у матери или родных сестер или до 55 лет у отца или родных братьев)?")]
        public bool QuestionFour { get; set; }

        [DisplayName("5.Были ли у Ваших близких родственников в молодом или среднем возрасте злокачественные новообразования (желудка, кишечника, толстой или прямой кишки, полипоз желудка, кишечника, предстательной железы, молочной железы, матки, опухоли других локализаций) или семейный аденоматоз диффузный полипоз) толстой кишки? ")]
        public bool QuestionFive { get; set; }

        [DisplayName("6. Возникает ли у Вас, когда поднимаетесь по лестнице, идете в гору или спешите, или при выходе из теплого помещения на холодный воздух, боль или ощущение давления, жжения или тяжести за грудиной или в левой половине грудной клетки, с распространением в левую руку?")]
        public bool QuestionSix { get; set; }

        [DisplayName("7. Если Вы останавливаетесь, исчезает ли эта боль (ощущения) в течение 10 минут? ")]
        public SelectList QuestionSeven { get; set; }
        public int SelectedQuestionSevenAnswer { get; set; }

        [DisplayName("8. Возникала ли у Вас когда-либо внезапная кратковременная слабость или неловкость при движении в одной руке (ноге) либо руке и ноге одновременно так, что Вы не могли взять или удержать предмет, встать со стула, пройтись по комнате?")]
        public bool QuestionEight { get; set; }

        [DisplayName("9. Возникало ли у Вас когда-либо внезапное без явных причин кратковременное онемение в одной руке, ноге или половине лица, губы или языка?")]
        public bool QuestionNine { get; set; }

        [DisplayName("10. Возникала ли у Вас когда-либо внезапно кратковременная потеря зрения на один глаз?")]
        public bool QuestionTen { get; set; }

        [DisplayName("11. Бывают ли у Вас ежегодно периоды ежедневного ка ля с отделением мокроты на протяжении примерно 3-х месяцев в году?")]
        public bool QuestionEleven { get; set; }

        [DisplayName("12. Бывают ли у Вас свистящие «хрипы» или «свисты» в грудной клетке с чувством затруднения дыхания или без?")]
        public bool QuestionTwelve { get; set; }

        [DisplayName("13. Бывало ли у Вас когда-либо кровохарканье?")]
        public bool QuestionThirteen { get; set; }

        [DisplayName("14. Беспокоят ли Вас боли в области верхней части живота (в области желудка), отрыжка, тошнота, рвота, ухудшение или отсутствие аппетита?")]
        public bool QuestionFourteen { get; set; }

        [DisplayName("15. Бывает ли у Вас неоформленный (полужидкий) черный или дегтеобразный стул?")]
        public bool QuestionFifteen { get; set; }

        [DisplayName("16. Похудели ли Вы за последнее время без видимых причин (т.е. без соблюдения диеты или увеличения физической активности и пр.)?")]
        public bool QuestionSixteen { get; set; }

        [DisplayName("17. Бывает ли у Вас боль в области заднепроходного отверстия?")]
        public bool QuestionSeventeen { get; set; }

        [DisplayName("18. Бывают ли у Вас кровяные выделения с калом?")]
        public bool QuestionEighteen { get; set; }

        [DisplayName("19. Курите ли Вы? (курение одной и более сигарет в день)")]
        public bool QuestionNineteen { get; set; }

        [DisplayName("20. Если Вы курите, то сколько в среднем сигарет в день выкуриваете?")]
        public int QuestionTwenty { get; set; }

        [DisplayName("21. Сколько минут в день Вы тратите на ходьбу в умеренном или быстром темпе (включая дорогу до места работы и обратно)?")]
        public SelectList QuestionTwentyOne { get; set; }
        public int SelectedQuestionTwentyOneAnswer { get; set; }

        [DisplayName("22. Употребляете ли Вы ежедневно около 400 граммов (или 4-5 порций) фруктов и овощей (не считая картофеля)?")]
        public bool QuestionTwentyTwo { get; set; }

        [DisplayName("23. Имеете ли Вы привычку подсаливать приготовленную пищу, не пробуя ее?")]
        public bool QuestionTwentyThree { get; set; }

        [DisplayName("24. Принимали ли Вы за последний год психотропные или наркотические вещества без назначения врача?")]
        public bool QuestionTwentyFour { get; set; }

        [DisplayName("25. Как часто Вы употребляете алкогольные напитки?")]
        public SelectList QuestionTwentyFive { get; set; }
        public int SelectedQuestionTwentyFiveAnswer { get; set; }

        [DisplayName("26. Какое количество алкогольных напитков (сколько порций) вы выпиваете обычно за один раз?")]
        public SelectList QuestionTwentySeven { get; set; }
        public int SelectedQuestionTwentySevenAnswer { get; set; }

        [DisplayName("27. Как часто Вы употребляете за один раз 6 или более порций?")]
        public SelectList QuestionTwentySix { get; set; }
        public int SelectedQuestionTwentySixAnswer { get; set; }

        public SelectList DefaultAnswerList { get; set; }
    }
}
