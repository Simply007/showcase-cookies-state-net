using Kontent.Ai.Delivery.Extensions.DependencyInjection;

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
                        .Build()
                    // optionalClientSetup =>
                        // optionalClientSetup.WithTypeProvider(new ProjectAProvider())
                )
                .AddDeliveryClient(
                    "preview",
                    deliveryOptionBuilder => deliveryOptionBuilder
                        .WithProjectId("6d7f2b4b-9432-012e-f6be-c9feb74c3912")
                        .UsePreviewApi("ew0KICAiYWxnIjogIkhTMjU2IiwNCiAgInR5cCI6ICJKV1QiDQp9.ew0KICAianRpIjogImQ0YzIwYjE4ZmM1ZjRhYmU4ZWFmMmY2NjE2YTJiYjQ3IiwNCiAgImlhdCI6ICIxNjc0NTYwODgxIiwNCiAgImV4cCI6ICIxNzA2MDk2ODIwIiwNCiAgInZlciI6ICIxLjAuMCIsDQogICJwcm9qZWN0X2lkIjogIjZkN2YyYjRiOTQzMjAxMmVmNmJlYzlmZWI3NGMzOTEyIiwNCiAgImF1ZCI6ICJkZWxpdmVyLmtlbnRpY29jbG91ZC5jb20iDQp9.AgQTXM-IFZ5WJcMPJZNgbwMjZFZ-T0WE5APNqDa0U7o")
                        .Build()
                    // optionalClientSetup =>
                    //     optionalClientSetup.WithTypeProvider(new ProjectBProvider())
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
// wefrweg
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
