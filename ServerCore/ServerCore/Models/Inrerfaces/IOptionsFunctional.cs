using ServerCore.Models.Classes;
using System.Collections.Generic;

namespace ServerCore.Models.Inrerfaces
{
    public interface IOptionsFunctional
    {
        void Create(Option option);
        Option Get(int IdOption);
        List<Option> GetOptions();
    }
}
