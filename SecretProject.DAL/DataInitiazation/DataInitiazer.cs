using System;
using SecretProject.BusinessProject.Models;
using Microsoft.EntityFrameworkCore;
using SecretProject.DAL.Contexts;
using System.Collections.Generic;
using System.Linq;
using SecretProject.BusinessProject.Measurements;

namespace SecretProject.DAL.DataInitiazation
{
    public class DataInitiazer
    {
        #region Class Methods
        public static void InitializeData(sBaseContext context)
        {
            //var nomenclatureGroups = new List<NomenclatureGroup>
            //{
            //    new NomenclatureGroup { Name = "Дезинфекция",OcObject = new Guid("1c624b18-6dcb-11ea-80c1-e0d55e4ac020")},
            //    new NomenclatureGroup { Name = "Упаковочные материалы",OcObject = new Guid("4101828e-6dcd-11ea-80c1-e0d55e4ac020")},
            //    new NomenclatureGroup { Name = "Пакеты",OcObject = new Guid("6d28ef0b-6dcd-11ea-80c1-e0d55e4ac020")}

            //};
            //nomenclatureGroups.ForEach(x => context.NomenclatureGroups.Add(x));

            //var measurements = new List<Measurement>
            //{
            //    new Measurement{ocCode = 796,Name = "Штука", InternationalName = "PCE"}
            //};

            //var nomenclature = new List<Nomenclature>
            //{
            //    new Nomenclature{Name="Пакет для стер. \"СТЕРИТ\" Плоский Самоклеящиеся 250Х400 упаковка 100 шт.",
            //        OcObject=new Guid("fb40124b-6e9a-11ea-80c1-e0d55e4ac020"),
            //        NomenclatureGroup = context.NomenclatureGroups.FirstOrDefault(g => g.OcObject.ToString() == "6d28ef0b-6dcd-11ea-80c1-e0d55e4ac020"),
            //        Manufacturer = new Manufacturer {Name = "НПФ «ВИНАР»",OcObject = new Guid("e7ca0743-6dd6-11ea-80c1-e0d55e4ac020") },
            //        Description = "Пакеты комбинированные самоклеящиеся для паровой, этиленоксидной, пароформальдегидной и радиационной стерилизации «СтериТ» " +
            //        "легко проницаемы для соответствующего стерилизующего агента, в закрытом виде непроницаемы для микроорганизмов," +
            //        " сохраняют целостность после стерилизации соответствующим методом.",
            //        }
            //};
        }
        #endregion
    }
}
