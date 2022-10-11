using DataAccsess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinies.FluentValidations
{
    public class ValidationCampaings:AbstractValidator<Campaings>
    {
        public ValidationCampaings()
        {
            RuleFor(x => x.Campaignname).MaximumLength(100).WithMessage("250 Karakterden Fazla Olamaz").MinimumLength(5).WithMessage("5 Karakterden Az Olamaz");
            RuleFor(x => x.Campaigndetail).MaximumLength(500).WithMessage("500 Karakterden Fazla Olamaz").MinimumLength(5).WithMessage("5 Karakterden Az Olamaz");
            
        }
    }
}

