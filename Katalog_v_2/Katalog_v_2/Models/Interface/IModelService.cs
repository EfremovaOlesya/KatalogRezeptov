using Katalog_v_2.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_v_2.Service
{
    interface IModelService
    {
        AModel GetElement(int id);

        void AddElement(AModel model);

        List<AModel> GetList();

        void DelElement(int id);

        void UpdateElement(AModel model);
    }
}
