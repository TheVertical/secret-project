using System;
using System.IO;
using System.Xml.Serialization;
using SecretProject.GLPIExtension.Base;
using SecretProject.GLPIExtension.Control;
using SecretProject.VisualElements.Elements.Base;

namespace SecretProject.GLPIExtension
{
    public static class Mock
    {
        public static Scenario Scenario => new Scenario()
        {
            ScenarioType = ScenarioType.Incident,
            Category = "1c",
            Children = new ControlObject[] {
                    new RequestControl
                    {
                        Id = 0,
                        Order = 0,
                        Children = new DataObject[] {
                            new TextObject
                            {
                                Value = "Опишите поломку, а таже общие видимые наблюдения.",
                            },
                            new ImageObject()
                        },
                    },
                    new AnswerControl
                    {
                        Id = 1,
                        Order = 1,
                        Children = new DataObject[] {
                            new TextObject
                            {
                                Id=null,
                                Value = "Мы принили в рассмотрение вашу заявку. Статус заявки можно узнать нажав на кнопку \"Статус\", также в автоматическом порядке статус вашей заявки будет обновляться каждый час. Благодарим за обращение!",
                            }
                        }
                    },
                    new AnswerControl
                    {
                        Id = 2,
                        Order = 2,
                        Children = new DataObject[]
                        {
                            new TextObject
                            {
                                Id=null,
                                Value = "Пока вы ожидаете подтверждения. Вы можете, придерживаясь четких правил применить данную инструкцию.\n1. Отсоедените фритурницу от электропитания.\n2. Откройте крышку и потяните за рычаг.\n3. Найдите, фильтр и замените его на новый. (Где находится новый фильтр спросить у зам-начальника столовой)."
                            },
                            new ImageObject
                            {
                                Id=null,
                                Path="/Images/Friture.png"
                            }
                        }
                    },
                    new NotificationControl {
                        Id = 3,
                        Order = 3,
                    }
                }
        };
    }
}