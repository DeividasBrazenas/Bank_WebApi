namespace Bank.WebApi.Middleware.DependencyContainer
{
    using System;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using Services.DataAgents.Account;
    using Services.DataAgents.Customer;
    using Services.DataAgents.Loan;
    using Services.DataAgents.Logs;
    using Services.DomainServices.Account;
    using Services.DomainServices.Customer;
    using Services.DomainServices.Loan;
    using Services.Mappers.Accounts;
    using Services.Mappers.Customers;
    using Services.Mappers.Loans;
    using Services.Mappers.Log;
    using Services.Repositories.Account;
    using Services.Repositories.Customer;
    using Services.Repositories.Loan;
    using Services.Services.Account;
    using Services.Services.Customer;
    using Services.Services.Loan;
    using Services.Services.Logs;

    public static class AutofacConfig
    {
        public static IServiceProvider RegisterAutofacDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var containerBuilder = new ContainerBuilder();

            services.AddSingleton(configuration);

            containerBuilder.Populate(services);

            containerBuilder.Register(x => Log.Logger).SingleInstance();

            containerBuilder.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerDependency();
            containerBuilder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerDependency();
            containerBuilder.RegisterType<LoanRepository>().As<ILoanRepository>().InstancePerDependency();

            containerBuilder.RegisterType<AccountDataAgent>().As<IAccountDataAgent>().InstancePerDependency();
            containerBuilder.RegisterType<CustomerDataAgent>().As<ICustomerDataAgent>().InstancePerDependency();
            containerBuilder.RegisterType<LoanDataAgent>().As<ILoanDataAgent>().InstancePerDependency();

            containerBuilder.RegisterType<AccountService>().As<IAccountService>().InstancePerDependency();
            containerBuilder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerDependency();
            containerBuilder.RegisterType<LoanService>().As<ILoanService>().InstancePerDependency();

            containerBuilder.RegisterType<StandardAccountMapper>().As<IAccountMapper>().InstancePerDependency();
            containerBuilder.RegisterType<StandardCustomerMapper>().As<ICustomerMapper>().InstancePerDependency();
            containerBuilder.RegisterType<StandardLoanMapper>().As<ILoanMapper>().InstancePerDependency();

            containerBuilder.RegisterType<StandardAccountDomainService>().As<IAccountDomainService>().InstancePerDependency();
            containerBuilder.RegisterType<StandardCustomerDomainService>().As<ICustomerDomainService>().InstancePerDependency();
            containerBuilder.RegisterType<StandardLoanDomainService>().As<ILoanDomainService>().InstancePerDependency();

            containerBuilder.RegisterType<LogDataAgent>().As<ILogDataAgent>().InstancePerDependency();
            containerBuilder.RegisterType<LogMapper>().As<ILogMapper>().InstancePerDependency();
            containerBuilder.RegisterType<LogService>().As<ILogService>().InstancePerDependency();

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            return serviceProvider;
        }
    }
}