using Inc.MyFamily.Shared.Models;

namespace Inc.MyFamily.Shared.Constants
{
    public static class ErrorMessages
    {
        public const string AuthErrorMessage = "Usuario ou senha invalidos!";
        public const string NotFoundMessage = "{0}, não encontrado";
        public const string ExampleErrorMensage = "Exemplo de mensagem de erro";

        public static readonly ErrorMessage ErrorCommunicatingWithService = new("45.06", "Error communicating with service.");
        public static readonly ErrorMessage ErrorCommunicatingAuthenticate = new("45.05", "Error authenticacao with CRMv2.");
        //public static readonly ErrorMessageBuilder ServicesUnexpectedError = new("45.07", "Unexpected error at {0} on {1}.");

        public static readonly string NomeNotByEmpity = "Nome não pode ser vazio ou nulo!";
        public static readonly string EmailNotByEmpity = "Email não pode ser vazio ou nulo!";
        public static readonly string SenhaNotByEmpity = "Senha não pode ser vazio ou nulo!";
        public static readonly string SOAPIntegrationError = "Ocorreu um erro ao tentar fazer uma consulta no webService do UAU.";

        public static readonly string RESTIntegrationError = "Ocorreu um erro ao tentar fazer uma consulta na API do UAU, DataResponse: {0}";
        public static readonly string UAUErrorsComunication = "Não conseguimos nos comunicar com o UAU.";

        public static readonly string AuthenticateError = "Token Invalido ou Usuario não Autenticado.";
        public static readonly string AuthenticateValidationError = "Ocorreu um erro ao realizar a autenticação, não foi possível verificar os dados de login.";

        public static readonly string DateBiggerThenDateNow = "A data de calculo precisa ser maior do que a data atual.";

        public static readonly string RegisterNotFound = "Não consegui encontrar esse registro no banco Capys. {0}";
        public static readonly string EmailError = "Não conseguimos fazer o envio do email :(.";
        public static readonly string RecuperarSenhaTimeOut = "Não foi possivel alterar sua senha, code invalido.";
        public static readonly string UserUAUError = "Não encontramos nenhum usuario valido, entre em contato com o setor de relacionamento da FGR. ";
        public static readonly string UserUAUSimpleError = "Não encontramos nenhum usuario valido, entre em contato com o nosso setor de relacionamento. ";

        public static readonly string UserUAUCapysError = "Não encontramos nenhum usuario valido, entre em contato com o setor de relacionamento.";


        public static readonly string DisabilitaFinanceiroBancoError = "Prezado cliente, para informações antecipação, entre em contato com a equipe de relacionamento do cliente.";

        public static readonly string DisabilitaFinanceiroError = "Este empreendimento não esta disponivel para antecipação de parcelas, por favor entrar em contato com o setor de relacionamento da FGR.";
        public static readonly string DisabilitaFinanceiroCapysError = "Este empreendimento não esta disponivel para antecipação de parcelas, por favor entrar em contato com o setor de relacionamento da FGR.";
        public static readonly string ErrorMensagemAntecipacaoRetroativa = "Não e possivel fazer antecipação de parcelas intermediárias, por favor selecione a parcela com maior vencimento";
        public static readonly string ErrorMensagemBoletoQuitados = "Não e possivel realizar uma antecipação com boletos em aberto no contrato.";
        public static readonly string ErrorMensagemAntecipacaoEmDia = "Não e possivel realizar uma antecipação com parcelas em aberto no contrato.";
        public static readonly string CarteiraSecuritizadaError = "Conforme comunicado, a parte financeira de seu contrato não é atendida mais pela FGR. Gentileza, entrar em contato com o banco responsável que consta em seu boleto.";
    }
}
