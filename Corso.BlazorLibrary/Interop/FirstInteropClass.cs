using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
namespace Corso.BlazorLibrary.Interop;

public class FirstInteropClass: IDisposable
{
    private readonly IJSRuntime jSRuntime;
    private DotNetObjectReference<HelloHelper>? helloHelperReference;


    public FirstInteropClass(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
    }

    public void Dispose()
    {
        helloHelperReference?.Dispose();
    }

    public async Task OpenModalAsync(string id)
    {
        await jSRuntime.InvokeVoidAsync("openModal", id);
    }

    public async Task CloseModalAsync ()
    {
        await jSRuntime.InvokeVoidAsync("closeModal");
    }

    public async Task  CallHelloHelperSayHello(string name)
    {
        helloHelperReference = DotNetObjectReference
            .Create(new HelloHelper(name));

        await jSRuntime.InvokeVoidAsync("sayHello", helloHelperReference);
    } 

    public async Task FirstFunction(string name, int a, int b)
    {
        await jSRuntime
        .InvokeVoidAsync("myFirstJavascriptFunction",
        name, a, b);
    }

    public async Task<int> SecondFunction(int a, int b)
    {
       return await jSRuntime
            .InvokeAsync<int>("mySecondJavaScriptFunction",
                a, b);
    }

    public async Task ThirdFunction()
    {
        await jSRuntime
            .InvokeVoidAsync("myThirdFunction");
    }

    public async Task OpenMap(double latitude, 
        double longitude, 
        int zoomLevel,
        List<MyMarker> markers)
    {
        await jSRuntime.InvokeVoidAsync(
            "showMap", latitude, longitude, zoomLevel, markers);
    }

}
