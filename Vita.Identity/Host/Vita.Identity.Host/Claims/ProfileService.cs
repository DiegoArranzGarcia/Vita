using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Vita.Identity.Application.Users.Queries;

namespace Vita.Identity.Host.Claims
{
    public class ProfileService : IProfileService
    {
        private readonly IMediator _mediator;

        public ProfileService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject?.GetSubjectId();
            if (sub == null) throw new Exception("No subject Id claim present");
            if (!Guid.TryParse(sub, out Guid id)) throw new Exception("Invalid subject Id claim");

            var getUserByIdQuery = new GetUserByIdQuery() { Id = id };
            var user = await _mediator.Send(getUserByIdQuery);
            if (user == null)
                return;

            //var principal = await ClaimsFactory.CreateAsync(user);
            //if (principal == null) throw new Exception("ClaimsFactory failed to create a principal");

            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.GivenName, user.GivenName),
                new Claim(JwtClaimTypes.FamilyName, user.FamilyName),
            };

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject?.GetSubjectId();
            if (sub == null) throw new Exception("No subject Id claim present");
            if (!Guid.TryParse(sub, out Guid id)) throw new Exception("Invalid subject Id claim");

            var getUserByIdQuery = new GetUserByIdQuery() { Id = id };
            var user = await _mediator.Send(getUserByIdQuery);
            //if (user == null)
            //{
            //    Logger?.LogWarning("No user found matching subject Id: {0}", sub);
            //}

            context.IsActive = user != null;
        }
    }
}
