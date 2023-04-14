using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorHtmlRendering;

IServiceCollection services = new ServiceCollection();
services.AddLogging();

IServiceProvider serviceProvider = services.BuildServiceProvider();
ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);
var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
{
    var output = await htmlRenderer.RenderComponentAsync<MyComponent>(ParameterView.Empty);
    return output.ToHtmlString();
});

Console.WriteLine(html);
