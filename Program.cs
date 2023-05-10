using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorHtmlRendering;

IServiceCollection services = new ServiceCollection();
services.AddLogging();

IServiceProvider serviceProvider = services.BuildServiceProvider();
ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

var dictionary = new Dictionary<string, object?>
{
    { "Message", "Hello from Render Component Example!" }
};

await using var htmlRenderer = new HtmlRenderer(serviceProvider, loggerFactory);
var html = await htmlRenderer.Dispatcher.InvokeAsync(async () =>
{
    var parameters = ParameterView.FromDictionary(dictionary);

    var output = await htmlRenderer.RenderComponentAsync<MyComponent>(parameters);
    return output.ToHtmlString();
});

Console.WriteLine(html);
