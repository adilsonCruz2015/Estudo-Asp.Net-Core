using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace ADC_Movie.Domain.Comand.MovieCmd.Validation
{
    public class InsertValidatorCmd : AbstractValidator<InsertCmd>
    {
        public InsertValidatorCmd()
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithMessage("{PropertyName} é inválido");

            RuleFor(g => g.Genre)
                .NotEmpty()
                .MaximumLength(250)
                .MinimumLength(2)
                .WithMessage("{PropertyName} é inválido");

            RuleFor(d => d.ReleaseDate)
                .NotEmpty()
                .WithMessage("{PropertyName} é inválido");

            RuleFor(c => c.Cpf)
                .ValidateCpf()
                .NotEmpty()
                .WithMessage("{PropertyName} não pode ser em branco");

            RuleFor(r => r.Rua)
                .NotEmpty()
                .WithMessage("{PropertyName} não pode ser em branco")
                .MaximumLength(250)
                .WithMessage("{PropertyName} deve ter no máximo 250 caracteres")
                .MinimumLength(20)
                .WithMessage("{PropertyName} deve ter no minimo 20 caracteres");

            RuleFor(s => s.Senha)
                .NotEmpty()
                .WithMessage("{PropertyName} não pode ser em branco")
                .MaximumLength(20)
                .WithMessage("{PropertyName} deve ter no máximo 20 caracteres")
                .MinimumLength(5)
                .WithMessage("{PropertyName} deve ter no minimo 5 caracteres")
                .Equal(s => s.ConfirmaSenha)
                .WithMessage("O valor do campo: {PropertyName} deve ser igual a {PropertyValue}"); ;
        }
    }

    public static class MovieValidatorExtension
    {
        public static IRuleBuilderOptions<T, TElement> ValidateCpf<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, valor, context) =>
            {
                return Check(valor);

            })
            .WithMessage("{PropertyName} não é válido");
        }


        private static bool Check(object value)
        {
            string input = Convert.ToString(value);

            Boolean retorno;
            string pattern;
            Regex regex;

            retorno = false;

            // Checando se tem apenas números
            pattern = @"^([0-9]{11})$|^([0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2})$";
            regex = new Regex(pattern);
            retorno = regex.Match(input).Success;
            //Checando se não são 11 dígitos iguais
            if (retorno == true)
            {
                input = input.Replace("-", "");
                input = input.Replace(".", "");
                pattern = @"^([1]{11}|[2]{11}|[3]{11}|[4]{11}|[5]{11}|[6]{11}|[7]{11}|[8]{11}|[9]{11}|[0]{11})$";
                regex = new Regex(pattern);
                retorno = !regex.Match(input).Success;
            }

            if (retorno == true)
            {
                /**/
                // Para validar calculamos usando os 9 primeiro dígito
                string cpf = input.Substring(0, 9);
                int soma;
                int resto = 0;
                int quociente = 0;
                int primeiroDigito = 0;
                int segundoDigito = 0;
                int multiplicador;
                // Calculando o primeiro dígito
                multiplicador = 10;
                soma = 0;
                for (int indice = 0; indice < cpf.Length; indice++)
                {
                    soma += (int.Parse(cpf[indice].ToString()) * multiplicador);
                    multiplicador--;
                }
                resto = soma % 11;
                quociente = (soma - resto) / 11;
                if (resto < 2)
                {
                    primeiroDigito = 0;
                }
                else
                {
                    primeiroDigito = 11 - resto;
                }
                // Calculando o segundo dígito
                // para calcular adicionamos o digito ao cpf
                cpf = cpf + primeiroDigito.ToString();
                multiplicador = 11;
                soma = 0;
                for (int indice = 0; indice < cpf.Length; indice++)
                {
                    soma += (int.Parse(cpf[indice].ToString()) * multiplicador);
                    multiplicador--;
                }
                resto = soma % 11;
                quociente = (soma - resto) / 11;
                if (resto < 2)
                {
                    segundoDigito = 0;
                }
                else
                {
                    segundoDigito = 11 - resto;
                }
                // Para finalizar adicionamos o digito ao cpf
                cpf = cpf + segundoDigito.ToString();
                // Agora que obtivemos um cpf completo comparamos o resultado com o informado
                return (input == cpf);
            }

            return false;
        }
    }
}
