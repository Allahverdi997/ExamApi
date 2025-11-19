using Application.Models.Request.Core.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz.")
                .MinimumLength(3).WithMessage("İstifadəçi adı ən az 3 simvol olmalıdır.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifrə boş ola bilməz.")
                .MinimumLength(6).WithMessage("Şifrə ən az 6 simvol olmalıdır.")
                .Matches(@"[A-Z]+").WithMessage("Şifrə ən az bir böyük hərf içərməlidir.")
                .Matches(@"[a-z]+").WithMessage("Şifrə ən az bir kiçik hərf içərməlidir.")
                .Matches(@"\d+").WithMessage("Şifrə ən az bir rəqəm içərməlidir.")
                .Matches(@"[\@\!\?\*\.\#]+").WithMessage("Şifrə ən az bir xüsusi simvol içərməlidir (@!?*.# və s.).");
        }
    }
}
