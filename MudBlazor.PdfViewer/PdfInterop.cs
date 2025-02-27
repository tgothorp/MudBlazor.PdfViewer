using Microsoft.JSInterop;

internal class PdfInterop(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> js =
        new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Gotho.MudBlazor.PdfViewer/mudpdf.min.js").AsTask());

    public async Task InitializeAsync(object objRef, string elementId, string documentUrl, double scale, double rotation, bool singlePageMode, string? password = null)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("init", objRef, elementId, documentUrl, scale, rotation, singlePageMode, password);
    }

    public async Task FirstPageAsync(object objRef, string elementId)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("firstPage", objRef, elementId);
    }

    public async Task LastPageAsync(object objRef, string elementId)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("lastPage", objRef, elementId);
    }

    public async Task PreviousPageAsync(object objRef, string elementId)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("previousPage", objRef, elementId);
    }

    public async Task NextPageAsync(object objRef, string elementId)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("nextPage", objRef, elementId);
    }

    public async Task GotoPageAsync(object objRef, string elementId, int gotoPageNum)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("goToPage", objRef, elementId, gotoPageNum);
    }

    public async Task ZoomInOutAsync(object objRef, string elementId, double scale)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("zoom", objRef, elementId, scale);
    }

    public async Task RotateAsync(object objRef, string elementId, double rotation)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("rotate", objRef, elementId, rotation);
    }

    public async Task PrintDocumentAsync(object objRef, string elementId)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("printDocument", objRef, elementId);
    }

    public async Task DownloadDocumentAsync(object objRef, string elementId)
    {
        var module = await js.Value;
        await module.InvokeVoidAsync("downloadDocument", objRef, elementId);
    }

    public async ValueTask DisposeAsync()
    {
        if (js.IsValueCreated)
        {
            var module = await js.Value;
            await module.DisposeAsync();
        }
    }
}