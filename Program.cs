using Kontent.Ai.Delivery.Extensions.DependencyInjection;
using ShowcaseCookiesStateNet.Models.Generated;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMultipleDeliveryClientFactory
 (
            factoryBuilder => factoryBuilder
                .AddDeliveryClient
                (
                    "production",
                    deliveryOptionBuilder => deliveryOptionBuilder
                        .WithProjectId("6d7f2b4b-9432-012e-f6be-c9feb74c3912")
                        .UseProductionApi()
                        .Build(),
                    optionalClientSetup =>
                        optionalClientSetup.WithTypeProvider(new CustomTypeProvider())
                )
                .AddDeliveryClient(
                    "preview",
                    deliveryOptionBuilder => deliveryOptionBuilder
                        .WithProjectId("6d7f2b4b-9432-012e-f6be-c9feb74c3912")
                        .UsePreviewApi("ew0KICAiYWxnIjogIkhTMjU2IiwNCiAgInR5cCI6ICJKV1QiDQp9.ew0KICAianRpIjogIjI0MDlhNzhjNmU4ODRlMzI5YWQwMGIxZTA0NWQzZmNlIiwNCiAgImlhdCI6ICIxNjc0NTYyNDIxIiwNCiAgImV4cCI6ICIxNzA2MDk4MzgwIiwNCiAgInZlciI6ICIxLjAuMCIsDQogICJwcm9qZWN0X2lkIjogIjZkN2YyYjRiOTQzMjAxMmVmNmJlYzlmZWI3NGMzOTEyIiwNCiAgImF1ZCI6ICJwcmV2aWV3LmRlbGl2ZXIua2VudGljb2Nsb3VkLmNvbSINCn0._z-kyRCcDwSwS-74zWF6gRnnSFwEFhKEdPGQXahY1xY")
                        .Build(),
                    optionalClientSetup =>
                        optionalClientSetup.WithTypeProvider(new CustomTypeProvider())
                )
                .Build()
        ); ;

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
