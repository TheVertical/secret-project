using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Common;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.VisualElements;
using SecretProject.VisualElements.Elements;
using SecretProject.VisualElements.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretProject.Services
{
    //список страниц <-
    //репозиторий / контекст данных
    //логер
    //настройки сериализации


    public class VisualRedactor : IVisualRedactor,IDisposable
    {
        #region Model
        private JsonSerializerOptions settings;
        private DbContext context;
        private IRepository repository;
        private ILogger<VisualRedactor> logger;
        #endregion
        #region Realization
        //TODO Оставить что-то одно, либо repository, либо context!
        public VisualRedactor(JsonSerializerOptions settings, ILogger<VisualRedactor> logger, DbContext context, IRepository repository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        
        #endregion

        #region Class Methods
        private DropdownItem CreateDropdownItem(NomenclatureGroup group)
        {
            if (group.Status == VisibleStatus.Hidden)
                return null;

            DropdownItem item = new DropdownItem();
            item.Title = group.Name;
            item.Route = $"catalog/category/{group.Id}";
            if (group.Childs == null)
                return item;
            item.Items = new List<DropdownItem>();
            foreach(var child in group.Childs)
            {
                DropdownItem childItem = CreateDropdownItem(child);
                item.Items.Add(childItem);
            }
            return item;
        }

        private DropdownMenu CreateDropDownMenu(IEnumerable<NomenclatureGroup> parents)
        {
            if (parents == null)
                return null;
            if (parents.Count() == 0)
                return null;

            DropdownMenu dropdownMenu = new DropdownMenu();

            foreach (var parent in parents)
            {
                DropdownItem item = CreateDropdownItem(parent);
                dropdownMenu.Items.Add(item);
            }
            return dropdownMenu;
        }
        private void createBackbone()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();

            Block header = new Block();
            #region блоки
            ImageBlock logo = new ImageBlock { Id = 0, Alt = "Логотип компании", Source = "./Images/logo.png", NeededColumns = 3 };
            header.AddVisualElement(logo);

            var pages = context.Set<Page>().ToList();

            LinksMenu linksMenu = new LinksMenu { NeededColumns=6};
            linksMenu.IsHorizontal = true;
            foreach(var page in pages)
            {
                LinkItem link = new LinkItem(page.Id,page.OfficialTitle,page.PageLink);
                linksMenu.Links.Add(link);
            }
            header.AddVisualElement(linksMenu);
            var companyContacts = context.Set<Company>().Where(c => c.Name == "Olimp-dental").FirstOrDefault();
            if (companyContacts != null)
            {
                ContactBlock contactblock = new ContactBlock()
                {
                    Id = companyContacts.Id,
                    NeededColumns = 3,
                    JustyfyContent = "end",
                    OpeningHours = companyContacts.WorkHours,
                    Phone = companyContacts.WorkPhone.ToString(),
                    IsHeaderStyle = true
                };
                header.AddVisualElement(contactblock);
            }
            #endregion
            backbone.Add("Header", header);

            Block grayLine = new Block();
            #region блоки
            var categories = repository.GetAll<NomenclatureGroup, bool>(nom => nom.Parent == null, true);
            DropdownMenu dropdownMenu = CreateDropDownMenu(categories);

            ComboBoxButton catalog = new ComboBoxButton { Id = 0, Title = "Каталог", Action = null, NeededColumns = 2, DropdownMenu = dropdownMenu };
            grayLine.AddVisualElement(catalog);

            Button learn = new Button { Id = 1, Title = "Обучение", NeededColumns = 2 };
            grayLine.AddVisualElement(learn);

            Button impl = new Button { Id = 2, Title = "Имплантация", NeededColumns = 2 };
            grayLine.AddVisualElement(impl);

            VisualSearch visualSearch = new VisualElements.Elements.VisualSearch { Id = 3, NeededColumns = 4 };
            grayLine.AddVisualElement(visualSearch);

            Button basket = new Button { Id = 4, Image = "./Images/shopLogo.png", Action = "/cart", NeededColumns = 1 };
            grayLine.AddVisualElement(basket);
            Button auth = new Button { Id = 5, Image = "./Images/profileLogo.png", Action = "/account", NeededColumns = 1 };
            grayLine.AddVisualElement(auth);

            #endregion
            backbone.Add("GrayLine", grayLine);

            Block footer = new Block();
            #region блоки

            Block linksBlock = new Block();
            footer.AddVisualElement(linksBlock);
            //ПОКА СТАТИКА
            LinksMenu links = new LinksMenu
            {
                Id = 1,
                MainTitle = "Моя учётная запись",
                IsHorizontal = false,
                NeededColumns = 4,
                AlignContent="start",
                Links = new List<LinkItem>
                {
                    new LinkItem (0,"Войти","#"),
                    new LinkItem (1,"Создать учётную запись","#"),
                }

            };
            linksBlock.AddVisualElement(links);
            //ПОКА СТАТИКА
            links = new LinksMenu
            {
                Id = 1,
                MainTitle = "Магазин",
                IsHorizontal = false,
                NeededColumns = 2,
                AlignContent="start",
                Links = new List<LinkItem>
                {
                    new LinkItem (0,"О нас","#"),
                    new LinkItem (1,"Отзывы о магазине","#"),
                    new LinkItem (2,"Обратная связь","#"),
                    new LinkItem (3,"Карта сайта","#"),
                }

            };
            linksBlock.AddVisualElement(links);
            //ПОКА СТАТИКА
            links = new LinksMenu
            {
                Id = 1,
                MainTitle = "Покупательский сервис",
                IsHorizontal = false,
                NeededColumns = 3,
                AlignContent="start",
                Links = new List<LinkItem>
                {
                    new LinkItem (0,"Ваши заказы","#"),
                    new LinkItem (1,"Отложенные","#"),
                    new LinkItem (2,"Список сравнения","#"),
                }

            };
            linksBlock.AddVisualElement(links);
            //ПОКА СТАТИКА
            var _contactblock = new ContactBlock()
            {
                Id = 0,
                NeededColumns = 3,
                Image = "./Images/LogoDown.png",
                OpeningHours = "Пн-Чт:10:00 - 18:00, Пт:10:00 - 17:00",
                Phone = "8 (812) 388-4538",
                CssStyle = "ContactBlock_FooterStyle"
            };
            linksBlock.AddVisualElement(_contactblock);
            #endregion
            backbone.Add("Footer", footer);

            string json = JsonSerializer.Serialize<Dictionary<string, object>>(backbone, settings);
            FileInfo file = new FileInfo("Files/Backbone.json");
            using (StreamWriter writer = file.CreateText())
            {
                writer.Write(json);
            }
        }
        #endregion
        #region Interface's Methods
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
            return new JsonResult(list, settings);
        }

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
            return new JsonResult(elements, settings);
        }

        public bool Clear(string page)
        {
            logger.LogDebug($"Try clear {page}.json");
            FileInfo file = new FileInfo($"Files/{page}.json");
            if (!file.Exists)
            {
                logger.LogDebug($"Unsuccessful clear of {page}.json! File not exists!");
                return false;
            }
            else
            {
                logger.LogDebug($"Successful clear of {page}.json!");
                file.Delete();
            }
            file = null;

            return true;
        }

        public object GetBackbone()
        {
            string path = "Files/Backbone.json";
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
                createBackbone();
            FileStream fs = new FileStream(path, FileMode.Open);
            return fs;
        }

        public object GetFormattedElement(object element)
        {
            return new JsonResult(element, settings);
        }

        public object GetFormattedElement(IEnumerable<object> element)
        {
            return new JsonResult(element, settings);
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
                        result = new JsonResult(elem, settings);
                        break;
                    }
                    catch (Exception ex) { logger.Log(LogLevel.Debug, ex.Message); }

                }
            }
            return result;
        }

        public void Dispose()
        {
            context = null;
        }
        #endregion

    }

    
}
