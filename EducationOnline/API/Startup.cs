using AspNetCoreRateLimit;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Education.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace API
{
    public class Startup
    {
        private readonly ConfigHelper _configHelper;
        private readonly IHostEnvironment _env;

        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            _configHelper = new ConfigHelper();
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });


                //����swagger��֤����
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "���¿�����������ͷ����Ҫ���Jwt��ȨToken��Bearer Token",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                //���ȫ�ְ�ȫ����
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"}
                        },new string[] { }
                    }
                });
            });

            #region ע��jwt
            JWTTokenOptions JWTTokenOptions = new JWTTokenOptions();



            var jwt = _configHelper.Get<JWTTokenOptions>("jwt", _env.EnvironmentName, true);

            //��ȡappsettings������
            //services.Configure<JWTTokenOptions>(this.Configuration.GetSection("JWTToken"));
            //�������Ķ���ʵ���󶨵�ָ�������ý�
            //Configuration.Bind(jwt.Expire.ToString(), JWTTokenOptions.Expire);
            //Configuration.Bind(jwt.Audience, JWTTokenOptions.Audience);
            //Configuration.Bind(jwt.Issuer, JWTTokenOptions.Issuer);
            //Configuration.Bind(jwt.Secret, JWTTokenOptions.Secret);
            JWTTokenOptions.Secret = jwt.Secret;
            JWTTokenOptions.Expire = jwt.Expire;
            JWTTokenOptions.Audience = jwt.Audience;
            JWTTokenOptions.Issuer = jwt.Issuer;
            //ע�ᵽIoc����
            services.AddSingleton(JWTTokenOptions);



            services.AddSingleton(new RedisHelper());
            //����Ȩ��
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
            });

            //�����֤����
            services.AddAuthentication(option =>
            {
                //Ĭ�������֤ģʽ
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //Ĭ�Ϸ���
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                //����Ԫ���ݵ�ַ��Ȩ���Ƿ���ҪHTTP
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                //������֤����
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //��ȡ������Ҫʹ�õ�Microsoft.IdentityModel.Tokens.SecurityKey����ǩ����֤��
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.
                    GetBytes(JWTTokenOptions.Secret)),
                    //��ȡ������һ��System.String������ʾ��ʹ�õ���Ч�����߼����ҵķ����ߡ� 
                    ValidIssuer = JWTTokenOptions.Issuer,
                    //��ȡ������һ���ַ��������ַ�����ʾ�����ڼ�����Ч���ڷ������ƵĹ��ڡ�
                    ValidAudience = JWTTokenOptions.Audience,
                    //�Ƿ���֤������
                    ValidateIssuer = false,
                    //�Ƿ���֤������
                    ValidateAudience = false,
                    ////����ķ�����ʱ��ƫ����
                    ClockSkew = TimeSpan.Zero,
                    ////�Ƿ���֤Token��Ч�ڣ�ʹ�õ�ǰʱ����Token��Claims�е�NotBefore��Expires�Ա�
                    ValidateLifetime = true
                };
                //���jwt���ڣ��ڷ��ص�header�м���Token-Expired�ֶ�Ϊtrue��ǰ���ڻ�ȡ����headerʱ�ж�
                option.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            #endregion
            services.AddScoped<ICRUD, MySqlDapperHelper>();

            #region ���ݿ�����
            var dbConfig = _configHelper.Get<DbConfig>("dbConfig",_env.EnvironmentName,true);
            #endregion

            #region     ��̨ԭ�����
            //< !--��Startup���ConfigureServices()�����н������ã�DefaultContractResolver() ԭ����������ص� json ���̨����һ��-- >
            services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null);
            #endregion 

            #region ��������
            //��������
            services.AddOptions();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);//���ü����԰汾
            services.AddMemoryCache();
            //����IpRateLimiting����
            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            var ratelimitconfig = _configHelper.Load("rateLimit", _env.EnvironmentName, true);  //��ȡ�Զ���IP��������
            services.Configure<IpRateLimitOptions>(ratelimitconfig.GetSection("IpRateLimiting"));
            //ע��������͹���洢
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            //��ӿ�ܷ���
            services.AddMvc();
            // clientId / clientIp������ʹ������
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //���ã���������Կ��������
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            #endregion

            #region AutoMapper �Զ�ӳ��

            var serviceAssembly = Assembly.Load("Education.Service");
            services.AddAutoMapper(serviceAssembly);

            #endregion

            #region Core��������
            services.AddCors(c =>
            {
                c.AddPolicy("CorsPolicy", policy =>
                {
                    var corsPath = _configHelper.Load("corUrls", _env.EnvironmentName, true).GetSection("CorsPaths").GetChildren().Select(p => p.Value).ToArray();
                    policy
                    .WithOrigins(corsPath)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()//ָ������cookie
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(60));
                    //����ӿ�����֤��һ�ο�������60�������ٴ�����ʱ��������Ҫ��֤����
                });
            });
            #endregion

            #region Redis
            services.AddSingleton(new RedisHelper());
            //redis����
            var section = Configuration.GetSection("Redis:Default");
            //�����ַ���
            ConfigHelperRedis._conn = section.GetSection("Connection").Value;

            //ʵ��������
            ConfigHelperRedis._name = section.GetSection("InstanceName").Value;
            //Ĭ�����ݿ�
            ConfigHelperRedis._db = int.Parse(section.GetSection("DefaultDB").Value ?? "0");
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseLog();

            app.UseIpRateLimiting();//��������м��

            app.UseRouting();

            app.UseStaticFiles();//�ļ�

            app.UseAuthentication();  //�����֤

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //��������
        public void ConfigureContainer(ContainerBuilder builder)
        {

            #region ������ע��
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<RedisCacheInterceptor>();
            builder.RegisterType<TransactionInterceptor>();
            #endregion

            //���س���
            var Service = Assembly.Load("Education.Service");
            var Service1 = Assembly.Load("Education.Repository");

            //��������Լ���������Ľӿں�ʵ�־���Service��β����ʵ�ַ���ӿںͷ���ʵ�ֵ�����
            builder.RegisterAssemblyTypes(Service, Service1)
                .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()//AsImplementedInterfaces()  ���Խӿڷ�ʽ����ע��,ע����Щ������еĹ����ӿ���Ϊ���񣨳����ͷ���Դ��
                .PropertiesAutowired()
                .InstancePerLifetimeScope()    //�̶߳���
                .EnableInterfaceInterceptors()//����������
                .InterceptedBy(typeof(LogInterceptor), typeof(RedisCacheInterceptor), typeof(TransactionInterceptor));

            
        }
    }
}
