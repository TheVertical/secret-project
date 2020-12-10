using System;
using SecretProject.BusinessProject.Models;
using Microsoft.EntityFrameworkCore;
using SecretProject.DAL.Contexts;
using System.Collections.Generic;
using System.Linq;
using SecretProject.BusinessProject.Measurements;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.BusinessProject.Models.UserData;
using SecretProject.BusinessProject.Models.Order;
using System.IO;

namespace SecretProject.DAL.DataInitiazation
{
    public class DataInitiazer
    {
        #region Class Methods
        public static void InitializeData(sBaseContext context)
        {
            var nomenclatureGroups = new List<NomenclatureGroup>
            {
                new NomenclatureGroup { Name = "Гигиена и профилактика",Childs = null,Parent = null},
                new NomenclatureGroup { Name = "Дезинфекция",Childs = null,Parent = null},
                new NomenclatureGroup { Name = "Ортопедические материалы",Childs = null,Parent = null},
                new NomenclatureGroup { Name = "Пломбировачные материалы материалы",Childs = null,Parent = null},
                new NomenclatureGroup { Name = "Приспособления и инструменты",Childs = null,Parent = null},
                new NomenclatureGroup { Name = "Слепочные массы",Childs = null,Parent = null},
            };
            context.NomenclatureGroups.AddRange(nomenclatureGroups);
            context.SaveChanges();

            var manufactures = new List<Manufacturer>
            {
                new Manufacturer { Name = "KERR"},
                new Manufacturer { Name = "Омега"},
                new Manufacturer { Name = "Candulor"},
                new Manufacturer { Name = "DMG"},
            };
            context.Manufacturers.AddRange(manufactures);
            context.SaveChanges();

            var measurements = new List<Measurement>
            {
                new Measurement{ocCode = 796, Name = "Штука", InternationalName = "PCE"},
                new Measurement{ocCode = 800, Name = "Набор", InternationalName = "PCE"}
            };
            context.Measurements.AddRange(measurements);

            var nomenclatures = new List<Nomenclature>
            {
                //Гигиена и профилактика
                new Nomenclature
                {
                    Name= @"Clean Polish паста 50 гр. №360 (Hawe Neos Dental)",
                    NomenclatureGroup = context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Гигиена и профилактика"),

                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "KERR"),

                    Description = "Паста полировочная стоматологическая: Cleanpolish на основе минералов из породы риолитов для чистки и полировки зубов, а также для предварительной полировки пломб из золота, амальгамы и композитов. Без фтора и анисово й отдушки. Цвет зеленый. Упаковка 50 г пасты в тюбике.",
                    Cost = 567,
                    Status = VisibleStatus.Visible,
                    Amount = 356,
                    Measurement = null
                },
                new Nomenclature
                {
                    Name= @"Cleanic без фторида 100г. тестовая уп. 3230",
                    NomenclatureGroup = context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Гигиена и профилактика"),

                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "KERR"),

                    Description = "Cleanic – универсальная паста для чистки и полировки. Паста Cleanic имеет изменяемую абразию: при нагрузке превращается из грубой в мелкозернистую и во время работы становится полировальной пастой с эффектом блеска. Она отвечает важнейшим требованиям к современной пасте: высокая чистящая способность, оптимальная полировка, минимальная абразия. Применение данной пасты для чистки и полировки одновременно позволяет значительно экономить время.",
                    Cost = 1700,
                    Status = VisibleStatus.Visible,
                    Amount = 5,
                    Measurement = null
                },
                //Дезинфекция
                new Nomenclature
                {
                    Name= @"Альвостаз губка (Йодоформ) гемостатический и антисептический компресс для альвеол(Омега)",
                    NomenclatureGroup = context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Дезинфекция"),

                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Омега"),
                    #region описание

                    Description = "Губка Альвостаз предназначается для лечения альвеолита, а также используется в качестве средства профилактики возможных осложнений после оперативного вмешательства, связанного с удалением зубов. Специальный препарат для альвеол обладает антисептическим действием и способствует остановке кровотечения. Коллагеновые кровоостанавливающие губки пропитаны специальным лекарственным раствором. Размер каждой из них составляет один квадратный сантиметр.",
                    Cost = 647,
                    Status = VisibleStatus.Visible,
                    Amount = 0,
	                #endregion

                    Measurement = null
                },
                new Nomenclature
                {
                    Name= @"Глассин Рест 10 гр+8г (Омега) стеклополиалкилатный пломбировочный материал химического отвердения",
                    NomenclatureGroup = context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Дезинфекция"),

                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Омега"),
                    #region описание
                    Description = @"Стеклоиономерный пломбировочный материал химического отвердения

Показания
“ГЛАССИН Рест” — стеклоиономерный пломбировочный материал химического отвердения, применяется при пломбировании кариозных полостей 3 и 5 классов. Пломбирование всех классов молочных зубов. Пломбирование некариозных поражений тканей зубов. Возможно использование в качестве подкладки под все виды пломб.

Свойства и состав
Порошок представляет собой мелкодисперсное алюминий-кальций лантан фторкремниевое стекло с рентгеноконтрастными добавками. Жидкость представляет собой водный раствор полиакриловой кислоты (определенной молекулярной массы) с органическими присадками, улучшающими ее свойства. Система порошок + жидкость характеризуется тем, что после образования цементной структуры все частицы остаются связанными, что в дальнейшем не способствует их вымыванию из материала. “ГЛАССИН Рест” характеризуется высокой прочностью и биологической совместимостью с тканями зуба. Повышенная химическая адгезия к дентину и эмали обеспечивает герметичное краевое прилегание. “ГЛАССИН Рест” обладает оптимальными эстетическими показателями. Противокариесный эффект обеспечивается за счет пролонгированного высвобождения ионов фтора. При пломбировании глубоких полостей, где толщина остаточного дентина менее 1мм, полость рекомендуется покрыть защитной прокладкой на основе гидроксида кальция, остальную поверхность дентина оставляют открытой для обеспечения химической связи материала с дентином.

Способ применения
После вскрытия полости зуба, провести механическую обработку по общепринятой методике, промыть и высушить полость.
Готовят материал при комнатной температуре (18 – 23Сo) на стеклянной пластине или специальном блокноте пластмассовым или стальным шпателем. Соотношение — 2 ложечки порошка с 1 каплей жидкости.
Сначала с полной порцией жидкости смешивают половину порции порошка, оставшуюся часть порошка вводят маленькими порциями до получения однородной смеси с глянцевой поверхностью. Смешивание производят в течение 45 – 60 секунд до получения пасты необходимой консистенции, которая должна быть похожа на пасту для пломбирования. Рабочее время приготовленного материала от 1,5 до 2-х минут. В процессе реставрационных работ и твердения, материал не должен контактировать с водой. Окончательное время твердения материала 5 – 6 минут с момента начала смешивания. Поскольку все стеклоиономерные материалы на начальном этапе отвердения очень чувствительны к влаге, целесообразно пломбу покрыть защитным лаком и высушить воздухом. Предварительную механическую обработку и шлифовку возможно провести не ранее чем через 15 – 20 минут. По окончании механической обработки пломбу покрывают защитным лаком. Окончательную механическую обработку проводят через 24 часа.

Упаковка: материал расфасован по 10 г порошка и 8 г жидкости.

Цвета — А2; А3; В1; В2 В3; С2",
                    #endregion
                    Cost = 720,
                    Status = VisibleStatus.Visible,
                    Amount = 8,
                    Measurement = null
                },
                //Ортопедические материалы
                new Nomenclature
                {
                    Name= @"Зубы композитные Bonartic II NFC+",
                    NomenclatureGroup = context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Ортопедические материалы"),

                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "DMG"),
                    #region описание
                    Description = @"Карт-форма для заказа зубов Закономерности, характерные для пространственного взаимоотношения естественных зубов, должны в равной степени применяться и при изготовлении протезов. При разработке боковых зубов Bonartic® II NFC+ их высокие функциональные свойства были адаптированы соответственно современным эстетическим требованиям.

Зубы Bonartic® II NFC+ сочетают в себе использование физиологических законов природы и эстетическо- морфологических требований с целью создания превосходного зубного протеза. Карт-форма для заказа зубов",
                    #endregion
                    Cost = 2400,
                    Status = VisibleStatus.Visible,
                    Amount = 10,
                    Measurement = null
                },
                new Nomenclature
                {
                    Name= @"ICON для инфильтрации кариеса вестибулярных поверхностей стартовый набор (DMG)",
                    NomenclatureGroup = context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Ортопедические материалы"),

                    Manufacturer = context.Manufacturers.FirstOrDefault(m => m.Name == "Candulor"),
                    #region описание
                    Description = @"Набор DMG ICON - эффективное лечение кариеса без потери здоровых тканей зуба.

В сотрудничестве с институтом Charite (Берлин) и универститетом г. Киль (Германия) была разработана система Icon для лечения начального кариеса - микроинвазивная, сохраняющая ткани зуба, простая в использовании, обеспечивающая безболезненное лечение в одно посещение.

Показания:
Микроинвазивное лечение ранних стадий кариеса на апроксимальных поверхностях (глубина поражения до D1*) и поражений эмали на вестибулярных поверхностях (например на стадии белого пятна, после снятия брекетов).

Противопоказания:
Запрещается использовать материал для полостей глубиной поражения от D2 до D3* или дефектов эмали, а также в цервикальных отделах с тонким слоем эмали или открытым дентином.",
                    #endregion
                    Cost = 5300,
                    Status = VisibleStatus.Visible,
                    Amount = 10,
                    Measurement = null
                },
            };
            context.Nomenclatures.AddRange(nomenclatures);
            context.SaveChanges();

            var users = new List<User>
            {
                new User{FirstName = "Данила",LastName="Потапов",Login="danila351960@yandex.ru",Password="potapov2222",MainPhone = new Phone(){ PhoneNumber = "79536600012"},Status = UserStatus.Active,
                    DeliveryAdresses = new List<Adress>
                    {
                        new Adress
                        {
                            Country = "Россия",
                            City = "Санкт-Петербург",
                            OKATOCod = 40,
                            District = "Невский",
                            Street = "Российский пр-кт",
                            BuildNumber = 3,
                            BuildCorps = 1,
                            Entrance = 1,
                            Floor = 3,
                            AppartmentNumber = 12,
                            Latitude = 59.923184f,
                            Longitude = 30.472759f,
                        }
                    }
                }
            };
            context.Users.AddRange(users);

            var promotion = new Promotion { OfficialTitle = "Специальные предложения!", WorkTitle = "Спец",
                DiscountedNomenclatures = new List<Nomenclature>()
            };
            var nomec = context.Nomenclatures.ToList();
            promotion.DiscountNomenclature(nomec, 10);
            context.Add(promotion);
            context.SaveChanges();


            var orders = new List<Order>
            {
                new Order
                {
                    OrderDetails = new OrderDetails
                    {
                        UserId = 1,
                        IsWithDelivery = true,
                    },
                    PaymentMethod = PaymentMethod.Bill,
                    Status = OrderState.Confirmed,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem { NomenclatureId = 2,ActualCount = 2, },
                        new OrderItem { NomenclatureId = 3,ActualCount = 1, },
                    }
                }
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();

            context.Database.OpenConnection();
            try
            {
                context.SaveChanges();
            }
            finally { context.Database.CloseConnection(); }
        }
        public static void RecreateDatabase(sBaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();
            context.Database.ExecuteSqlRaw("CREATE TRIGGER Order_INSERT_TRIGGER ON Orders"
                                            + " AFTER INSERT"
                                            + " AS"
                                            + " BEGIN"
                                            + " SET NOCOUNT ON;"
                                            + " IF((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;"
                                            + " DECLARE @Id INT"
                                            + " SELECT @Id = INSERTED.Id"
                                            + " FROM INSERTED"
                                            + " UPDATE dbo.Orders"
                                            + " SET DateCreated = GETDATE()"
                                            + " WHERE Id = @Id"
                                            + " END");
        }
        public  static void Main(string[] args)
        {
            sBaseContextFactory factory = new sBaseContextFactory();
            using (sBaseContext context = factory.CreateDbContext("server=DESKTOP-P7SS3RO;database=SecretDb;Integrated Security=True;App=EntityFramework"))
            {
                RecreateDatabase(context);
                InitializeData(context);
            }
        }
        #endregion
    }
}
