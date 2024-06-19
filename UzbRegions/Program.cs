var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();
builder.Services.AddOutputCache();

#region CORS Policy for all origins
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicyName", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
#endregion

#region Add rate limiting to DI services

/*builder.Services.Configure<IpRateLimitOptions>
    (builder.Configuration.GetSection("IpRateLimit"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();*/
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
//app.UseIpRateLimiting();
app.UseHttpsRedirection();
app.UseCors("DefaultCorsPolicyName");
app.UseAuthorization();
app.UseResponseCaching();
app.UseOutputCache();
app.MapControllers();
app.Run();