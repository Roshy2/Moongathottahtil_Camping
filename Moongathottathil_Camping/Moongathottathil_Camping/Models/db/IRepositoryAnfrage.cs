using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongathottathil_Camping.Models.db
{
    interface IRepositoryAnfrage
    {
        void Open();
        void Close();
        bool Insert(Campingplatzreservierung campres);

    }
}
