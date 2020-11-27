using Microsoft.AspNetCore.Mvc;
using SecretProject.VisualElements.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretProject.Services
{
    public class VisualRedactor
    {

        #region Model
        private JsonSerializerOptions serializeOptions;

        #endregion

        #region Properties

        #endregion

        #region Realization
        public VisualRedactor(JsonSerializerOptions serializeOptions)
        {
            this.serializeOptions = serializeOptions ?? throw new ArgumentNullException(nameof(serializeOptions));
        }
        #endregion

        #region Class Methods
        public JsonResult GetBackbone()
        {
            /////Header
            //    //ImageBlock - Логотип
            //    //LinksMenu
            //    //ContactBlock
            /////GrayBar
            //    //ComboBox - Каталог
            //    //SearchBar
            //    //Button - Корзина
            //    //Button - Страница пользователя
            /////Body
            //    //Banner
            //    //Slider - Спецпредложения
            //    //Slider - Хиты продаж
            //    //Button - Перейти к каталогу
            //    //InfoBlock - ...
            /////Footer
            //    //StayWithUsBlock
            Dictionary<string, object> backbone = new Dictionary<string, object>();
            Block header = new Block();
            backbone.Add("Header", header);
            Block grayLine = new Block();
            backbone.Add("GrayLine", grayLine);
            Block content = new Block();
            backbone.Add("Content", content);
            Block footer = new Block();
            backbone.Add("Footer", footer);
            return new JsonResult(backbone);
        }

        public JsonResult GetExplicitMockBackgone()
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

        public JsonResult GetVisualElementJson(object visualElement)
        {
            return new JsonResult(visualElement, serializeOptions);
        }
        public JsonResult GetVisualElementJson(IEnumerable<object> visualElements)
        {
            return new JsonResult(visualElements,serializeOptions);
        }
#if DEBUG
        public JsonResult GetAllJsonVisualObjects()
        {
            Dictionary<string, object> backbone = new Dictionary<string, object>();
            Block elements = new Block();
            backbone.Add("Elements", elements);
            Assembly visualAssembly = Assembly.GetAssembly(typeof(Block));
            foreach (Type type in visualAssembly.GetTypes())
            {
                if (!type.IsInterface && !type.IsAbstract && type.GetInterface("IVisualElement") != null)
                {
                    var elem = visualAssembly.CreateInstance(type.FullName);
                    if (elem != null)
                        elements.AddVisualElement(elem);
                }
            }
            return new JsonResult(backbone, serializeOptions);
        }
#endif
        #endregion
    }

    
}
