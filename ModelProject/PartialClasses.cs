using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject
{
    [MetadataType(typeof(CodigoPostalMetaData))]
    public partial class CodigoPostal
    { }

    [MetadataType(typeof(InformacoesUteisMetaData))]
    public partial class InformacoesUteis
    { }

    [MetadataType(typeof(OcorrenciasMetaData))]
    public partial class Ocorrencias
    { }

    [MetadataType(typeof(TipoOcorrenciasMetaData))]
    public partial class TipoOcorrencias
    { }

    [MetadataType(typeof(TipoUtilizadorMetaData))]
    public partial class TipoUtilizador
    { }

    [MetadataType(typeof(UtilizadoresMetaData))]
    public partial class Utilizadores
    {}

    

    
}
