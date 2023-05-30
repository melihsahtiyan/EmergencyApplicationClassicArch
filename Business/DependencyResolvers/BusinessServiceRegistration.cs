using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAllergyService, AllergyManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IOngoingDiseaseService, OngoingDiseaseManager>();
            services.AddScoped<IMedicationService, MedicationManager>();
            services.AddScoped<ISourceService, SourceManager>();
            services.AddScoped<ISystemStaffService, SystemStaffManager>();
            services.AddScoped<IUserAllergiesService, UserAllergiesManager>();
            services.AddScoped<IUserOngoingDiseaseService, UserOngoingDiseaseManager>();
            services.AddScoped<IUserMedicationsService, UserMedicationsManager>();
            services.AddScoped<IUserProfileService, UserProfileManager>();
            services.AddScoped<IUserService, UserManager>();
            //services.AddScoped<IOperationClaimService, OperationClaimManager>();
            services.AddScoped<IPostService, PostManager>();
            services.AddScoped<IPostTemplateService, PostTemplateManager>();
            //services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
            //services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
            services.AddScoped<ITokenHelper,JwtHelper>();

            return services;
        }
    }
}
