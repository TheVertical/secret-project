using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.VisualElements;
using SecretProject.VisualElements.Elements;
using SecretProject.WebApi.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Services
{
    public class MockJsonVisualRedactor : IVisualRedactor, IDisposable
    {
        private readonly IRepository repository;

        #region Model
        //Home
        //Каталог
        //Страница товара
        //Страница успешной регистрации
        //Корзина
        //404

        private ILogger<MockJsonVisualRedactor> logger;
        private JsonSerializerOptions serializeOptions;

        #endregion

        #region Realization
        public MockJsonVisualRedactor(IRepository repository, ILogger<MockJsonVisualRedactor> logger, JsonSerializerOptions serializeOptions)
        {
            this.repository = repository;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.serializeOptions = serializeOptions ?? throw new ArgumentNullException(nameof(serializeOptions));
        }
        #endregion

        #region Interface's Methods
        public object GetAllVisualElements()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();
            Block elements = new Block();
            backbone.Add("Elements", elements);

            Assembly visualAssembly = Assembly.GetAssembly(typeof(Block));

            foreach (Type type in visualAssembly.GetTypes())
            {
                if (!type.IsInterface && !type.IsAbstract && type.GetInterface("IVisualElement") != null)
                {
                    try
                    {
                        var elem = visualAssembly.CreateInstance(type.FullName);
                        if (elem != null)
                        {
                            logger.Log(LogLevel.Debug, $"Visual element of {type.Name} type.");
                            foreach (PropertyInfo prop in type.GetProperties())
                            {
                                logger.Log(LogLevel.Debug, $"It is setted default value to property {prop.Name}");
                                var setMethod = prop.GetSetMethod(false);
                                if (setMethod == null)
                                    continue;
                            }
                            elements.AddVisualElement(elem);
                        }
                    }
                    catch (Exception ex) { logger.Log(LogLevel.Debug, ex.Message); }

                }
            }
            return new JsonResult(elements, serializeOptions);
        }
        public object GetAllViewModels()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();
            ArrayList list = new ArrayList();
            backbone.Add("Models", list);

            Assembly visualAssembly = Assembly.GetAssembly(typeof(Block));

            foreach (Type type in visualAssembly.GetTypes())
            {
                if (!type.IsInterface && !type.IsAbstract && type.GetInterface("IViewModel") != null)
                {
                    try
                    {
                        var elem = visualAssembly.CreateInstance(type.FullName);
                        if (elem != null)
                        {
                            foreach (PropertyInfo prop in type.GetProperties())
                            {
                                var setMethod = prop.GetSetMethod(false);
                                if (setMethod == null)
                                    continue;
                            }
                            list.Add(elem);
                        }
                    }
                    catch (Exception ex) { logger.Log(LogLevel.Debug, ex.Message); }

                }
            }
            return new JsonResult(list, serializeOptions);
        }
        public object GetBackbone()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();

            Block header = new Block();
            #region блоки
            ImageBlock logo = new ImageBlock { Id = 0, Alt = "Логотип компании", Source = "./Images/logo.png", NeededColumns = 3 };
            header.AddVisualElement(logo);
            LinksMenu linksMenu = new LinksMenu
            {
                Id = 0,
                IsHorizontal = true,
                NeededColumns = 3,
                Links = new List<LinkItem>
                {
                    new LinkItem (0,"Доставка и оплата","/first"),
                    new LinkItem (1,"Возврат","/second"),
                    new LinkItem (2,"Пункт самовывоза","/"),
                    new LinkItem (3,"Контакты","#"),
                    new LinkItem (4,"Контакты","#"),
                    new LinkItem (5,"Новости","#"),
                    new LinkItem (6,"Акции и скидки","#"),
                    new LinkItem (7,"Отзывы","#"),
                }
            };
            header.AddVisualElement(linksMenu);

            ContactBlock contactblock = new ContactBlock()
            {
                Id = 0,
                NeededColumns = 2,
                OpeningHours = "Пн-Чт:10:00 - 18:00, Пт:10:00 - 17:00",
                Phone = "8 (812) 388-4538"
            };
            header.AddVisualElement(contactblock);
            #endregion
            backbone.Add("Header", header);

            Block grayLine = new Block();
            #region блоки
            DropdownMenu dropdownMenu = new DropdownMenu();
            var categories = repository.GetAll<NomenclatureGroup, bool>(nom => nom.Parent == null, true);

            foreach (var car in categories)
            {
                dropdownMenu.Items.Add(new DropdownItem { Title = car.Name, Route = "#", Items = null });
            }

            ComboBoxButton catalog = new ComboBoxButton { Id = 0, Title = "Каталог", Action = "#", NeededColumns = 2, DropdownMenu = dropdownMenu };
            grayLine.AddVisualElement(catalog);
            ComboBoxButton learning = new ComboBoxButton { Id = 1, Title = "Каталог", Action = "#", NeededColumns = 2, DropdownMenu = null };
            grayLine.AddVisualElement(learning);
            ComboBoxButton implanting = new ComboBoxButton { Id = 2, Title = "Каталог", Action = "#", NeededColumns = 2, DropdownMenu = null };
            grayLine.AddVisualElement(implanting);

            Button basket = new Button { Id = 3, Image = "shopLogo", Action = "#", NeededColumns = 1 };
            grayLine.AddVisualElement(basket);
            Button auth = new Button { Id = 4, Image = "profileLogo", Action = "#", NeededColumns = 1 };
            grayLine.AddVisualElement(auth);

            #endregion
            backbone.Add("GrayLine", grayLine);

            Block footer = new Block();
            #region блоки
            Label stayOnLink = new Label() { Id = 0, NeededColumns = 6, Text = "Оставайтесь на связи" };
            footer.AddVisualElement(stayOnLink);

            LinksMenu links = new LinksMenu
            {
                Id = 1,
                MainTitle = "Моя учётная запись",
                IsHorizontal = false,
                NeededColumns = 3,
                Links = new List<LinkItem>
                {
                    new LinkItem (0,"Войти","#"),
                    new LinkItem (1,"Создать учётную запись","#"),
                }

            };
            footer.AddVisualElement(links);

            links = new LinksMenu
            {
                Id = 1,
                MainTitle = "Магазин",
                IsHorizontal = false,
                NeededColumns = 3,
                Links = new List<LinkItem>
                {
                    new LinkItem (0,"О нас","#"),
                    new LinkItem (1,"Отзывы о магазине","#"),
                    new LinkItem (2,"Обратная связь","#"),
                    new LinkItem (3,"Карта сайта","#"),
                }

            };
            footer.AddVisualElement(links);

            links = new LinksMenu
            {
                Id = 1,
                MainTitle = "Покупательский сервис",
                IsHorizontal = false,
                NeededColumns = 3,
                Links = new List<LinkItem>
                {
                    new LinkItem (0,"Ваши заказы","#"),
                    new LinkItem (1,"Отложенные","#"),
                    new LinkItem (2,"Список сравнения","#"),
                }

            };
            footer.AddVisualElement(links);

            contactblock = new ContactBlock()
            {
                Id = 0,
                NeededColumns = 2,
                OpeningHours = "Пн-Чт:10:00 - 18:00, Пт:10:00 - 17:00",
                Phone = "8 (812) 388-4538"
            };

            #endregion
            backbone.Add("Footer", footer);

            string json = JsonSerializer.Serialize<Dictionary<string, object>>(backbone, serializeOptions);
            FileInfo file = new FileInfo("Backbone.json");
            using (StreamWriter writer = file.CreateText())
            {
                writer.Write(json);
            }
            return new JsonResult(backbone, serializeOptions);
        }
        public object GetBackbone(bool expl)
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();

            Block header = new Block();

            ImageBlock logo = new ImageBlock { Id = 0, Alt = "Логотип компании", Source = "#" };
            header.AddVisualElement(logo);
            LinksMenu linksMenu = new LinksMenu
            {
                Id = 0,
                Links = new List<LinkItem>{
                new LinkItem (0,"#","Доставка и оплата_1 " ), new LinkItem(0, "#", "Доставка и оплата_2") }
            };
            header.AddVisualElement(linksMenu);
            ContactBlock contactblock = new ContactBlock() { Id = 0, OpeningHours = "openingHours", Phone = "8 (812) 388-4538" };
            header.AddVisualElement(contactblock);

            backbone.Add("Header", header);
            Block grayLine = new Block();
            backbone.Add("GrayLine", grayLine);
            Block content = new Block();
            backbone.Add("Content", content);
            Block footer = new Block();
            backbone.Add("Footer", footer);
            return new JsonResult(backbone, serializeOptions);
        }
        public object GetFormattedElement(object element)
        {
            return new JsonResult(element, serializeOptions);
        }
        public object GetVisualElementByName(string name)
        {
            Assembly visualAssembly = Assembly.GetAssembly(typeof(Block));
            JsonResult result = null;
            foreach (Type type in visualAssembly.GetTypes())
            {
                if (!type.IsInterface && !type.IsAbstract && type.GetInterface("IVisualElement") != null && type.Name.Contains(name))
                {
                    try
                    {
                        var elem = visualAssembly.CreateInstance(type.FullName);
                        if (elem != null)
                        {
                            logger.Log(LogLevel.Debug, $"Visual element of {type.Name} type.");
                            foreach (PropertyInfo prop in type.GetProperties())
                            {
                                logger.Log(LogLevel.Debug, $"It is setted default value to property {prop.Name}");
                                var setMethod = prop.GetSetMethod(false);
                                if (setMethod == null)
                                    continue;
                            }
                        }
                        result = new JsonResult(elem, serializeOptions);
                        break;
                    }
                    catch (Exception ex) { logger.Log(LogLevel.Debug, ex.Message); }

                }
            }
            return result;
        }
        public object GetFormattedElement(IEnumerable<object> element)
        {
            return new JsonResult(element, serializeOptions);
        }

        #region Async
        public async Task<object> GetAllVisualElementsAsync()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();
            Block elements = new Block();
            backbone.Add("Elements", elements);

            Assembly visualAssembly = Assembly.GetAssembly(typeof(Block));

            foreach (Type type in visualAssembly.GetTypes())
            {
                if (!type.IsInterface && !type.IsAbstract && type.GetInterface("IVisualElement") != null)
                {
                    try
                    {
                        var elem = visualAssembly.CreateInstance(type.FullName);
                        if (elem != null)
                        {
                            logger.Log(LogLevel.Debug, $"Visual element of {type.Name} type.");
                            foreach (PropertyInfo prop in type.GetProperties())
                            {
                                logger.Log(LogLevel.Debug, $"It is setted default value to property {prop.Name}");
                                var setMethod = prop.GetSetMethod(false);
                                if (setMethod == null)
                                    continue;
                            }
                            elements.AddVisualElement(elem);
                        }
                    }
                    catch (Exception ex) { logger.Log(LogLevel.Debug, ex.Message); }

                }
            }
            var result = new JsonResult(elements, serializeOptions);
            return result;
        }

        public void Dispose()
        {
            serializeOptions = null;
            logger = null;
        }

        public bool Clear(string page)
        {
            throw new NotImplementedException();
        }
        //public async Task<ResultType> GetBackboneAsync<ResultType>()
        //{
        //    Json
        //}
        //public async Task<ResultType> GetFormattedVisualElementAsync<ResultType>(object element)
        //    {}
        //public async Task<ResultType> GetFormattedVisualElementAsync<ResultType>(IEnumerable<object> element)
        //    {}
        //public async Task<ResultType> GetAllVisualElementsAsync<ResultType>()
        //    {}
        #endregion
        #endregion

    }
}
