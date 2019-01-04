using Katalog_v_2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog_v_2.Models.Interface
{
    interface IBludo: IModelService
    {
        void AddRezept(Rezept rezept);
        Rezept GetRezept(string name, int Bludo_id);
    }
}
