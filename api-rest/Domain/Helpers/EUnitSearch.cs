using System.ComponentModel;

namespace api_rest.Domain.Helpers
{
    public enum EUnitSearch : byte
    {
        [Description("MaterialEscolar")]
        MaterialEscolar = 1,

        [Description("ArtigosViagem")]
        ArtigosViagem = 2,

        [Description("ItensEsportivos")]
        ItensEsportivos = 3,

        [Description("Informatica")]
        Informatica = 4

    }

}
