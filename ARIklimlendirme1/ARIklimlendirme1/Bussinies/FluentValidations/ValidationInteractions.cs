using DataAccsess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinies.FluentValidations
{
    public class ValidationInteractions: AbstractValidator<Interactions>
    {
        public ValidationInteractions()
        {
            RuleFor(x => x.Name).MaximumLength(25).WithMessage("25 Karakterden Fazla Olamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adınızı girmelisiniz");
            RuleFor(x => x.Surname).MaximumLength(25).WithMessage("25 Karakterden Fazla Olamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad girmelisiniz");
            RuleFor(x => x.Address).MaximumLength(150).WithMessage("150 Karakterden Fazla Olamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres bilgisi girmelisiniz");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Doğru EMail giriniz");
            RuleFor(x => x.Faultdetail).MaximumLength(500).WithMessage("500 Karakterden Fazla Olamaz");
            RuleFor(x => x.Faultdetail).NotEmpty().WithMessage("Arıza bilgisi girmelisiniz");
            RuleFor(x=> x.dateTime).NotEmpty().WithMessage("Tarih bilgisi girmelisiniz");
        }
    }
}
