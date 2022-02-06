using System;
using System.IO;
using System.Xml.Serialization;
using SecretProject.GLPIExtension.Base;
using SecretProject.GLPIExtension.Control;
using SecretProject.VisualElements.Elements.Base;

namespace SecretProject.GLPIExtension
{
    public class Mock {
        public Scenario Scenario => new Scenario()
            {
                Id = 0,
                ScenarioType = ScenarioType.Incident,
                Category = "1c",
                ControlChildren = new ControlObject[] {
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
                        ControlChildren = new ControlObject[]
                        {
                            new AnswerControl
                            {
                                Id = 1,
                                Order = 0,
                                Children = new DataObject[] {
                                    new TextObject
                                    {
                                        Value = "Мы принили в рассмотрение вашу заявку. Статус заявки можно узнать нажав на кнопку \"Статус\", также в автоматическом порядке статус вашей заявки будет обновляться каждый час. Благодарим за обращение!",
                                    }
                                }
                            }
                        }
                    },
                    new AnswerControl
                    {
                        Id = 1,
                        Order = 1,
                        Children = new DataObject[]
                        {
                            new TextObject
                            {
                                Value = "Пока вы ожидаете подтверждения. Вы можете, придерживаясь четких правил применить данную инструкцию.\n1. Отсоедените фритурницу от электропитания.\n2. Откройте крышку и потяните за рычаг.\n3. Найдите, фильтр и замените его на новый. (Где находится новый фильтр спросить у зам-начальника столовой)."
                            },
                            new ImageObject
                            {
                                Path="/Images/Friture.png"
                            }
                        }
                    }
                }
            };
    }
}