﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject
{
    // Atribuir diferentes nomes aos campos das tabelas na BD

    class CodigoPostalMetaData
    {
        public int ID { get; set; }
        [Display(Name = "Nº Código Postal")]
        [StringLength(8)] // Máximo 8 caracteres xxxx-xxx
        public string Codigo { get; set; }
        [Display(Name = "Nome da Localidade")]
        public string Localidade { get; set; }
    }

    class InformacoesUteisMetaData
    {
        public int ID { get; set; }
        [Required]
        public string Assunto { get; set; }
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }
        [Display(Name = "Destinatário")]
        public Nullable<int> Destinatario { get; set; }
        [Display(Name = "Código Postal")]
        public Nullable<int> IdCodigoPostal { get; set; }
    }

    class OcorrenciasMetaData
    {
        public int ID { get; set; }
        [Display(Name = "Nome Utilizador")]
        public int IdUtilizador { get; set; }
        [Display(Name = "Tipo de Ocorrência")]
        public int IdOcorrencias { get; set; }
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }
        public string Anexos { get; set; }
    }

    class TipoOcorrenciasMetaData
    {
        public int ID { get; set; }
        [Display(Name = "Designação")]
        public string Designacao { get; set; }
        [Display(Name = "Utilizadores Permitidos")]
        public Nullable<int> PermissoesUtilizador { get; set; }
    }

    class TipoUtilizadorMetaData
    {
        public int ID { get; set; }
        [Display(Name = "Tipo de Utilizador")]
        public string Tipo { get; set; }
        [Display(Name = "Id Permissão")]
        public string RoleID { get; set; }

    }

    class UtilizadoresMetaData
    {
        public int ID { get; set; }
        [Display(Name = "Nome Completo")]
        [Required]
        public string Nome { get; set; }
        [Display(Name = "Nº Identificação")]
        [Required]
        public int NumCC { get; set; }
        [Display(Name = "Nº Eleitor")]
        public Nullable<int> NumEleitor { get; set; }
        [Required]
        public string Morada { get; set; }
        [Display(Name = "Código Postal")]
        [Required]
        public Nullable<int> IdCodigoPostal { get; set; }
        public string Email { get; set; }
        [Display(Name = "Nome de Utilizador")]
        public string NomeUtilizador { get; set; }
        public string Password { get; set; }
        [Range(0, 1)] // Entre 0 e 1
        public byte Estado { get; set; }
        [Display(Name = "Tipo de Utilizador")]
        public Nullable<int> Tipo { get; set; }
        public string UserID { get; set; }
    }
}
