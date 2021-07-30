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


                //启用swagger验证功能
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                //添加全局安全条件
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

            #region 注册jwt
            JWTTokenOptions JWTTokenOptions = new JWTTokenOptions();



            var jwt = _configHelper.Get<JWTTokenOptions>("jwt", _env.EnvironmentName, true);

            //获取appsettings的内容
            //services.Configure<JWTTokenOptions>(this.Configuration.GetSection("JWTToken"));
            //将给定的对象实例绑定到指定的配置节
            //Configuration.Bind(jwt.Expire.ToString(), JWTTokenOptions.Expire);
            //Configuration.Bind(jwt.Audience, JWTTokenOptions.Audience);
            //Configuration.Bind(jwt.Issuer, JWTTokenOptions.Issuer);
            //Configuration.Bind(jwt.Secret, JWTTokenOptions.Secret);
            JWTTokenOptions.Secret = jwt.Secret;
            JWTTokenOptions.Expire = jwt.Expire;
            JWTTokenOptions.Audience = jwt.Audience;
            JWTTokenOptions.Issuer = jwt.Issuer;
            //注册到Ioc容器
            services.AddSingleton(JWTTokenOptions);



            services.AddSingleton(new RedisHelper());
            //【授权】
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
            });

            //添加验证服务
            services.AddAuthentication(option =>
            {
                //默认身份验证模式
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //默认方案
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                //设置元数据地址或权限是否需要HTTP
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                //令牌验证参数
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //获取或设置要使用的Microsoft.IdentityModel.Tokens.SecurityKey用于签名验证。
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.
                    GetBytes(JWTTokenOptions.Secret)),
                    //获取或设置一个System.String，它表示将使用的有效发行者检查代币的发行者。 
                    ValidIssuer = JWTTokenOptions.Issuer,
                    //获取或设置一个字符串，该字符串表示将用于检查的有效受众反对令牌的观众。
                    ValidAudience = JWTTokenOptions.Audience,
                    //是否验证发起人
                    ValidateIssuer = false,
                    //是否验证订阅者
                    ValidateAudience = false,
                    ////允许的服务器时间偏移量
                    ClockSkew = TimeSpan.Zero,
                    ////是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                    ValidateLifetime = true
                };
                //如果jwt过期，在返回的header中加入Token-Expired字段为true，前端在获取返回header时判断
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

            #region 数据库连接
            var dbConfig = _configHelper.Get<DbConfig>("dbConfig",_env.EnvironmentName,true);
            #endregion

            #region     后台原样输出
            //< !--在Startup类的ConfigureServices()方法中进行配置，DefaultContractResolver() 原样输出，返回的 json 与后台定义一致-- >
            services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null);
            #endregion 

            #region 限流配置
            //加载配置
            services.AddOptions();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);//设置兼容性版本
            services.AddMemoryCache();
            //加载IpRateLimiting配置
            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            var ratelimitconfig = _configHelper.Load("rateLimit", _env.EnvironmentName, true);  //读取自定义IP限流配置
            services.Configure<IpRateLimitOptions>(ratelimitconfig.GetSection("IpRateLimiting"));
            //注入计数器和规则存储
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            //添加框架服务
            services.AddMvc();
            // clientId / clientIp解析器使用它。
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //配置（计数器密钥生成器）
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            #endregion

            #region AutoMapper 自动映射

            var serviceAssembly = Assembly.Load("Education.Service");
            services.AddAutoMapper(serviceAssembly);

            #endregion

            #region Core跨域请求
            services.AddCors(c =>
            {
                c.AddPolicy("CorsPolicy", policy =>
                {
                    var corsPath = _configHelper.Load("corUrls", _env.EnvironmentName, true).GetSection("CorsPaths").GetChildren().Select(p => p.Value).ToArray();
                    policy
                    .WithOrigins(corsPath)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()//指定处理cookie
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(60));
                    //如果接口已验证过一次跨域，则在60分钟内再次请求时，将不需要验证跨域
                });
            });
            #endregion

            #region Redis
            services.AddSingleton(new RedisHelper());
            //redis缓存
            var section = Configuration.GetSection("Redis:Default");
            //连接字符串
            ConfigHelperRedis._conn = section.GetSection("Connection").Value;

            //实例化名称
            ConfigHelperRedis._name = section.GetSection("InstanceName").Value;
            //默认数据库
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

            app.UseIpRateLimiting();//添加限流中间件

            app.UseRouting();

            app.UseStaticFiles();//文件

            app.UseAuthentication();  //添加认证

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //其他代码
        public void ConfigureContainer(ContainerBuilder builder)
        {

            #region 拦截器注入
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<RedisCacheInterceptor>();
            builder.RegisterType<TransactionInterceptor>();
            #endregion

            //加载程序集
            var Service = Assembly.Load("Education.Service");
            var Service1 = Assembly.Load("Education.Repository");

            //根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(Service, Service1)
                .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()//AsImplementedInterfaces()  是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
                .PropertiesAutowired()
                .InstancePerLifetimeScope()    //线程独立
                .EnableInterfaceInterceptors()//开启拦截器
                .InterceptedBy(typeof(LogInterceptor), typeof(RedisCacheInterceptor), typeof(TransactionInterceptor));

            
        }
    }
}
