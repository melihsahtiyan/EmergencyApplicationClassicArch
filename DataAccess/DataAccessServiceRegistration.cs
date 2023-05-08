using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
            IConfiguration configuration)

        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ResqDatabaseConnectionString")));
            services.AddScoped<IAllergyDal, AllergyDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IEmailAuthenticatorDal, EmailAuthenticatorDal>();
            services.AddScoped<IMedicalHistoryDal, MedicalHistoryDal>();
            services.AddScoped<IMedicationDal, MedicationDal>();
            services.AddScoped<IOperationClaimDal, OperationClaimDal>();
            services.AddScoped<IOtpAuthenticatorDal, OtpAuthenticatorDal>();
            services.AddScoped<IPostDal, PostDal>();
            services.AddScoped<IPostTemplateDal, PostTemplateDal>();
            services.AddScoped<IRefreshTokenDal, RefreshTokenDal>();
            services.AddScoped<ISourceDal, SourceDal>();
            services.AddScoped<ISystemStaffDal, SystemStaffDal>();
            services.AddScoped<IUserProfileDal, UserProfileDal>();
            services.AddScoped<IUserAllergiesDal, UserAllergiesDal>();
            services.AddScoped<IUserMedicalHistoryDal, UserMedicalHistoryDal>();
            services.AddScoped<IUserMedicationDal, UserMedicationDal>();
            services.AddScoped<IUserOperationClaimDal, UserOperationClaimDal>();
            services.AddScoped<IUserDal, UserDal>();
            return services;
        }
    }
}
