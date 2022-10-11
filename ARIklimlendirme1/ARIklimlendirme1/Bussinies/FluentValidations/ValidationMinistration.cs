using DataAccsess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinies.FluentValidations
{
    public class ValidationMinistration : AbstractValidator<Ministration>
    {
        public ValidationMinistration()
        {
            RuleFor(x => x.Ministrationname).MaximumLength(70).WithMessage("70 Karakterden Fazla Olamaz");
            RuleFor(x => x.Ministrationname).NotEmpty().WithMessage("Hizmet Adı girmelisiniz");
            RuleFor(x => x.Ministrationdescription).MaximumLength(250).WithMessage("250 Karakterden Fazla Olamaz");
            RuleFor(x => x.Ministrationdescription).NotEmpty().WithMessage("Hizmet Açıklaması girmelisiniz");
            RuleFor(x => x.Images).MaximumLength(100).WithMessage("100 Karakterden Fazla Olamaz");
            RuleFor(x => x.Images).NotEmpty().WithMessage("Fotoğraf yüklemelisiniz");
            RuleFor(x => x.Ministrationprovided).MaximumLength(500).WithMessage("500 Karakterden Fazla Olamaz");
            RuleFor(x => x.Ministrationprovided).NotEmpty().WithMessage("Sağlanan hizmet bilgisi girmelisiniz");
            
        }
    }
}
