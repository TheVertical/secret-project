﻿using System;
using SecretProject.BusinessProject.Models;
using Microsoft.EntityFrameworkCore;
using SecretProject.DAL.Contexts;
using System.Collections.Generic;
using System.Linq;
using SecretProject.BusinessProject.Models.UserData;
using SecretProject.BusinessProject.Models.Order;
using System.IO;
using SecretProject.VisualElements.Pages;
using SecretProject.BusinessProject.Models.Common;
using System.Text;
using Newtonsoft.Json;

namespace SecretProject.DAL.DataInitiazation
{
    public class MainDataInitializer : DataInitializerBase
    {
        public override void InitializeData(DbContext context)
        {
//             MainContext _context = null;
//             if(context is MainContext)
//                 _context = context as MainContext;
//             else
//             {
//                 Exception ex = new Exception("Context has incorrect type!");
//                 throw new TypeInitializationException(nameof(_context), ex);
//             }

//             bool isNeedRandom = true;
//             Random random = new Random();
//             var company = new Company
//             {
//                 Name = "Olimp-dental",
//                 WorkHours = "Пн-Чт:10:00 - 18:00, Пт:10:00 - 17:00",
//                 WorkPhone = new Phone() { PhoneNumber = "8 (812) 388-4538" }
//             };
//             _context.Companies.Add(company);
//             var nomenclatureGroups = new List<NomenclatureGroup>
//             {
//                 new NomenclatureGroup { Name = "Гигиена и профилактика",Childs = null,Parent = null},
//                 new NomenclatureGroup { Name = "Дезинфекция",Childs = null,Parent = null},
//                 new NomenclatureGroup { Name = "Ортопедические материалы",Childs = null,Parent = null},
//                 new NomenclatureGroup { Name = "Пломбировачные материалы",Childs = null,Parent = null},
//                 new NomenclatureGroup { Name = "Приспособления и инструменты",Childs = null,Parent = null},
//                 new NomenclatureGroup { Name = "Слепочные массы",Childs = null,Parent = null},
//             };
//             if (isNeedRandom)
//             {
//                 var randomNomenclatureGroup = new List<NomenclatureGroup>();
//                 for (int i = 0; i < 3; i++)
//                 {
//                     NomenclatureGroup group = new NomenclatureGroup();
//                     group.Name = this.GenRandomString(50);
//                     randomNomenclatureGroup.Add(group);
//                 }
//                 _context.NomenclatureGroups.AddRange(randomNomenclatureGroup);
//             }
//             _context.NomenclatureGroups.AddRange(nomenclatureGroups);
//             _context.SaveChanges();

//             var manufactures = new List<Manufacturer>
//             {
//                 new Manufacturer { Name = "KERR"},
//                 new Manufacturer { Name = "Омега"},
//                 new Manufacturer { Name = "Candulor"},
//                 new Manufacturer { Name = "DMG"},
//             };
//             _context.Manufacturers.AddRange(manufactures);
//             if(isNeedRandom)
//             {
//                 var randomManufacturers = new List<Manufacturer>();
//                 for (int i = 0; i < 16; i++)
//                 {
//                     Manufacturer manufacturer = new Manufacturer();
//                     int length = random.Next(3, 10);
//                     manufacturer.Name = this.GenRandomString(10, Alphabet: "QWERTYUIOPASDFGHJKLZXCVBNM");
//                     randomManufacturers.Add(manufacturer);
//                 }
//                 _context.Manufacturers.AddRange(randomManufacturers);
//             }
//             _context.SaveChanges();

//             var measurements = new List<Measurement>
//             {
//                 new Measurement{ocCode = 796, Name = "Штука", InternationalName = "PCE"},
//                 new Measurement{ocCode = 800, Name = "Набор", InternationalName = "PCE"}
//             };
//             _context.Measurements.AddRange(measurements);

//             var nomenclatures = new List<Nomenclature>
//             {
//                 //Гигиена и профилактика
//                 new Nomenclature
//                 {
//                     Name= @"Clean Polish паста 50 гр. №360 (Hawe Neos Dental)",
//                     NomenclatureGroup = _context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Гигиена и профилактика"),

//                     Manufacturer = _context.Manufacturers.FirstOrDefault(m => m.Name == "KERR"),

//                     Description = "Паста полировочная стоматологическая: Cleanpolish на основе минералов из породы риолитов для чистки и полировки зубов, а также для предварительной полировки пломб из золота, амальгамы и композитов. Без фтора и анисово й отдушки. Цвет зеленый. Упаковка 50 г пасты в тюбике.",
//                     Cost = 567,
//                     Status = VisibleStatus.Visible,
//                     Amount = 356,
//                     Measurement = null,
//                    ImageUrl = "./Images/Product.jpg"
//                 },
//                 new Nomenclature
//                 {
//                     Name= @"Cleanic без фторида 100г. тестовая уп. 3230",
//                     NomenclatureGroup = _context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Гигиена и профилактика"),

//                     Manufacturer = _context.Manufacturers.FirstOrDefault(m => m.Name == "KERR"),

//                     Description = "Cleanic – универсальная паста для чистки и полировки. Паста Cleanic имеет изменяемую абразию: при нагрузке превращается из грубой в мелкозернистую и во время работы становится полировальной пастой с эффектом блеска. Она отвечает важнейшим требованиям к современной пасте: высокая чистящая способность, оптимальная полировка, минимальная абразия. Применение данной пасты для чистки и полировки одновременно позволяет значительно экономить время.",
//                     Cost = 1700,
//                     Status = VisibleStatus.Visible,
//                     Amount = 5,
//                     Measurement = null,
//                    ImageUrl = "./Images/Product.jpg"
//                 },
//                 //Дезинфекция
//                 new Nomenclature
//                 {
//                     Name= @"Альвостаз губка (Йодоформ) гемостатический и антисептический компресс для альвеол(Омега)",
//                     NomenclatureGroup = _context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Дезинфекция"),

//                     Manufacturer = _context.Manufacturers.FirstOrDefault(m => m.Name == "Омега"),
//                     #region описание

//                     Description = "Губка Альвостаз предназначается для лечения альвеолита, а также используется в качестве средства профилактики возможных осложнений после оперативного вмешательства, связанного с удалением зубов. Специальный препарат для альвеол обладает антисептическим действием и способствует остановке кровотечения. Коллагеновые кровоостанавливающие губки пропитаны специальным лекарственным раствором. Размер каждой из них составляет один квадратный сантиметр.",
//                     Cost = 647,
//                     Status = VisibleStatus.Visible,
//                     Amount = 0,
// 	                #endregion

//                     Measurement = null,
//                    ImageUrl = "./Images/Product.jpg"
//                 },
//                 new Nomenclature
//                 {
//                     Name= @"Глассин Рест 10 гр+8г (Омега) стеклополиалкилатный пломбировочный материал химического отвердения",
//                     NomenclatureGroup = _context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Дезинфекция"),

//                     Manufacturer = _context.Manufacturers.FirstOrDefault(m => m.Name == "Омега"),
//                     #region описание
//                     Description = @"Стеклоиономерный пломбировочный материал химического отвердения

// Показания
// “ГЛАССИН Рест” — стеклоиономерный пломбировочный материал химического отвердения, применяется при пломбировании кариозных полостей 3 и 5 классов. Пломбирование всех классов молочных зубов. Пломбирование некариозных поражений тканей зубов. Возможно использование в качестве подкладки под все виды пломб.

// Свойства и состав
// Порошок представляет собой мелкодисперсное алюминий-кальций лантан фторкремниевое стекло с рентгеноконтрастными добавками. Жидкость представляет собой водный раствор полиакриловой кислоты (определенной молекулярной массы) с органическими присадками, улучшающими ее свойства. Система порошок + жидкость характеризуется тем, что после образования цементной структуры все частицы остаются связанными, что в дальнейшем не способствует их вымыванию из материала. “ГЛАССИН Рест” характеризуется высокой прочностью и биологической совместимостью с тканями зуба. Повышенная химическая адгезия к дентину и эмали обеспечивает герметичное краевое прилегание. “ГЛАССИН Рест” обладает оптимальными эстетическими показателями. Противокариесный эффект обеспечивается за счет пролонгированного высвобождения ионов фтора. При пломбировании глубоких полостей, где толщина остаточного дентина менее 1мм, полость рекомендуется покрыть защитной прокладкой на основе гидроксида кальция, остальную поверхность дентина оставляют открытой для обеспечения химической связи материала с дентином.

// Способ применения
// После вскрытия полости зуба, провести механическую обработку по общепринятой методике, промыть и высушить полость.
// Готовят материал при комнатной температуре (18 – 23Сo) на стеклянной пластине или специальном блокноте пластмассовым или стальным шпателем. Соотношение — 2 ложечки порошка с 1 каплей жидкости.
// Сначала с полной порцией жидкости смешивают половину порции порошка, оставшуюся часть порошка вводят маленькими порциями до получения однородной смеси с глянцевой поверхностью. Смешивание производят в течение 45 – 60 секунд до получения пасты необходимой консистенции, которая должна быть похожа на пасту для пломбирования. Рабочее время приготовленного материала от 1,5 до 2-х минут. В процессе реставрационных работ и твердения, материал не должен контактировать с водой. Окончательное время твердения материала 5 – 6 минут с момента начала смешивания. Поскольку все стеклоиономерные материалы на начальном этапе отвердения очень чувствительны к влаге, целесообразно пломбу покрыть защитным лаком и высушить воздухом. Предварительную механическую обработку и шлифовку возможно провести не ранее чем через 15 – 20 минут. По окончании механической обработки пломбу покрывают защитным лаком. Окончательную механическую обработку проводят через 24 часа.

// Упаковка: материал расфасован по 10 г порошка и 8 г жидкости.

// Цвета — А2; А3; В1; В2 В3; С2",
//                     #endregion
//                     Cost = 720,
//                     Status = VisibleStatus.Visible,
//                     Amount = 8,
//                     Measurement = null,
//                    ImageUrl = "./Images/Product.jpg"
//                 },
//                 //Ортопедические материалы
//                 new Nomenclature
//                 {
//                     Name= @"Зубы композитные Bonartic II NFC+",
//                     NomenclatureGroup = _context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Ортопедические материалы"),

//                     Manufacturer = _context.Manufacturers.FirstOrDefault(m => m.Name == "DMG"),
//                     #region описание
//                     Description = @"Карт-форма для заказа зубов Закономерности, характерные для пространственного взаимоотношения естественных зубов, должны в равной степени применяться и при изготовлении протезов. При разработке боковых зубов Bonartic® II NFC+ их высокие функциональные свойства были адаптированы соответственно современным эстетическим требованиям.

// Зубы Bonartic® II NFC+ сочетают в себе использование физиологических законов природы и эстетическо- морфологических требований с целью создания превосходного зубного протеза. Карт-форма для заказа зубов",
//                     #endregion
//                     Cost = 2400,
//                     Status = VisibleStatus.Visible,
//                     Amount = 10,
//                     Measurement = null,
//                    ImageUrl = "./Images/Product.jpg"
//                 },
//                 new Nomenclature
//                 {
//                     Name= @"ICON для инфильтрации кариеса вестибулярных поверхностей стартовый набор (DMG)",
//                     NomenclatureGroup = _context.NomenclatureGroups.FirstOrDefault(g => g.Name == "Ортопедические материалы"),

//                     Manufacturer = _context.Manufacturers.FirstOrDefault(m => m.Name == "Candulor"),
//                     #region описание
//                     Description = @"Набор DMG ICON - эффективное лечение кариеса без потери здоровых тканей зуба.

// В сотрудничестве с институтом Charite (Берлин) и универститетом г. Киль (Германия) была разработана система Icon для лечения начального кариеса - микроинвазивная, сохраняющая ткани зуба, простая в использовании, обеспечивающая безболезненное лечение в одно посещение.

// Показания:
// Микроинвазивное лечение ранних стадий кариеса на апроксимальных поверхностях (глубина поражения до D1*) и поражений эмали на вестибулярных поверхностях (например на стадии белого пятна, после снятия брекетов).

// Противопоказания:
// Запрещается использовать материал для полостей глубиной поражения от D2 до D3* или дефектов эмали, а также в цервикальных отделах с тонким слоем эмали или открытым дентином.",
//                     #endregion
//                     Cost = 5300,
//                     Status = VisibleStatus.Visible,
//                     Amount = 10,
//                     Measurement = null,
//                    ImageUrl = "./Images/Product.jpg"
//                 },
//             };
//             _context.Nomenclatures.AddRange(nomenclatures);
//             if (isNeedRandom)
//             {
//                 var randomNomenclatures = new List<Nomenclature>();
//                 for (int i = 0; i < 10000; i++)
//                 {
//                     Nomenclature nom = new Nomenclature();
//                     int length = random.Next(3, 10);
//                     nom.Name = this.GenRandomString(50);
//                     nom.NomenclatureGroupId = random.Next(1, 9);
//                     nom.ManufacturerId = Guid.NewGuid();
//                     nom.Status = VisibleStatus.Visible;
//                     nom.Cost = random.Next(0, 1000000);
//                     nom.Amount = random.Next(0, 10000);
//                     int image = random.Next(0, 3);
//                     nom.ImageUrl = image == 0 ? "./Images/Product.jpg" : "./Images/Product"+image+".jpg";
//                     nom.Description = this.GenRandomString(150);
//                     randomNomenclatures.Add(nom);
//                 }
//                 _context.Nomenclatures.AddRange(randomNomenclatures);
//             }
//             _context.SaveChanges();

//             var promotion = new Promotion { OfficialTitle = "Специальные предложения!", WorkTitle = "Спец",
//                 DiscountedNomenclatures = new List<Nomenclature>()
//             };
//             List<Nomenclature> nomec = new List<Nomenclature>();
//             if (isNeedRandom)
//             {
//                 for (int i = 0; i < 100; i++)
//                 {
//                     int nomId = random.Next(1, 1000 + nomenclatures.Count);
//                     Nomenclature nomenclature = _context.Nomenclatures.Find(nomId);
//                     nomec.Add(nomenclature);
//                 }
//             }
//             else
//                 nomec.AddRange(_context.Nomenclatures.ToList());
//             promotion.DiscountNomenclature(nomec, 10);
//             _context.Add(promotion);
//             _context.SaveChanges();


//             var orders = new List<Order>
//             {
//                 new Order
//                 {
//                     OrderDetails = new OrderDetails
//                     {
//                         UserId = 1,
//                         IsWithDelivery = true,
//                     },
//                     PaymentMethod = PaymentMethod.Bill,
//                     Status = OrderState.Confirmed,
//                     OrderItems = new System.Collections.ObjectModel.ObservableCollection<OrderItem>
//                     {
//                         new OrderItem { NomenclatureId = Guid.NewGuid(), ActualCount = 2, },
//                         new OrderItem { NomenclatureId = Guid.NewGuid(), ActualCount = 1, },
//                     }
//                 }
//             };
//             if(isNeedRandom)
//             {
//                 var randomOrders = new List<Order>();
//                 for (int i = 0; i < 5; i++)
//                 {
//                     OrderDetails orderDetails = new OrderDetails
//                     {
//                         UserId = 1,
//                         IsWithDelivery = true,
//                     };
                    
//                     Order order = new Order();
//                     order.OrderDetails = orderDetails;
//                     int paymentM = random.Next(0, Enum.GetValues(typeof(PaymentMethod)).Length - 1);
//                     order.PaymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentM.ToString());
//                     int status = random.Next(0, Enum.GetValues(typeof(OrderState)).Length - 1);
//                     for (int j = 0; j < random.Next(1,10); j++)
//                     {
//                         Guid nomId = Guid.NewGuid();
//                         int actualCount = random.Next(1, 100);
//                         OrderItem item = new OrderItem() { NomenclatureId = nomId, ActualCount = actualCount };
//                         order.OrderItems.Add(item);
//                     }
//                     randomOrders.Add(order);
//                 }
//                 _context.Orders.AddRange(randomOrders);
//             }
//             _context.Orders.AddRange(orders);

//             List<Page> pages = new List<Page> 
//             {
//                 new Page{OfficialTitle = "Доставка и оплата",WorkTitle="DeliveryAndPlay",PageLink="pages/home"},
//                 new Page{OfficialTitle = "Возврат",WorkTitle="Return",PageLink="pages/return"},
//                 new Page{OfficialTitle = "Пункт самовывоза",WorkTitle="PickupPoint",PageLink="pages/pickuppoint"},
//                 new Page{OfficialTitle = "Контакты",WorkTitle="Contacts",PageLink="pages/contacts"},
//                 new Page{OfficialTitle = "Новости",WorkTitle="News",PageLink="pages/news"},
//                 new Page{OfficialTitle = "Отзывы",WorkTitle="Reviews",PageLink="pages/Reviews"}
//             };
//             _context.Pages.AddRange(pages);
//             _context.SaveChanges();

//             _context.Database.OpenConnection();
//             try
//             {
//                 _context.SaveChanges();
//             }
//             finally { _context.Database.CloseConnection(); }
        }

        public override void RecreateDatabase(DbContext context, bool isNeedToInitializeData = false)
        {
            base.RecreateDatabase(context,isNeedToInitializeData);
            if(isNeedToInitializeData)
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
    }
}
