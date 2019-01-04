using Katalog_v_2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_v_2.Models.Interface
{
    interface IBludo
    {
        BludoModel GetElement(int id);

        void AddElement(BludoModel model);

        List<BludoModel> GetList();

        void AddRezept(RezeptModel model);

        void DelElement(int id);
    }
}
