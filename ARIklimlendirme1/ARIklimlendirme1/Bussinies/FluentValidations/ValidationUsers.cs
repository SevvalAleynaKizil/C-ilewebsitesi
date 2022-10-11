using DataAccsess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinies.FluentValidations
{
    public class ValidationUsers : AbstractValidator<Users>
    {
        public ValidationUsers()
        {
            RuleFor(x => x.Username).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı girmelisiniz");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("20 Karakterden Fazla Olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrenizi girmelisiniz");
        }
    }
}
